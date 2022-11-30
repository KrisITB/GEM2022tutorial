using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderScript : MonoBehaviour, IDeselectHandler //Interface to receive OnDeselect callbacks
{
    private Slider thisSlider;
    private Image[] sliderColors;
    private void Start()
    {
        thisSlider = this.GetComponent<Slider>();
        thisSlider.onValueChanged.AddListener(delegate { SliderValueChange(); });

        sliderColors = thisSlider.GetComponentsInChildren<Image>();
        sliderColors[0].color = Color.green;
        sliderColors[sliderColors.Length-1].color = Color.yellow;
    }

    private void SliderValueChange()
    {
        sliderColors[0].color = Color.Lerp(Color.blue, Color.red, thisSlider.value);
        sliderColors[sliderColors.Length - 1].color = Color.Lerp(Color.yellow, Color.green, thisSlider.value); ;
    }
    
    public void OnDeselect(BaseEventData data)
    {
        Data.SliderValue = thisSlider.value;
        //SaveData.SaveTimeSeries(); // REMOVED FOR COMPILATION
    }
}
