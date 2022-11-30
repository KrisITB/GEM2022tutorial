using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public static class SaveData
{
    public static void SaveFile(bool ts = false)
    {
        string path = GetPath(ts);

        if (!File.Exists(path))
        {
            string columns = "time, question 1, question 2, question 3";
            if (ts)
            {
                columns = "time, button,slider";
            }
            using (StreamWriter columnsWriter = new StreamWriter(path))
            {
                columnsWriter.WriteLine(columns);
            }
        }

        StreamWriter sw = new StreamWriter(path, true);

        string answers;
        if (!ts)
        {
            answers = DataHolder.ID;
            foreach (int answer in DataHolder.Answers)
            {
                answers += "," + answer;
            }
        }
        else
        { 
            answers = DateTime.UtcNow.ToString() +
                "." + DateTime.UtcNow.Millisecond.ToString() +
                "," +
                DataHolder.TurnedOn + 
                "," +
                DataHolder.SliderValue;
        }
        
        sw.WriteLine(answers);
        sw.Close();

        if (!ts)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    private static string GetPath(bool ts)
    {
        string fileName = "questionnaire.csv";
        if (ts)
        {
            fileName = DataHolder.ID + ".csv";
        }
        return Path.Combine(Application.persistentDataPath, fileName);
    }
}
