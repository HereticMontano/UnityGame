using Assets.Scripts;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManagerController : MonoBehaviour
{
    Queue<string> sentences;

    public Canvas board;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StarDialog(Dialog dialogue)
    {
        board.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.sentences[0];
        
        board.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
    }
}
