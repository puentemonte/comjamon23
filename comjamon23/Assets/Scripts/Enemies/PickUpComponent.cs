using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComponent : MonoBehaviour
{
    #region parameters
    private float _speed = 4f;
    private float deadZone;
    private bool pick = false;
    #endregion

    #region properties
    private Transform _myTransform;
    private SoundPlayerManager _soundPlayerManager;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovementController>() != null)
        {
            _soundPlayerManager.EligeAudioP(0, 0.2f);
            GameManager.Instance.bugSolved();
            pick = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.7f);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _soundPlayerManager = GetComponent<SoundPlayerManager>();
        _myTransform = transform;
        deadZone = -Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pick)
        {
            _myTransform.Translate(new Vector2(0, -_speed * Time.deltaTime));
            if (_myTransform.position.y < deadZone)
                Destroy(gameObject);
        }      
    }
}
