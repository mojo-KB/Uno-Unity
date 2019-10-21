using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoCardsSet : MonoBehaviour
{
    UnoCards unoCards = new UnoCards();
    List<UnoCards> cardsSet = new List<UnoCards>();
    Sprite[] cardSprites;


    // Start is called before the first frame update
    void Start()
    {
        cardSprites = Resources.LoadAll<Sprite>("Sprites/Cards");
        cardsSet = unoCards.createCards();

        foreach(var card in cardsSet)
        {
            foreach (Sprite sprite in cardSprites)
            {
                if (sprite.name.Contains(card.color.ToString()))
                {
                    GameObject go = new GameObject("Card");
                    SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                    renderer.sprite = sprite;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
