using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    private CuestionaryControll cuestionaryController;
    private void Start()
    {
        cuestionaryController = FindObjectOfType<CuestionaryControll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetTrigger("UpDown");
        cuestionaryController.Answer(name == "shi block");
        GetComponent<AudioSource>().Play();
    }
}
