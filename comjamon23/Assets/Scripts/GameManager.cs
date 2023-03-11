using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region parameters
    int solved;
    #endregion

    #region properties
    static private GameManager _instance;

    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    #region references
    [SerializeField]
    private EnemiesManager enemiesManager;
    #endregion

    #region methods
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public EnemiesManager getEnemiesManager()
    {
        return enemiesManager;
    }


    public void solvedBugs()
    {
        solved++;
    }
    #endregion  

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
