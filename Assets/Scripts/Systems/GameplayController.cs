using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    [SerializeField] private FloatEvent newHighscoreEvent;
    [SerializeField] private UnityEvent countdownEvent;
    [SerializeField] private UnityEvent gameEndEvent;
    [SerializeField] private float startingCountdownTime = 3f;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 startPos;
    private TankController playerTank;
    List<TankController> aiList;
    private DifficultySO difficulty;
    private int points;
    private float startTime;
    private int mapId;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Init();
    }

    public void Init()
    {
        GameInfo game = DataHolder.instance.gameInfo;
        difficulty = game.difficulty;
        mapId = game.mapId;

        InitDropSystem(game.mapInfo.obstacles);
        InitPlayer(game.playerType, difficulty);

        startTime = Time.time;

        points = 0;

        StartCoroutine(StartingCountdown(startingCountdownTime));
    }
    public void SetAiList(List<AiController> aiControllerList)
    {
        aiList = new List<TankController>();
        foreach(AiController ai in aiControllerList)
        {
            aiList.Add(ai.GetTankController());
        }
    }
    IEnumerator StartingCountdown(float time)
    {
        countdownEvent.Invoke();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;
    }
    public void TankKilled(TankController tankKilled)
    {
        if (tankKilled == playerTank) 
        {
            GameEnd(false);
            Destroy(playerTank.transform.parent.gameObject);
            playerTank = null;
            return;
        }
        aiList.Remove(tankKilled);
        tankKilled.Reset();

        points += difficulty.PointsPerKill;

        if (aiList.Count == 0) GameEnd(true);
    }

    void GameEnd(bool win)
    {
        if (win) GameWon();
        else GameOver();
        StartCoroutine(GoToMainMenu());
    }
    void GameWon()
    {
        points += (int)((Time.time - startTime) * difficulty.PointsPerTime);
        SaveHighscore();
#if DEBUG_LOGS
        Debug.Log("WIN");
#endif
    }

    void SaveHighscore()
    {
       if (HighscoreSystem.SetHighscore(mapId, points)) newHighscoreEvent.Invoke(points); 
    }
    void GameOver()
    {
#if DEBUG_LOGS
        Debug.Log("LOSE");
#endif
    }

    IEnumerator GoToMainMenu()
    {
        Time.timeScale = 0.25f;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        CleanMap();
        LoadingSystem.instance.LoadScene("MainMenu");
    }
    void InitPlayer(TankSO tankSO, DifficultySO diffSO)
    {
        PlayerController playerInstance = Instantiate(player, startPos, this.transform.rotation, null).GetComponent<PlayerController>();
        playerInstance.Init(tankSO, diffSO);
        playerTank = playerInstance.GetTankController();
    }
    void InitDropSystem(Vector3[] obstacles)
    {
        BoostDropSystem.instance.Init(obstacles);
    }
    void CleanMap()
    {
        RemoveAllTanks();
    }
    void RemoveAllTanks()
    {
        foreach(TankController tank in aiList)
        {
            tank.Reset();
        }
        if (playerTank != null) 
        {
            Destroy(playerTank.transform.parent.gameObject);
            playerTank = null;
        }
    }
}
