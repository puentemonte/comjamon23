using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCollisionComponent : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private GameObject pickUp;
    #endregion

    #region properties

    #endregion

    #region references
    private SoundEnemiesManager _soundEnemyManager;
    #endregion

    #region methods

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _soundEnemyManager = GetComponent<SoundEnemiesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {      
        if (other.GetComponent<BulletComponent>() != null)
        {
            _soundEnemyManager.EligeAudioP(0, 0.8f);
            int r = Random.Range(0, 10);
            if (r < 5)
            {
                Instantiate(pickUp, transform.position, new Quaternion(0, 0, 0, 0));
            }
        }
        if (other.GetComponent<PlayerMovementController>() != null)
        {
            _soundEnemyManager.EligeAudioP(1, 0.4f);
            GameManager.Instance.GameOver();
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 0.5f);
        Destroy(other.gameObject, 0.5f);      
    }
}
