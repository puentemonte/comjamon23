using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovementController : MonoBehaviour
{
    #region parameters
    private float cont = 0;
    private float _speed = 0.05f;
    private float _elapsedTime = 0f;
    private float _duration = 0.1f;
    #endregion

    #region properties
    Vector3 newPos;
    Transform _myTransform;
    #endregion

    #region references

    #endregion

    #region methods

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _duration)
        {
            cont += 0.5f;
            newPos = new Vector3(2*Mathf.Sin(cont), -_speed, 0);
            _myTransform.Translate(newPos);
            _elapsedTime = 0;
        }     
    }
}
