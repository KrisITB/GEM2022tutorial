using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderButtonCTRL : MonoBehaviour
{
    public void Pressed()
    {
        Debug.Log("pressed?");
    }
    public void Deselected()
    {
        Debug.Log("Deselected");
    }
    public void Selected()
    {
        Debug.Log("Selected");
    }
}
