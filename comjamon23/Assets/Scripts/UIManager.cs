using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region References
    [SerializeField]
    private GameObject[] _personajesBlock;
    [SerializeField]
    private bool[] _personajes;
    #endregion

    #region Methods
    void Desbloquea(GameObject[] _personajesBlock)
    {
        for(int i=0; i<_personajesBlock.Length; i++)
        {
            if (_personajes[i]==true) _personajesBlock[i].SetActive(false);
            else _personajesBlock[i].SetActive(true);
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _personajes = new bool[] { true, false, false, false, false, false, false, false };
    }

    // Update is called once per frame
    void Update()
    {
        Desbloquea(_personajesBlock);
    }
}
