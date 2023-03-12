using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        Instantiate(PlayerStorage.playerPrefab, new Vector3(0,0,0), new Quaternion(0,0,0,0));
    }
}
