using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuestionaryControll : MonoBehaviour
{
    public GameObject board;

    private Queue<Questions> dialogs;
    private Questions actualQuestion;
    private TextMeshProUGUI body;

    private bool IsAQuestion => actualQuestion != null && !actualQuestion.Answer.HasValue;
    

    void Start()
    {
        dialogs = new Queue<Questions>();
        body = board.GetComponentsInChildren<TextMeshProUGUI>().First(x => x.name == "Body");
        LoadDialogs();
        DisplayNextSentence();
    }

    public void Answer(bool answer)
    {
        if (!IsAQuestion)
        {
            if (actualQuestion.Answer == answer)
            {
                body.text = "GANO LA OVEJA!";
            }
            else
                body.text = "Perdio la oveja";

            Invoke("DisplayNextSentence", 1);
        }
    }

    public void Update()
    {
        if (IsAQuestion && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }

        var foot = board.GetComponentsInChildren<TextMeshProUGUI>().First(x => x.name == "Foot");
        foot.enabled = IsAQuestion;
    }

    private void DisplayNextSentence()
    {
        if (dialogs.Any())
        {
            actualQuestion = dialogs.Dequeue();
            body.text = actualQuestion.Question;
        }
        else
            EndQuestionary();
    }

    private void EndQuestionary()
    {
        SceneManager.LoadScene(3);
    }

    private void LoadDialogs()
    {
        var respuesta = new System.Random();

        dialogs.Enqueue(new Questions() { Question = "Ahora es un juego de preguntas y respuestas, pegale un cabeza al bloque que sea la respuesta correcta" });
        dialogs.Enqueue(new Questions() { Question = "Pessoa ¿murio en 1935?", Answer = respuesta.Next(2) == 1 });
        dialogs.Enqueue(new Questions() { Question = "Si la pregunta es Shi, ¿cual es la respuesta?", Answer = false});
        dialogs.Enqueue(new Questions() { Question = "Es 2 + 2 + 2 = 222", Answer = respuesta.Next(2) == 1 });
        dialogs.Enqueue(new Questions() { Question = "Si la pregunta es Shu, ¿cual es la respuesta?", Answer = true });
    }
}

public class Questions
{
    public string Question { get; set; }
    public bool? Answer { get; set; }
}
