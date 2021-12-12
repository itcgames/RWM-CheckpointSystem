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
        
    }
}
