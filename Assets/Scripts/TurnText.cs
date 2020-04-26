using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnText : MonoBehaviour
{
    public UnoCardsSet deck;
    // Start is called before the first frame update
    void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<UnoCardsSet>();
        if(deck.state == GameState.PLAYERTURN)
        {
            gameObject.GetComponent<TMP_Text>().text = "C'est au tour du joueur";
        }
        else
        {
            gameObject.GetComponent<TMP_Text>().text = "C'est au tour de l'IA";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (deck.state == GameState.PLAYERTURN)
        {
            gameObject.GetComponent<TMP_Text>().text = "C'est au tour du joueur";
        }
        else
        {
            gameObject.GetComponent<TMP_Text>().text = "C'est au tour de l'IA";
        }
    }
}
