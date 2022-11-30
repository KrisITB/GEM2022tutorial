using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public static class SaveDataOld
{
    public static void SaveFile()
    {
        string path = GetPath(false);

        if (!File.Exists(path))
        {
            string columns = "time, question 1, question 2, question3";
            using (StreamWriter columnsWriter = new StreamWriter(path))
            {
                columnsWriter.WriteLine(columns);
            }
        }

        StreamWriter sw = new StreamWriter(path, true);
        string answers = DateTime.UtcNow.ToString() + "." + System.DateTime.UtcNow.Millisecond.ToString();
        foreach (int answer in Data.Answers)
        {
            answers += "," + answer;
        }
        sw.WriteLine(answers);
        sw.Close();
    }

    public static void SaveTimeSeries()
    {
        string path = GetPath(true);
        if (!File.Exists(path))
        {
            string columns = "time, slider, yes/no";
            using (StreamWriter columnsWriter = new StreamWriter(path))
            {
                columnsWriter.WriteLine(columns);
            }
        }
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            string tsAnswers = DateTime.UtcNow.ToString() + "." + System.DateTime.UtcNow.Millisecond.ToString() + "," + Data.SliderValue + "," + Data.YesNo;
        }
    }

    private static string GetPath(bool timeSeries)
    {
        string fileName = "";
        if (timeSeries)
        {
            fileName = Data.ID + ".csv";
        }
        else
        {
            fileName = "questionnaire.csv";
        }
        
        return Path.Combine(Application.persistentDataPath, fileName);
    }
}
