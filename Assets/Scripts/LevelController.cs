using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject levelContainer;
    public GameObject canvasContainer;
    void Start()
    {
        Invoke("HideLevelScreen", 1);
    }

    private void HideLevelScreen()
    {
        levelContainer.SetActive(true);
        canvasContainer.SetActive(false);
    }

}
