using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TreeEditor;
using UnityEngine;

public class BackGroundLoopController : MonoBehaviour
{
    public GameObject[] back;
    public float Choke;

    private Vector2 screenBounds;

    private void Start()
    {
        var mainCamara = GetComponent<Camera>();
        screenBounds = mainCamara.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamara.transform.position.z));

        foreach (var root in back)
        {
            LoadChildObjects(root.gameObject);
        }

    }

    private void LoadChildObjects(GameObject obj)
    {
        var objecWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - Choke;
        int childNeed =  (int)Mathf.Ceil(screenBounds.x * 2 / objecWidth);
        var clone = Instantiate(obj);
        for (int i = 0; i <= childNeed; i++)
        {
            var c = Instantiate(clone);
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objecWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    private void RepositeChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            var firstChild = children[1].gameObject;
            var lastChild = children.Last().gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - Choke;

            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
    private void LateUpdate()
    {
        foreach (var root in back)
        {
            RepositeChildObjects(root.gameObject);
        }
    }
}
