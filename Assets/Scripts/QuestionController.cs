using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ADD to support Button class

public class QuestionController : MonoBehaviour
{
    [SerializeField] List<Button> buttons; //Buttons in question holder
    public int QuestionID = 0; //Question number holder

    public void NewAnswer(int answer) //method for highlighting last pressed button
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().color = Color.yellow;
        }
        buttons[answer - 1].GetComponent<Image>().color = Color.green;

        DataHolder.Answers[QuestionID - 1] = answer;
    }
}
