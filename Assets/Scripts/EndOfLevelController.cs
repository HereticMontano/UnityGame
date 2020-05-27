using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelController : MonoBehaviour
{

    private DialogManagerController dialogManager;
    private bool IsInTheEnd;

    private void Awake()
    {
        dialogManager = FindObjectOfType<DialogManagerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsInTheEnd = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (IsInTheEnd && dialogManager.IsDialogClose)
            SceneManager.LoadScene(2);
    }
}
