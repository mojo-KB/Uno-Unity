﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAPlay : MonoBehaviour
{
    private UnoCardsSet deck;
    private SpriteRenderer playingDeck;
    private float timer;
    private float waitingTime;
    Sprite[] cardSprites;

    // Start is called before the first frame update
    void Start()
    {
        timer = .0f;
        waitingTime = 3f;
        cardSprites = Resources.LoadAll<Sprite>("Sprites/Cards");
        deck = GameObject.Find("Deck").GetComponent<UnoCardsSet>();
        playingDeck = GameObject.Find("PlayingDeck").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deck.state == GameState.IATURN)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                timer = 0f;
                PlayCard();
            }
        }
        LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
    }
    //Function for the IA to play a card. It's a really simple way since I don't want to spend more time on this project anymore. I check in a "for" for all the cards I have. If the card is playable, the IA plays it otherwise I go to the next one.
    private void PlayCard()
    {
        bool pick = true;
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            string[] name = gameObject.transform.GetChild(i).name.Split(" ".ToCharArray());
            if (playingDeck.sprite.name.Contains(name[2])) {
                foreach (Sprite sprite in cardSprites)
                {
                    if (sprite.name.Contains(name[2]) && sprite.name.Contains(name[1]))
                    {
                        playingDeck.sprite = sprite;
                    }       
                }
                //WIP: Animation when IA plays a card
                iTween.MoveTo(gameObject.transform.GetChild(i).gameObject, iTween.Hash("x", 0.99f, "y", 0.1f, "z", -6, "speed", 30, "time", .6f, "oncomplete", "DestroyPlayedCard", "oncompletetarget", gameObject, "oncompleteparams", gameObject.transform.GetChild(i).gameObject));
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

    private void DestroyPlayedCard(GameObject go)
    {
        Destroy(go);
    }
}