using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject characterCambas;
    public void Jugar()
    {
        mainCanvas.SetActive(false);
        characterCambas.SetActive(true);
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Character()
    {
        Debug.Log("Se hizo click");
    }
}
