using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Image img;
    [SerializeField]
    private TextMeshProUGUI name;
    public CardInfo card;
    // Start is called before the first frame update
    void Start()
    {
        if(card != null)
        {
            name.text = card.name;
            img.sprite = card.image;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Start();
    }
}
