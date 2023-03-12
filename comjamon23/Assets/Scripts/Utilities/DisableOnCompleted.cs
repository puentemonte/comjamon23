using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnCompleted : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.levelStatus())
        {
            gameObject.SetActive(false);
        }
    }
}
