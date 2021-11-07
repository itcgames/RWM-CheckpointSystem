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

        t_system.AddGameData("Game Level", gameLevel);

        t_system.AddGameData("Game Time Left", timeLeft);

        t_system.AddGameData("Game Difficulty", difficulty);

        t_system.SaveData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
