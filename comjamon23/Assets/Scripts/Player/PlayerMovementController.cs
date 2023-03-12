using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _speed = 1.0f;

    float halfHeight;
    float verticalMin;
    float verticalMax;
    #endregion

    #region properties
    private Vector3 _movementDirection;
    Transform _myTransform;
    #endregion

    #region references
    private Rigidbody2D _myrb;
    #endregion

    #region methods

    public void SetMovementDirection(Vector3 newMovementDirection)
    {
        _movementDirection = newMovementDirection;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myrb = GetComponent<Rigidbody2D>();

        Camera camera = Camera.main;
        halfHeight = camera.orthographicSize;

        verticalMin = -halfHeight;
        verticalMax = halfHeight;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
        if (_myTransform.position.y + _movementDirection.y < verticalMin || _myTransform.position.y + _movementDirection.y > verticalMax)
            _myrb.velocity = new Vector2(0, 0);
        else
            _myrb.velocity = (_speed * _movementDirection);
        
    }
}
