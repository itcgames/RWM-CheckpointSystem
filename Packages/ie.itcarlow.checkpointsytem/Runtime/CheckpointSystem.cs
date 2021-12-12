using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CheckpointSystem : MonoBehaviour
{
    [System.Serializable]
    public class MyList<T>
    {
        public List<string> name = new List<string>();

        public List<T> data = new List<T>();
    }

    [System.Serializable]
    public class Info
    {
        public MyList<int> intList = new MyList<int>();
        public MyList<float> floatList = new MyList<float>();
        public MyList<string> stringList = new MyList<string>();
        public MyList<Vector2> vector2List = new MyList<Vector2>();
    }

    //save file location
    string filename;
    public Info info;
    public ArrayList arrayList = new ArrayList();

    public void Awake()
    {
        filename = Application.dataPath + "playerData.txt";
        info = new Info();

        arrayList.Add(info.intList);
        arrayList.Add(info.floatList);
        arrayList.Add(info.stringList);
        arrayList.Add(info.vector2List);

    }

    public string fileLoc()
    {
        return filename;
    }

    public void AddToIntList(string s, int data)
    {
        info.intList.name.Add(s);
        info.intList.data.Add(data);        
    }

    public void AddToFloatList(string s, float data)
    {
        info.floatList.name.Add(s);
        info.floatList.data.Add(data);
    }

    public void AddToStringList(string s, string data)
    {
        info.stringList.name.Add(s);
        info.stringList.data.Add(data);
    }

    public void AddToVector2List(string s, Vector2 data)
    {
        info.vector2List.name.Add(s);
        info.vector2List.data.Add(data);
    }

    public void SaveDataToFile()
    {
        TextWriter tw;
        if (!File.Exists(filename))
        {
            
            tw = new StreamWriter(filename, false);
            tw.Close();
        }
        tw = new StreamWriter(filename, false);

        foreach(var i in arrayList)
        {
            tw.WriteLine(JsonUtility.ToJson(i));
        }

        tw.Close();
    }
}
