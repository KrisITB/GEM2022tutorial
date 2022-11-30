using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCtrl : MonoBehaviour
{
    [SerializeField] List<Button> buttons;
    public int questionID = 0;

    public void NewAnswer(int answer)
    {
        SetActiveButton(answer);
    }

    private void SetActiveButton(int i)
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().color = Color.yellow;
        }
        buttons[i - 1].GetComponent<Image>().color = Color.green;
    }
}
