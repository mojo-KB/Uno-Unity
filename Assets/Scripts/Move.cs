using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    public GameObject selectedCard;
    public GameObject selectColor;
    public GameObject playingDeck;
    public UnoCardsSet deck;
    private Hashtable ht;

    private void Start()
    {
        selectedCard = gameObject;
        deck = GameObject.Find("Deck").GetComponent<UnoCardsSet>();
        playingDeck = GameObject.Find("PlayingDeck");
        selectColor = deck.selectColor;

        ht = new Hashtable();
        ht.Add("x", 0.99f);
        ht.Add("y", 0.1f);
        ht.Add("z", -6);
        ht.Add("speed", 30);
        ht.Add("time", .6f);
        ht.Add("oncomplete", "ShowNewPlayingCard");
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnMouseDown()
    {
        if(deck.state == GameState.PLAYERTURN) {
            string[] name = gameObject.name.Split(" ".ToCharArray()); //index 1 is "number" or text and index 2 is color.

            AudioSource audio = gameObject.AddComponent<AudioSource>();
            
            if (playingDeck.GetComponent<SpriteRenderer>().sprite.name.Contains(name[2]) || playingDeck.GetComponent<SpriteRenderer>().sprite.name.Contains(name[1]) && !gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("AddTwo")){
                //Detach gameobject from parent to use iTwee animation.
                gameObject.transform.parent = null;
                audio.PlayOneShot((AudioClip)Resources.Load("Sound/cardPlace1"));
                iTween.MoveTo(gameObject, ht);
                if(name[1] == "Block" || name[1] == "Reverse" || name[1] == "AddTwo")
                {
                    deck.state = GameState.PLAYERTURN;
                }
                else { 
                    deck.state = GameState.IATURN;
                }
            }
            else if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("Black"))
            {
                gameObject.transform.parent = null;
                audio.PlayOneShot((AudioClip)Resources.Load("Sound/cardPlace1"));
                iTween.MoveTo(gameObject, ht);
                selectColor.SetActive(true);
            }
            else if (GameObject.Find("PlayingDeck").GetComponent<SpriteRenderer>().sprite.name.Contains(name[2]) && gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("AddTwo"))
            {
                gameObject.transform.parent = null;
                audio.PlayOneShot((AudioClip)Resources.Load("Sound/cardPlace1"));
                iTween.MoveTo(gameObject, ht);
                deck.AddTwoCards(gameObject.transform.parent.gameObject);
                deck.state = GameState.IATURN;
            }
        }
    }

    //Function used when the iTween animation is complete.
    private void ShowNewPlayingCard()
    {
        playingDeck.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        playingDeck.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(gameObject);
    }
}
