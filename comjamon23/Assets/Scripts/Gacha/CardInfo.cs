using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCard", menuName = "Character")]
public class CardInfo : ScriptableObject
{
    public Sprite image;
    public string name;
}
