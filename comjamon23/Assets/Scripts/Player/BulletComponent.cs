using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxTimeInterval = 1f;
    private float _elapsedTime;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, _speed * Time.deltaTime));
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime > _maxTimeInterval){
            Destroy(gameObject);
        }
    }
}
