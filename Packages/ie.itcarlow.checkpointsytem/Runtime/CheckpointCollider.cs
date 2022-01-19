using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollider : MonoBehaviour
{
    float checkpointHitTimer = 10.0f;
    public float currentCheckpointTime = 10.0f;
    public bool savePossible = true;
    public CheckpointSystem t_checkpointSystem;

    void Awake()
    {
        if (FindObjectOfType<CheckpointSystem>() == null)
        {
            t_checkpointSystem = new CheckpointSystem();
        }
        else
        {
            t_checkpointSystem = FindObjectOfType<CheckpointSystem>();
        }
    }

    void Update()
    {
        if(!savePossible)
        {
            if(currentCheckpointTime > 0.0f)
            {
                currentCheckpointTime -= Time.deltaTime;
            }
            else
            {
                currentCheckpointTime = checkpointHitTimer;
                savePossible = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            savePossible = false;
            if (t_checkpointSystem != null)
            {
                t_checkpointSystem.SaveDataToFile();
            }
            else
            {
                t_checkpointSystem = new CheckpointSystem();
                t_checkpointSystem.Awake();
                t_checkpointSystem.SaveDataToFile();
            }
        }
    }
}
