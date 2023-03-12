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

    #endregion

    #region methods

    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BulletComponent>() != null)
        {
            int r = Random.Range(0, 10);
            if (r < 5)
            {
                Instantiate(pickUp, transform.position, new Quaternion(0, 0, 0, 0));
            }
        }
        if (other.GetComponent<PlayerMovementController>() != null)
        {
            GameManager.Instance.GameOver();
        }
        Destroy(gameObject);
        Destroy(other.gameObject);      
    }
}
