using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    #region parameters
    private float _elapsedTime = 0f;
    private float _duration = 2f;
    float halfHeight;
    float halfWidth;
    float horizontalMin;
    float horizontalMax;
    float verticalMin;
    float verticalMax;
    int offset = 5;
    private float enemiesKilled;
    #endregion

    #region properties
    [SerializeField]
    private GameObject[] _enemies;
    #endregion

    #region references

    #endregion

    #region methods
    public void bugSolved()
    {
        enemiesKilled++;
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
        if(enemiesKilled > 10)
        {
            GameManager.Instance.changeScene("Puzzle");
        }
    }
}
