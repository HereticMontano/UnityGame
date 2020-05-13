using UnityEngine;

public class PlatformControll : MonoBehaviour
{

    public float waitingTime = 0.5f;
    private float counter;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (counter <= 0)
            {
                GetComponent<PlatformEffector2D>().useColliderMask = true;
                counter = waitingTime;
            }
            else
                counter -= Time.deltaTime; 
        }
        else if(!Input.GetKey(KeyCode.DownArrow))
            GetComponent<PlatformEffector2D>().useColliderMask = false;
    }
}

