using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CheckpointSystem : MonoBehaviour
{
    [System.Serializable]
    public struct SavaData<t>
    {
        public string name;
        public t data;
    }

    //save file location
    string filename;

    //player data lists
    public List<SavaData<int>> playerDataInt;
    public List<SavaData<float>> playerDataFloat;
    public List<SavaData<Vector2>> playerDataVec2;

    public List<SavaData<int>> gameDataInt;
    public List<SavaData<float>> gameDataFloat;
    public List<SavaData<string>> gameDataString;

    public void Awake()
    {
        filename = Application.dataPath + "playerData.txt";
        playerDataFloat = new List<SavaData<float>>();
        playerDataInt = new List<SavaData<int>>();
        playerDataVec2 = new List<SavaData<Vector2>>();

        gameDataFloat = new List<SavaData<float>>();
        gameDataInt = new List<SavaData<int>>();
        gameDataString = new List<SavaData<string>>();

    }

    public string fileLoc()
    {
        return filename;
    }

    public void AddPlayerData<T>(string t_string, T t_data)
    {
        //All player int data needed
        if(t_data is int)
        {
            SavaData<int> data;
            data.name = t_string;
            data.data = (int)Convert.ChangeType(t_data, typeof(int));
            playerDataInt.Add(data);
        }
        else if(t_data is float) //All player float data needed
        {
            SavaData<float> data;
            data.name = t_string;
            data.data = (float)Convert.ChangeType(t_data, typeof(float));
            playerDataFloat.Add(data);
        }
        else if (t_data is Vector2) //All player vector data needed
        {
            SavaData<Vector2> data;
            data.name = t_string;
            data.data = (Vector2)Convert.ChangeType(t_data, typeof(Vector2));
            playerDataVec2.Add(data);
        }
    }

    public void AddGameData<T>(string t_string, T t_data)
    {
        //All player int data needed
        if (t_data is int)
        {
            SavaData<int> data;
            data.name = t_string;
            data.data = (int)Convert.ChangeType(t_data, typeof(int));
            gameDataInt.Add(data);
        }
        else if (t_data is float) //All player float data needed
        {
            SavaData<float> data;
            data.name = t_string;
            data.data = (float)Convert.ChangeType(t_data, typeof(float));
            gameDataFloat.Add(data);
        }
        else if (t_data is string) //All player vector data needed
        {
            SavaData<string> data;
            data.name = t_string;
            data.data = (string)Convert.ChangeType(t_data, typeof(string));
            gameDataString.Add(data);
        }
    }

    public void SaveData()
    {
        TextWriter tw;
        if (!File.Exists(filename))
        {
            tw = new StreamWriter(filename, false);
            tw.Close();
        }
        tw = new StreamWriter(filename, true);

        if (playerDataInt != null)
        {
            tw.WriteLine("Int Player Data \n");
            for (int i = 0; i < playerDataInt.Count; i++)
            {
                tw.WriteLine(playerDataInt[i].name + " , " + playerDataInt[i].data);
            }
        }

        if (playerDataFloat != null)
        {
            tw.WriteLine("\nFloat Player Data \n");
            for (int i = 0; i < playerDataFloat.Count; i++)
            {
                tw.WriteLine(playerDataFloat[i].name + " , " + playerDataFloat[i].data);
            }
        }

        if (playerDataVec2 != null)
        {
            tw.WriteLine("\nVector2 Player Data\n");
            for (int i = 0; i < playerDataVec2.Count; i++)
            {
                tw.WriteLine(playerDataVec2[i].name + " , " + playerDataVec2[i].data);
            }
        }

        if (gameDataInt != null)
        {
            tw.WriteLine("\nInt Game Data\n");
            for (int i = 0; i < gameDataInt.Count; i++)
            {
                tw.WriteLine(gameDataInt[i].name + " , " + gameDataInt[i].data);
            }
        }

        if (gameDataFloat != null)
        {
            tw.WriteLine("\nFloat Game Data\n");
            for (int i = 0; i < gameDataFloat.Count; i++)
            {
                tw.WriteLine(gameDataFloat[i].name + " , " + gameDataFloat[i].data);
            }
        }

        if (gameDataString != null)
        {
            tw.WriteLine("\nString Game Data\n");
            for (int i = 0; i < gameDataString.Count; i++)
            {
                tw.WriteLine(gameDataString[i].name + " , " + gameDataString[i].data);
            }
        }

        tw.Close();
    }
}
