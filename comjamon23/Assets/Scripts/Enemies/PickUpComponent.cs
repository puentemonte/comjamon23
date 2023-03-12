using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComponent : MonoBehaviour
{
    #region parameters
    private float _speed = 4f;
    private float deadZone;
    #endregion

    #region properties
    private Transform _myTransform;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovementController>() != null)
        {
            GameManager.Instance.bugSolved();
            Destroy(gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        _myTransform = transform;
        deadZone = -Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.Translate(new Vector2(0, - _speed * Time.deltaTime));
        if (_myTransform.position.y < deadZone)
            Destroy(gameObject);
    }
}
