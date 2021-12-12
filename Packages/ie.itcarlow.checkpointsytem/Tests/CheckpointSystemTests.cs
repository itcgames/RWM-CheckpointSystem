using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.IO;

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
}