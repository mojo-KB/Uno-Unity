using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public enum GameState
{
    PLAYERTURN,
    IATURN,
    WIN,
    LOSE
}
public class UnoCardsSet : MonoBehaviour
{
    UnoCards unoCards = new UnoCards();
    public List<UnoCards> cardsSet = new List<UnoCards>();
    public GameObject playingDeck;
    public GameObject selectColor;
    Sprite[] cardSprites;

    public GameState state;

    // Start is called before the first frame update
    void Start()
    {
        createShuffleCards();
        playingDeck = GameObject.Find("PlayingDeck");
        selectColor = GameObject.Find("SelectColor");
        SpriteRenderer renderer = playingDeck.GetComponent<SpriteRenderer>();

        foreach (Sprite sprite in cardSprites)
        {
            if (sprite.name.Contains(cardsSet[0].color.ToString()) && sprite.name.Contains(cardsSet[0].value.ToString()))
            {
                renderer.sprite = sprite;
                playingDeck.transform.localScale = new Vector3(1.5f,1.5f,1);
            }
        }
        cardsSet.RemoveAt(0);
        selectColor.SetActive(false);
        state = GameState.PLAYERTURN;
    }

    private void Update()
    {

    }


    void createShuffleCards()
    {
        cardSprites = Resources.LoadAll<Sprite>("Sprites/Cards");
        cardsSet = unoCards.createCards();

        System.Random _random = new System.Random();

        int n = cardsSet.Count;
        for (int i = 0; i < n; i++)
        {
            UnoCards unoCards;

            int r = i + (int)(_random.NextDouble() * (n - i));
            unoCards = cardsSet[r];
            cardsSet[r] = cardsSet[i];
            cardsSet[i] = unoCards;
        }
    }

    //When the deck is clicked, the player receive a new card.
    private void OnMouseDown()
    {
        GameObject go = new GameObject("Card " + cardsSet.First().value.ToString() + " " + cardsSet.First().color.ToString());
        
        go.AddComponent<LayoutElement>();
        go.AddComponent<Move>();
        go.AddComponent<BoxCollider2D>();
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        
        //Since my logic was fucked up at the beginning of the project, I have to use a foreach to fix a sprite..
        foreach (Sprite sprite in cardSprites)
        {
            if (sprite.name.Contains(cardsSet.First().color.ToString()) && sprite.name.Contains(cardsSet.First().value.ToString()))
            {
                renderer.sprite = sprite;
                renderer.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            }
        }

        iTween.MoveTo(go, iTween.Hash("x", 4, "y", -4.14,"z",-0.2, "speed", 30, "time", .6f,"oncomplete", "AddCardPlayerParent", "oncompletetarget", gameObject, "oncompleteparams", go));
        cardsSet.RemoveAt(0);
        LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
        state = GameState.IATURN;
    }
    //Function to give the IA a card when he can't play any card that he have in his hand.
    public void GiveIACard()
    {
        GameObject go = new GameObject("Card " + cardsSet.First().value.ToString() + " " + cardsSet.First().color.ToString());
        go.AddComponent<LayoutElement>();
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("Sprites/Cards/UNO-Back");
        renderer.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        
        iTween.MoveTo(go, iTween.Hash("x", -4, "y", 3.9, "z", -0.2, "speed", 30, "time", .6f, "oncomplete", "AddCardIAParent", "oncompletetarget", gameObject, "oncompleteparams", go));
        cardsSet.RemoveAt(0);
    } 
    //Function to add two cards depending on who played it.
    public void AddTwoCards(GameObject player)
    {
        for (int i = 0; i < 2; i++)
        {
            Debug.Log(i);
            GameObject go = new GameObject("Card " + cardsSet.First().value.ToString() + " " + cardsSet.First().color.ToString());
            go.AddComponent<LayoutElement>();
            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();

            if (player.tag == "Player")
            {
                go.transform.SetParent(GameObject.Find("IAHand").transform, false);
                renderer.sprite = Resources.Load<Sprite>("Sprites/Cards/UNO-Back");
                renderer.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            }
            else
            {
                go.transform.SetParent(GameObject.Find("PlayerHand").transform, false);
                go.AddComponent<Move>();
                go.AddComponent<BoxCollider2D>();

                foreach (Sprite sprite in cardSprites)
                {
                    if (sprite.name.Contains(cardsSet.First().color.ToString()) && sprite.name.Contains(cardsSet.First().value.ToString()))
                    {
                        renderer.sprite = sprite;
                        renderer.transform.localScale = new Vector3(1.5f, 1.5f, 1);
                    }
                }
            }

            cardsSet.RemoveAt(0);
        }
    }

    public void AddFourCards(GameObject player)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject go = new GameObject("Card " + cardsSet.First().value.ToString() + " " + cardsSet.First().color.ToString());
            go.AddComponent<LayoutElement>();
            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();

            if (player.tag == "Player")
            {
                go.transform.SetParent(GameObject.Find("IAHand").transform, false);
                renderer.sprite = Resources.Load<Sprite>("Sprites/Cards/UNO-Back");
                renderer.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            }
            else
            {
                go.transform.SetParent(GameObject.Find("PlayerHand").transform, false);
                go.AddComponent<Move>();
                go.AddComponent<BoxCollider2D>();

                foreach (Sprite sprite in cardSprites)
                {
                    if (sprite.name.Contains(cardsSet.First().color.ToString()) && sprite.name.Contains(cardsSet.First().value.ToString()))
                    {
                        renderer.sprite = sprite;
                        renderer.transform.localScale = new Vector3(1.5f, 1.5f, 1);
                    }
                }
            }

            cardsSet.RemoveAt(0);
        }       
    }

    //Function to add parent to the card draw by the player. This is the way I found to add parent after the iTween animation. Otherwise, the animation can't be played.
    private void AddCardPlayerParent(GameObject go)
    {
        go.transform.SetParent(GameObject.Find("PlayerHand").transform, false);
    }
    //Function to add parent to the card draw by the IA.
    private void AddCardIAParent(GameObject go)
    {
        go.transform.SetParent(GameObject.Find("IAHand").transform, false);
    }
}
