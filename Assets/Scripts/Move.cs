using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    public GameObject selectedCard;
    public GameObject selectColor;

    private void Start()
    {
        selectedCard = gameObject;
        selectColor = GameObject.Find("Deck").GetComponent<UnoCardsSet>().selectColor;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnMouseDown()
    {
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
    }

}
