using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    #region parameters
    private float _elapsedTime = 0f;
    private float _duration = 5f;
    float halfHeight;
    float halfWidth;
    float horizontalMin;
    float horizontalMax;
    float verticalMin;
    float verticalMax;
    int offset = 10;
    bool completed = false;
    #endregion

    #region properties
    [SerializeField]
    private GameObject[] _enemies;
    [SerializeField]
    private GameObject submited;
    [SerializeField]
    private GameObject wronganswer;
    [SerializeField]
    private GameObject timelimit;
    #endregion

    #region references

    #endregion

    #region methods

    public GameObject getWrongAnswer()
    {
        return wronganswer;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;

        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;

        verticalMin = -halfHeight;
        verticalMax = halfHeight;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _duration)
        {
            Vector3 v = new Vector3(Random.Range(horizontalMin + offset, horizontalMax - offset), Random.Range(verticalMax, verticalMax - verticalMax/5), 0);
            Instantiate(_enemies[Random.Range(0, _enemies.Length)], v, new Quaternion(0,0,0,0));
            _elapsedTime = 0;
        }
        if(GameManager.Instance.numBugsSolved() > 10)
        {
            Time.timeScale = 0;
            GameManager.Instance.levelCompleted();
            Instantiate(submited, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        }
        if (GameManager.Instance.getGameOver())
        {
            Time.timeScale = 0;

            if (GameManager.Instance.getTimeLimit())
                Instantiate(timelimit, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            else
                Instantiate(wronganswer, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
        if(GameManager.Instance.levelStatus() && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.setLevelStatus(false);
            if(GameManager.Instance.level() == 0)
                GameManager.Instance.changeScene("PuzzleFib");
            else if(GameManager.Instance.level() == 1)
                GameManager.Instance.changeScene("PuzzleBubble");
            Time.timeScale = 1;
        }
        else if(GameManager.Instance.getGameOver() && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.setGameOver(false);
            GameManager.Instance.setTimeLimit(false);
            GameManager.Instance.setLevelStatus(false);
            GameManager.Instance.changeScene("Juez");
            Time.timeScale = 1;
        }
    }
}
