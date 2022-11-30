using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderController : MonoBehaviour, IPointerUpHandler
{
    Slider slider;
    Image[] sliderImages;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
        sliderImages = slider.GetComponentsInChildren<Image>();
    }

    public void NewValue()
    {
        foreach(Image image in sliderImages)
        {
            image.color = Color.Lerp(Color.blue, Color.red, slider.value);
        }
        DataHolder.SliderValue = slider.value;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SaveData.SaveFile(true);
    }
}
