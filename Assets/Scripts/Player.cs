using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level;
    public int speed;

    public float xp;
    public float health;

    public Vector2 pos;

    CheckpointSystem t_system;

    // Start is called before the first frame update
    void Start()
    {
        t_system = FindObjectOfType<CheckpointSystem>();
        level = 5;
        speed = 10;

        xp = 145031.05f;
        health = 48.5f;

        pos = new Vector2(25.6f, 420.69f);

        t_system.AddToIntList("Level", level);
        t_system.AddToIntList("Speed", speed);
        t_system.AddToFloatList("Xp", xp);
        t_system.AddToFloatList("Health", health);
        t_system.AddToVector2List("PLayer Position", pos);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            t_system.SaveDataToFile();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            t_system.LoadData();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            level = t_system.info.intList.data[0];
            speed = t_system.info.intList.data[1];
            xp = t_system.info.floatList.data[0];
            health = t_system.info.floatList.data[1];
            pos = t_system.info.vector2List.data[0];
        }
    }
}
