using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    #region parameters
    private float _elapsedTime = 0f;
    private float _duration = 1f;
    Camera camera;
    float halfHeight;
    float halfWidth;
    float horizontalMin;
    float horizontalMax;
    float verticalMin;
    float verticalMax;
    #endregion

    #region properties
    [SerializeField]
    private GameObject _simpleEnemy;
    #endregion

    #region references

    #endregion

    #region methods

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
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
            Vector3 v = new Vector3(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMax, verticalMax - verticalMax/5), 0);
            Instantiate(_simpleEnemy, v, new Quaternion(0,0,0,0));
            _elapsedTime = 0;
        }
    }
}
