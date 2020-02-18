using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    List<UnoCards> hand = new List<UnoCards>();
    List<UnoCards> set;

    bool loading = true;

    // Start is called before the first frame update
    void Start()
    {
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
        set.RemoveRange(0, 6);

        Sprite[] cardSprites;


        cardSprites = Resources.LoadAll<Sprite>("Sprites/Cards");
        foreach (var card in hand)
        {
            foreach (Sprite sprite in cardSprites)
            {
                if (sprite.name.Contains(card.color.ToString()) && sprite.name.Contains(card.value.ToString()))
                {
                    GameObject go = new GameObject("Card " + card.value.ToString() + " " + card.color.ToString());
                    go.transform.SetParent(GameObject.Find("PlayerHand").transform, false);
                    go.AddComponent<LayoutElement>();
                    go.AddComponent<Move>();
                    go.AddComponent<BoxCollider2D>();
                    SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                    renderer.sprite = sprite;
                    renderer.transform.localScale = new Vector3(1.5f, 1.5f, 1);

                    LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
                }
            }
        }
    }
}
