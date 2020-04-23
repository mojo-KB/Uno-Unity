using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAPlay : MonoBehaviour
{
    private UnoCardsSet deck;
    private SpriteRenderer playingDeck;
    Sprite[] cardSprites;

    // Start is called before the first frame update
    void Start()
    {
        cardSprites = Resources.LoadAll<Sprite>("Sprites/Cards");
        deck = GameObject.Find("Deck").GetComponent<UnoCardsSet>();
        playingDeck = GameObject.Find("PlayingDeck").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deck.state == GameState.IATURN)
        {
            PlayCard();
        }
        LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
    }

    private void PlayCard()
    {
        bool pick = true;
        Debug.Log("IA Turn:");
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            string[] name = gameObject.transform.GetChild(i).name.Split(" ".ToCharArray());
            Debug.Log(name[2]);
            if (playingDeck.sprite.name.Contains(name[2])) {
                foreach (Sprite sprite in cardSprites)
                {
                    if (sprite.name.Contains(name[2]) && sprite.name.Contains(name[1]))
                    {
                        playingDeck.sprite = sprite;
                    }       
                }
                Destroy(gameObject.transform.GetChild(i).gameObject);
                pick = false;
                break;
            }
        }
        if (pick)
        {
            deck.GiveIACard();
        }
        deck.state = GameState.PLAYERTURN;
    }
}
