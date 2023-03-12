using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region parameters
    int solved;
    bool completed = false;
    bool gameOver = false;
    bool timelimit = false;
    private float _elapsedTime = 0f;
    private float _duration = 10;
    private float enemiesKilled;
    private int actLevel;
    #endregion

    #region properties
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private bool[] _personajes = new bool[] { true, false, false, false, false, false, false, false };
    public bool[] Personajes
    {
        get {return _personajes; }
    }
    #endregion

    #region references
    #endregion

    #region methods
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void solvedBugs()
    {
        solved++;
    }

    public void DesbloqueaPersonaje(int pos)
    {
        _personajes[pos] = true;
    }

    public void levelCompleted()
    {
        completed = true;
    }

    public bool levelStatus()
    {
        return completed;
    }

    public void setLevelStatus(bool _completed)
    {
        completed = _completed;
    }

    public bool getGameOver()
    {
        return gameOver;
    }

    public void setGameOver(bool gOver)
    {
        gameOver = gOver;
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public float numBugsSolved()
    {
        return enemiesKilled;
    }

    public void bugSolved()
    {
        enemiesKilled++;
    }

    public bool getTimeLimit()
    {
        return timelimit;
    }

    public void setTimeLimit(bool tLimit)
    {
        timelimit = tLimit;
    }

    public int level()
    {
        return actLevel;
    }

    public void setLevelFib()
    {
        actLevel = 0;
    }

    public void setLevelBubble()
    {
        actLevel = 1;
    }
    #endregion

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver || completed)
        {
            _elapsedTime = 0;
            enemiesKilled = 0;
        }
        if (SceneManager.GetActiveScene().name == "SI_Scene")
        {
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > _duration)
            {
                GameOver();
                timelimit = true;
                _elapsedTime = 0;
            }
        }
    }
}
