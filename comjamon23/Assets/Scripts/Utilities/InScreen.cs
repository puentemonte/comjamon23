using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InScreen : MonoBehaviour
{
    #region parameters
    private float screenWidth;
    private float horizontalMin;
    private float horizontalMax;
    #endregion

    #region references
    Transform _myTransform;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        Camera camera = Camera.main;
        screenWidth = camera.aspect * camera.orthographicSize;

        horizontalMin = -screenWidth;
        horizontalMax = screenWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (_myTransform.position.x > horizontalMax)
            _myTransform.position = new Vector3(horizontalMin, _myTransform.position.y, _myTransform.position.z);
        else if(_myTransform.position.x < horizontalMin)
            _myTransform.position = new Vector3(horizontalMax, _myTransform.position.y, _myTransform.position.z);
    }
}
