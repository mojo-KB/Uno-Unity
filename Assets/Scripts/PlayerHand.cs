using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHand : MonoBehaviour
{
    List<UnoCards> hand = new List<UnoCards>();
    List<UnoCards> set;

    bool loading = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadHand();
    }

    // Update is called once per frame
    void Update()
    {
        if(hand.Count == 0 && loading)
        {
            LoadHand();
            loading = false;
        }


    }
    
    void LoadHand()
    {
        set = GameObject.FindWithTag("Deck").GetComponent<UnoCardsSet>().cardsSet;
        hand = set.Take(7).ToList();
        Sprite[] cardSprites;
        int x = -5;
        int y = -4;

        cardSprites = Resources.LoadAll<Sprite>("Sprites/Cards");
        foreach (var card in hand)
        {
            foreach (Sprite sprite in cardSprites)
            {
                if (sprite.name.Contains(card.color.ToString()) && sprite.name.Contains(card.value.ToString()))
                {
                    Vector3 newpos = new Vector3(x, y, 0);
                    GameObject go = new GameObject("Card " + card.value.ToString() + " " + card.color.ToString());
                    go.AddComponent<Move>();
                    go.AddComponent<BoxCollider2D>();
                    SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                    renderer.sprite = sprite;
                    renderer.transform.position = newpos;
                    x += 1;
                }
            }
        }
    }
}
