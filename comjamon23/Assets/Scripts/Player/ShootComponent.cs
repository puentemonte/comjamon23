using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    private float _elapsedTime = 0f;
    private float _duration = 0.4f;

    bool fire = false;
    [SerializeField]
    private Transform _myShootController;
    [SerializeField]
    private GameObject _bullet;

    private SoundPlayerManager _soundPlayerManager;

    public void setFire(bool nFire)
    {
        fire = nFire;
    }

    public void Shoot() {
        _soundPlayerManager.EligeAudioP(0, 0.03f);
        Instantiate(_bullet, _myShootController.position, _myShootController.rotation);
    }

    private void Start()
    {
        _soundPlayerManager = GetComponent<SoundPlayerManager>();
    }

    void Update() {
        _elapsedTime += Time.deltaTime;
        if (fire && (_elapsedTime > _duration))
        {
            Shoot();
            _elapsedTime = 0;
        }
    }
}