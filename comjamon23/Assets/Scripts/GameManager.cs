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
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private bool[] _personajes = new bool[] { false, false, false, false, false, false, false, false };
    public bool[] Personajes
    {
        get {return _personajes; }
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

    public void DesbloqueaPersonaje(int pos)
    {
        _personajes[pos] = true;
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
