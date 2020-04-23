using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    public GameObject selectedCard;
    public GameObject selectColor;
    public UnoCardsSet deck;

    private void Start()
    {
        selectedCard = gameObject;
        deck = GameObject.Find("Deck").GetComponent<UnoCardsSet>();
        selectColor = deck.selectColor;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnMouseDown()
    {
        if(deck.state == GameState.PLAYERTURN) {
            string[] name = gameObject.name.Split(" ".ToCharArray());
            for(int i = 0; i < name.Length; i++)
            {
                if (GameObject.Find("PlayingDeck").GetComponent<SpriteRenderer>().sprite.name.Contains(name[i])){
                    GameObject.Find("PlayingDeck").GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    GameObject.Find("PlayingDeck").GetComponent<SpriteRenderer>().color = Color.white;
                    Destroy(gameObject);
                }
                else if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("Black"))
                {
                    GameObject.Find("PlayingDeck").GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    GameObject.Find("PlayingDeck").GetComponent<SpriteRenderer>().color = Color.white;
                    Destroy(gameObject);

                    selectColor.SetActive(true);
                }
            }
            deck.state = GameState.IATURN;
        }
    }

}
