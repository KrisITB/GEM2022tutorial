using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionnaireController : MonoBehaviour
{
    private int currentQuestion = 0;
    [SerializeField] List<GameObject> questions;

    [SerializeField] Button next;
    [SerializeField] Button back;

    private void Start()
    {
        currentQuestion = 1;
        SetActiveQuestion(currentQuestion);
    }

    private void SetButtons(int questionNumber)
    {
        if (questionNumber == 1)
        {
            back.interactable = false;
        }
        else if (questionNumber == questions.Count)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;
            back.interactable = true;
        }
    }
    private void SetActiveQuestion(int questionNumber)
    {
        foreach (GameObject question in questions)
        {
            question.SetActive(false);
        }
        questions[questionNumber - 1].SetActive(true);
        SetButtons(currentQuestion);
    }
    public void ChangeQuestion(int direction)
    {
        currentQuestion += direction;
        SetActiveQuestion(currentQuestion);
    }

    public void Submit()
    {
        SaveData.SaveFile();
    }
}
