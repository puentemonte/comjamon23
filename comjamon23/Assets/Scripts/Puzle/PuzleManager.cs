using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzleManager : MonoBehaviour
{
    [SerializeField]
    public bool[] corrects;
    [SerializeField]
    private GameObject GREEN;
    [SerializeField]
    private GameObject RED;
    private bool c = false;
    private bool w = false;

    public bool correct()
    {
        for(int i = 0; i < corrects.Length; i++)
        {
            if (!corrects[i]) return false;
        }
        return true;
    }

    public void submit()
    {
        if (correct())
        {
            if (!c)
            {
                GameManager.Instance.problemSolved();
                Instantiate(GREEN, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                GREEN.transform.localScale = new Vector3(25, 25, 0);
                Time.timeScale = 0;
                c = true;
            }        
        }
        else
        {
            if (!w)
            {
                Instantiate(RED, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                RED.transform.localScale = new Vector3(25, 25, 0);
                Time.timeScale = 0;
                w = true;
            }       
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RED.transform.localScale = new Vector3(25, 25, 0);
        GREEN.transform.localScale = new Vector3(25, 25, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (c && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            GameManager.Instance.changeScene("Juez");
        }
        else if (w && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;

            GameManager.Instance.changeScene("Juez");
        }
    }
}
