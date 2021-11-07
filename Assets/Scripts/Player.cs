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

        t_system.AddPlayerData("Player Level", level);
        t_system.AddPlayerData("Player Speed", speed);

        t_system.AddPlayerData("Player Xp", xp);
        t_system.AddPlayerData("Player Health", health);

        t_system.AddPlayerData("Player Position", pos);

        t_system.SaveData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
