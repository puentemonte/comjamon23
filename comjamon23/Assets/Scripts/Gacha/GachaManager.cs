using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    [SerializeField]
    private GachaRate[] gacha;
    [SerializeField]
    private Transform parent, pos;
    [SerializeField] private GameObject characterCardGO;
    GameObject characterCard;
    Card card;

    public void Gacha()
    {
        characterCard = Instantiate(characterCardGO, pos.position, Quaternion.identity) as GameObject;
        characterCard.transform.SetParent(parent);
        characterCard.transform.localScale = new Vector3(1,1,1);
        card = characterCard.GetComponent<Card>();

        int rnd = UnityEngine.Random.Range(1, 101);
        string r;
        if(rnd <= gacha[0].rate) // normales
        {
            r = gacha[0].rarity;
        }
        else // legendarios
        {
            r = gacha[1].rarity;
        }
        card.card = Reward(r);
    }
    public CardInfo Reward(string rarity)
    {
        GachaRate gr = Array.Find(gacha, rt => rt.rarity == rarity);
        CardInfo[] reward = gr.reward;

        int rnd = UnityEngine.Random.Range(0, 4);
        Debug.Log(reward[rnd]);
        return reward[rnd];
    }
}
