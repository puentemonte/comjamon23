using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    #region references
    [SerializeField] GameObject[] prefabs;
    #endregion
    #region methods
    public void Select(int index)
    {
        if (GameManager.Instance.Personajes[index] == true)
        {
            PlayerStorage.playerPrefab = this.prefabs[index];
        }
    }
    #endregion
    void Start()
    {
        this.Select(0);
    }

}
