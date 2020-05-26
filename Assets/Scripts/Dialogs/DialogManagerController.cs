using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Assets.Scripts.Extension;
public class DialogManagerController : MonoBehaviour
{
    Queue<string> sentences;

    public GameObject board;

    private Dialog actualDialog;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StarDialog(Dialog dialogue)
    {
        foreach (var item in dialogue.sentences)
            sentences.Enqueue(item);

        DisplayNextSentence();

        float positionY = Camera.main.OrthographicBounds().max.y - board.GetComponent<RectTransform>().rect.width / 4;
        board.transform.position = new Vector3(Camera.main.transform.position.x, positionY);
        board.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (sentences.Any())
                DisplayNextSentence();
            else
                board.SetActive(false);
        }
    }

    private void DisplayNextSentence()
    {
        var body = board.GetComponentsInChildren<TextMeshProUGUI>().First(x => x.name == "Body");
        body.text = sentences.Dequeue();
    }
}
