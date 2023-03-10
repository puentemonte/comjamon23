using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private Transform _myShootController;
    [SerializeField]
    private GameObject _bullet;
    

    public void Shoot() {
        Instantiate(_bullet, _myShootController.position, _myShootController.rotation);
    }

    void Update() {
    }
}