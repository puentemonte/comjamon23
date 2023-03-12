using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleon_text : MonoBehaviour
{
    [SerializeField]
    private GameObject text;
    bool k = false;
    int i = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && k)
            GameManager.Instance.changeScene("Juez");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            text.SetActive(true);
            k = true;
        }
    }
}
