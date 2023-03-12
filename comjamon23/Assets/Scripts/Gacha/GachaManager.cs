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
        //if(characterCard == null)
        //{
            characterCard = Instantiate(characterCardGO, pos.position, Quaternion.identity) as GameObject;
            characterCard.transform.SetParent(parent);
            characterCard.transform.localScale = new Vector3(1,1,1);
            card = characterCard.GetComponent<Card>();

            int rnd = UnityEngine.Random.Range(1, 101);
            for(int i=0; i<gacha.Length; i++)
            {
                if(rnd <= gacha[i].rate)
                {
                   card.card = Reward(gacha[i].rarity);
                   return;
                }
            }
       // }
    }
    public CardInfo Reward(string rarity)
    {
        GachaRate gr = Array.Find(gacha, rt => rt.rarity == rarity);
        CardInfo[] reward = gr.reward;

        int rnd = UnityEngine.Random.Range(0, reward.Length);
        Debug.Log(reward[rnd]);
        return reward[rnd];
    }
}
