using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public static class DataHolder
{
    [SerializeField] public static string ID;

    [SerializeField] public static int[] Answers = { 0, 0, 0 };

    [SerializeField] public static bool TurnedOn = false;

    [SerializeField] public static float SliderValue = 0f;

    static DataHolder()
    {
        ID = DateTime.UtcNow.ToString().Replace("/", "-").Replace(" ", "_T_").Replace(":", "-")
            + "." + System.DateTime.UtcNow.Millisecond.ToString();
    }
}
