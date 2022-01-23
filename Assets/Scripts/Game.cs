using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int gameLevel;

    public float timeLeft;

    public string difficulty;

    CheckpointSystem t_system;

    // Start is called before the first frame update
    void Start()
    {
        gameLevel = 15;

        timeLeft = 14.01f;

        difficulty = "Medium";

        t_system = FindObjectOfType<CheckpointSystem>();

        t_system.AddToStringList("Difficulty", difficulty);
        t_system.AddToIntList("Game Level", gameLevel);
        t_system.AddToFloatList("Time Left", timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            gameLevel = t_system.info.intList.data[2];
            timeLeft = t_system.info.floatList.data[2];
            difficulty = t_system.info.stringList.data[0];
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            t_system.SetMissionText("Mission One");
            t_system.TaskSaveInterval(2);
            t_system.MissionTaskNum(7);
            t_system.MissionInProgress(true);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            t_system.SetMissionText("Mission Two");
            t_system.TaskSaveInterval(4);
            t_system.MissionTaskNum(16);
            t_system.MissionInProgress(true);

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            t_system.IncrementCurrentTaskNum();
        }
    }
}
