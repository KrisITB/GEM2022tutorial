using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionnaireCTRL : MonoBehaviour
{
    [SerializeField] List<GameObject> questions;

    [SerializeField] int currentQuestion = 0;

    [SerializeField] Button next;
    [SerializeField] Button back;

    [SerializeField] Button submitButton;
    [SerializeField] TextMeshProUGUI submitPanelText;

    private bool allAnswered;

    //[SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClipThanks;
    [SerializeField] AudioClip audioClipRequestAnswers;
    [SerializeField] AudioClip audioClipOutro;

    private void Start()
    {
        currentQuestion = 1;
        SetActiveQuestion(currentQuestion);
        //audioSource = GetComponent<AudioSource>();
    }

    private void SetButtons(int questionNumber)
    {
        if (questionNumber == 1)
        {
            back.interactable = false;
        }
        else if(questionNumber == questions.Count)
        {
            next.interactable = false;

            AudioSource audioSource = questions[currentQuestion - 1].GetComponent<AudioSource>();

            allAnswered = true;
            foreach (int answer in Data.Answers)
            {
                if (answer == 0)
                {
                    allAnswered = false;
                }
            }
            if (allAnswered)
            {
                submitPanelText.text = "Thank you!\n Feel free to go back and change your answers or press submit button";
                audioSource.clip = audioClipOutro;
            }
            else
            {
                submitPanelText.text = "Please answer all questions";
                audioSource.clip = audioClipRequestAnswers;
            }
        }
        else
        {
            next.interactable = true;
            back.interactable = true;
        }
    }

    public void nextQuestion(int direction)
    {
        currentQuestion += direction;
        SetActiveQuestion(currentQuestion);
    }

    public void PlayAudio()
    {
        AudioSource audioSource = questions[currentQuestion-1].GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void SetActiveQuestion(int questionNumber)
    {
        foreach (GameObject question in questions)
        {
            question.SetActive(false);
        }
        questions[questionNumber-1].SetActive(true);
        SetButtons(currentQuestion);
    }

    public void Submit()
    {
        AudioSource audioSource = questions[currentQuestion - 1].GetComponent<AudioSource>();

        if (allAnswered)
        {
            SaveData.SaveFile();
            audioSource.clip = audioClipThanks;
        }
        else
        {
            audioSource.clip = audioClipRequestAnswers;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
    }

}
