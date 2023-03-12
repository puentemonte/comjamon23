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

    private SoundPlayerManager _soundPlayerManager;

    private void Start()
    {
        _soundPlayerManager = GetComponent<SoundPlayerManager>();
    }

    public void Gacha()
    {
        _soundPlayerManager.EligeAudioP(0, 0.3f);

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
        Personaje();
        
    }
    public CardInfo Reward(string rarity)
    {
        GachaRate gr = Array.Find(gacha, rt => rt.rarity == rarity);
        CardInfo[] reward = gr.reward;

        int rnd = UnityEngine.Random.Range(0, 4);
        return reward[rnd];
    }
    public void Personaje()
    {
        if (card.card.name == "Cleon")
        {
            GameManager.Instance.DesbloqueaPersonaje(0);
        }
        else if(card.card.name == "Guille")
        {
            GameManager.Instance.DesbloqueaPersonaje(1);
        }
        else if (card.card.name == "Pedro Pablo otra vez?")
        {
            GameManager.Instance.DesbloqueaPersonaje(2);
        }
        else if (card.card.name == "Pedro Pablo")
        {
            GameManager.Instance.DesbloqueaPersonaje(3);
        }
        else if (card.card.name == "Cleon Lemur")
        {
            GameManager.Instance.DesbloqueaPersonaje(4);
        }
        else if (card.card.name == "Guille Ackerman")
        {
            GameManager.Instance.DesbloqueaPersonaje(5);
        }
        else if (card.card.name == "Marco Antonio Pen")
        {
            GameManager.Instance.DesbloqueaPersonaje(6);
        }
        else if (card.card.name == "Pedro Pablo WA")
        {
            GameManager.Instance.DesbloqueaPersonaje(7);
        }
    }
}
