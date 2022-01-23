using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class CheckpointSystemTest
{

    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void Teardown()
    {
    }

    [UnityTest]
    public IEnumerator CheckPlayerInfo()
    {
        CheckpointSystem t_system = new CheckpointSystem();
        t_system.Awake();
        int level = 5;
        int speed = 10;

        float xp = 145031.05f;
        float health = 48.5f;

        Vector2 pos = new Vector2(25.6f, 420.69f);

        t_system.AddToIntList("Player Level", level);
        t_system.AddToIntList("Player Speed", speed);

        t_system.AddToFloatList("Player Xp", xp);
        t_system.AddToFloatList("Player Health", health);

        t_system.AddToVector2List("Player Position", pos);

        t_system.SaveDataToFile();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual("Player Level", t_system.info.intList.name[0]);
        Assert.AreEqual(level, t_system.info.intList.data[0]);
        Assert.AreEqual("Player Speed", t_system.info.intList.name[1]);
        Assert.AreEqual(speed, t_system.info.intList.data[1]);

        Assert.AreEqual("Player Xp", t_system.info.floatList.name[0]);
        Assert.AreEqual(xp, t_system.info.floatList.data[0]);
        Assert.AreEqual("Player Health", t_system.info.floatList.name[1]);
        Assert.AreEqual(health, t_system.info.floatList.data[1]);

        Assert.AreEqual("Player Position", t_system.info.vector2List.name[0]);
        Assert.AreEqual(pos, t_system.info.vector2List.data[0]);

    }

    [UnityTest]
    public IEnumerator FileExists()
    {
        CheckpointSystem t_system = new CheckpointSystem();
        t_system.Awake();
        t_system.SaveDataToFile();
        string file = Application.dataPath + "playerData.txt";
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(file, t_system.fileLoc());
    }

    [UnityTest]
    public IEnumerator CheckGameInfo()
    {
        CheckpointSystem t_system = new CheckpointSystem();
        t_system.Awake();
        int gameLevel = 15;

        float timeLeft = 14.01f;

        string difficulty = "Medium";


        t_system.AddToIntList("Game Level", gameLevel);

        t_system.AddToFloatList("Game Time Left", timeLeft);

        t_system.AddToStringList("Game Difficulty", difficulty);

        t_system.SaveDataToFile();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual("Game Level", t_system.info.intList.name[0]);
        Assert.AreEqual(gameLevel, t_system.info.intList.data[0]);

        Assert.AreEqual("Game Time Left", t_system.info.floatList.name[0]);
        Assert.AreEqual(timeLeft, t_system.info.floatList.data[0]);

        Assert.AreEqual("Game Difficulty", t_system.info.stringList.name[0]);
        Assert.AreEqual(difficulty, t_system.info.stringList.data[0]);

    }

    [UnityTest]
    public IEnumerator ReadInfoFromFile()
    {
        CheckpointSystem t_system = new CheckpointSystem();
        t_system.Awake();
        int gameLevel = 15;

        float timeLeft = 14.01f;

        string difficulty = "Medium";

        int level = 5;
        int speed = 10;

        float xp = 145031.05f;
        float health = 48.5f;

        Vector2 pos = new Vector2(25.6f, 420.69f);

        t_system.AddToIntList("Player Level", level);
        t_system.AddToIntList("Player Speed", speed);
        t_system.AddToFloatList("Player Xp", xp);
        t_system.AddToFloatList("Player Health", health);
        t_system.AddToVector2List("Player Position", pos);
        t_system.AddToIntList("Game Level", gameLevel);
        t_system.AddToFloatList("Game Time Left", timeLeft);
        t_system.AddToStringList("Game Difficulty", difficulty);
        t_system.SaveDataToFile();

        yield return new WaitForSeconds(0.1f);

        t_system.LoadData();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(gameLevel, t_system.info.intList.data[2]);
        Assert.AreEqual(timeLeft, t_system.info.floatList.data[2]);
        Assert.AreEqual(difficulty, t_system.info.stringList.data[0]);
        Assert.AreEqual(level, t_system.info.intList.data[0]);
        Assert.AreEqual(speed, t_system.info.intList.data[1]);
        Assert.AreEqual(xp, t_system.info.floatList.data[0]);
        Assert.AreEqual(health, t_system.info.floatList.data[1]);
        Assert.AreEqual(pos, t_system.info.vector2List.data[0]);

    }

    [UnityTest]
    public IEnumerator AssignInfo()
    {
        CheckpointSystem t_system = new CheckpointSystem();
        t_system.Awake();
        int gameLevel = 15;
        float timeLeft = 14.01f;
        string difficulty = "Medium";
        int level = 5;
        int speed = 10;
        float xp = 145031.05f;
        float health = 48.5f;
        Vector2 pos = new Vector2(25.6f, 420.69f);

        t_system.LoadData();

        yield return new WaitForSeconds(0.1f);

        int actual_gameLevel = t_system.info.intList.data[2];
        float actual_timeLeft = t_system.info.floatList.data[2];
        string actual_difficulty = t_system.info.stringList.data[0];
        int actual_level = t_system.info.intList.data[0];
        int actual_speed = t_system.info.intList.data[1];
        float actual_xp = t_system.info.floatList.data[0];
        float actual_health = t_system.info.floatList.data[1];
        Vector2 actual_pos = t_system.info.vector2List.data[0];

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(gameLevel, actual_gameLevel);
        Assert.AreEqual(timeLeft, actual_timeLeft);
        Assert.AreEqual(difficulty, actual_difficulty);
        Assert.AreEqual(level, actual_level);
        Assert.AreEqual(speed, actual_speed);
        Assert.AreEqual(xp, actual_xp);
        Assert.AreEqual(health, actual_health);
        Assert.AreEqual(pos, actual_pos);

    }

    [UnityTest]
    public IEnumerator PlayerEntersSaveArea()
    {
        CheckpointSystem t_system = new CheckpointSystem();
        t_system.Awake();

        GameObject m_worldCheckpoint = Resources.Load<GameObject>("WorldCheckpoint");

        Assert.AreEqual(true, m_worldCheckpoint.GetComponent<CheckpointCollider>().savePossible);

        GameObject m_testPlayer = Resources.Load<GameObject>("TestPlayer");

        yield return new WaitForSeconds(0.1f);
        m_testPlayer.transform.position = new Vector3(0, 0, 0);

        m_worldCheckpoint.GetComponent<CheckpointCollider>().OnTriggerEnter2D(m_testPlayer.GetComponent<Collider2D>());

        Assert.AreEqual(false, m_worldCheckpoint.GetComponent<CheckpointCollider>().savePossible);
    }

    [UnityTest]
    public IEnumerator TimerResets()
    {
        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(false, GameObject.FindObjectOfType<CheckpointCollider>().savePossible);

        yield return new WaitForSeconds(10.0f);

        Assert.AreEqual(true, GameObject.FindObjectOfType<CheckpointCollider>().savePossible);
    }


    [UnityTest]
    public IEnumerator WorldCheckpointSaveActuallyWorks()
    {
        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(0.1f);

        CheckpointSystem t_system = GameObject.FindObjectOfType<CheckpointSystem>();

        int gameLevel = 15;
        float timeLeft = 14.01f;
        string difficulty = "Medium";
        int level = 5;
        int speed = 10;
        float xp = 145031.05f;
        float health = 48.5f;
        Vector2 pos = new Vector2(25.6f, 420.69f);

        yield return new WaitForSeconds(0.1f);

        t_system.LoadData();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(gameLevel, t_system.info.intList.data[2]);
        Assert.AreEqual(timeLeft, t_system.info.floatList.data[2]);
        Assert.AreEqual(difficulty, t_system.info.stringList.data[0]);
        Assert.AreEqual(level, t_system.info.intList.data[0]);
        Assert.AreEqual(speed, t_system.info.intList.data[1]);
        Assert.AreEqual(xp, t_system.info.floatList.data[0]);
        Assert.AreEqual(health, t_system.info.floatList.data[1]);
        Assert.AreEqual(pos, t_system.info.vector2List.data[0]);
    }

    [UnityTest]
    public IEnumerator SaveTheGameAfterXmin()
    {
        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(false, GameObject.FindObjectOfType<CheckpointSystem>().autoSave);

        yield return new WaitForSecondsRealtime(20.0f);
        Assert.AreEqual(2, GameObject.FindObjectOfType<CheckpointSystem>().timesSaved);
    }

    [UnityTest]
    public IEnumerator AutoSaveInfoIsCorrect()
    {
        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(0.1f);

        CheckpointSystem t_system = GameObject.FindObjectOfType<CheckpointSystem>();

        int gameLevel = 15;
        float timeLeft = 14.01f;
        string difficulty = "Medium";
        int level = 5;
        int speed = 10;
        float xp = 145031.05f;
        float health = 48.5f;
        Vector2 pos = new Vector2(25.6f, 420.69f);

        yield return new WaitForSeconds(10.0f);

        t_system.LoadData();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(gameLevel, t_system.info.intList.data[2]);
        Assert.AreEqual(timeLeft, t_system.info.floatList.data[2]);
        Assert.AreEqual(difficulty, t_system.info.stringList.data[0]);
        Assert.AreEqual(level, t_system.info.intList.data[0]);
        Assert.AreEqual(speed, t_system.info.intList.data[1]);
        Assert.AreEqual(xp, t_system.info.floatList.data[0]);
        Assert.AreEqual(health, t_system.info.floatList.data[1]);
        Assert.AreEqual(pos, t_system.info.vector2List.data[0]);
    }

    [UnityTest]
    public IEnumerator SaveGameAfterTasks()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(0.1f);
        CheckpointSystem t_system = GameObject.FindObjectOfType<CheckpointSystem>();

        yield return new WaitForSeconds(0.1f);
        t_system.TaskSaveInterval(2);
        t_system.MissionTaskNum(7);
        t_system.MissionInProgress(true);
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(4, t_system.missionTimeSaved);
    }

    [UnityTest]
    public IEnumerator MissionSaveInfoIsCorrect()
    {
        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(0.1f);

        CheckpointSystem t_system = GameObject.FindObjectOfType<CheckpointSystem>();

        int gameLevel = 15;
        float timeLeft = 14.01f;
        string difficulty = "Medium";
        int level = 5;
        int speed = 10;
        float xp = 145031.05f;
        float health = 48.5f;
        Vector2 pos = new Vector2(25.6f, 420.69f);

        yield return new WaitForSeconds(0.1f);
        t_system.TaskSaveInterval(2);
        t_system.MissionTaskNum(7);
        t_system.MissionInProgress(true);
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(4, t_system.missionTimeSaved);

        yield return new WaitForSeconds(0.1f);

        t_system.LoadData();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(gameLevel, t_system.info.intList.data[2]);
        Assert.AreEqual(timeLeft, t_system.info.floatList.data[2]);
        Assert.AreEqual(difficulty, t_system.info.stringList.data[0]);
        Assert.AreEqual(level, t_system.info.intList.data[0]);
        Assert.AreEqual(speed, t_system.info.intList.data[1]);
        Assert.AreEqual(xp, t_system.info.floatList.data[0]);
        Assert.AreEqual(health, t_system.info.floatList.data[1]);
        Assert.AreEqual(pos, t_system.info.vector2List.data[0]);
    }

    [UnityTest]
    public IEnumerator MissionTextWorks()
    {
        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(0.1f);

        CheckpointSystem t_system = GameObject.FindObjectOfType<CheckpointSystem>();

        yield return new WaitForSeconds(0.1f);
        t_system.SetMissionText("Mission Two");
        t_system.TaskSaveInterval(4);
        t_system.MissionTaskNum(16);
        t_system.MissionInProgress(true);

        Assert.AreEqual("Mission Two Tasks till next save: 4", t_system.missionText.text);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual("Mission Two Tasks till next save: 3", t_system.missionText.text);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        t_system.IncrementCurrentTaskNum();
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual("Mission Two Tasks till next save: 1", t_system.missionText.text);
    }

    [UnityTest]
    public IEnumerator CheckpointTextWorks()
    {
        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(0.1f);

        CheckpointCollider t_system = GameObject.FindObjectOfType<CheckpointCollider>();
        t_system.playerPos.transform.position = new Vector3(3.35f, 0, 0);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual("3.35 m", t_system.distanceText.text);

        t_system.playerPos.transform.position = new Vector3(50, 0, 00);

        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(false, t_system.distanceText.IsActive());
    }
}