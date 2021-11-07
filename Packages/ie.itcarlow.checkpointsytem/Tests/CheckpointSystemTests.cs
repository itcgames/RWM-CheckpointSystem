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

        t_system.AddPlayerData("Player Level", level);
        t_system.AddPlayerData("Player Speed", speed);

        t_system.AddPlayerData("Player Xp", xp);
        t_system.AddPlayerData("Player Health", health);

        t_system.AddPlayerData("Player Position", pos);
        t_system.SaveData();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual("Player Level", t_system.playerDataInt[0].name);
        Assert.AreEqual(level, t_system.playerDataInt[0].data);
        Assert.AreEqual("Player Speed", t_system.playerDataInt[1].name);
        Assert.AreEqual(speed, t_system.playerDataInt[1].data);

        Assert.AreEqual("Player Xp", t_system.playerDataFloat[0].name);
        Assert.AreEqual(xp, t_system.playerDataFloat[0].data);
        Assert.AreEqual("Player Health", t_system.playerDataFloat[1].name);
        Assert.AreEqual(health, t_system.playerDataFloat[1].data);

        Assert.AreEqual("Player Position", t_system.playerDataVec2[0].name);
        Assert.AreEqual(pos, t_system.playerDataVec2[0].data);

    }

    [UnityTest]
    public IEnumerator FileExists()
    {
        CheckpointSystem t_system = new CheckpointSystem();
        t_system.Awake();
        t_system.SaveData();
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


        t_system.AddGameData("Game Level", gameLevel);

        t_system.AddGameData("Game Time Left", timeLeft);

        t_system.AddGameData("Game Difficulty", difficulty);

        t_system.SaveData();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual("Game Level", t_system.gameDataInt[0].name);
        Assert.AreEqual(gameLevel, t_system.gameDataInt[0].data);

        Assert.AreEqual("Game Time Left", t_system.gameDataFloat[0].name);
        Assert.AreEqual(timeLeft, t_system.gameDataFloat[0].data);

        Assert.AreEqual("Game Difficulty", t_system.gameDataString[0].name);
        Assert.AreEqual(difficulty, t_system.gameDataString[0].data);

    }
}