using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private float deadZone;

    private Transform _myTranform;

    // Start is called before the first frame update
    void Start()
    {
        _myTranform = gameObject.GetComponent<Transform>();
        deadZone = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        _myTranform.Translate(new Vector2(0, _speed * Time.deltaTime));
        if (_myTranform.position.y > deadZone)
            Destroy(gameObject);       
    }
}
