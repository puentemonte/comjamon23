using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCollisionComponent : MonoBehaviour
{
    #region parameters
    
    #endregion

    #region properties
    private PolygonCollider2D _mycol;
    #endregion

    #region references

    #endregion

    #region methods

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _mycol = gameObject.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.getEnemiesManager().bugSolved();
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
