using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Color turnedOnColor;
    [SerializeField] Color turnedOffColor;

    private Renderer meshRenderer;

    private void Start()
    {
        meshRenderer = this.GetComponentInChildren<Renderer>();
        
        if (DataHolder.TurnedOn)
        {
            meshRenderer.material.color = turnedOnColor;
        }
        else
        {
            meshRenderer.material.color = turnedOffColor;
        }
    }
    public void Selected()
    {
        DataHolder.TurnedOn = !DataHolder.TurnedOn;
        if (DataHolder.TurnedOn)
        {
            meshRenderer.material.color = turnedOnColor;
        }
        else
        {
            meshRenderer.material.color = turnedOffColor;
        }
        SaveData.SaveFile(true);
    }
}
