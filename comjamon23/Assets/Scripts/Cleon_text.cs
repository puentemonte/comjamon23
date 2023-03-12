using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleon_text : MonoBehaviour
{
    [SerializeField]
    private GameObject textBox;
    bool endConv = false;
    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && endConv)
            GameManager.Instance.changeScene("Juez");
        if (Input.GetKeyDown(KeyCode.Space) && i < transform.childCount)
        {
            textBox.SetActive(true);
            transform.GetChild(i - 1).gameObject.SetActive(false);
            transform.GetChild(i).gameObject.SetActive(true);
            i++;
            if (i >= transform.childCount) endConv = true;
        }
    }
}
