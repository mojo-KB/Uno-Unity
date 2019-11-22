﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoCardsSet : MonoBehaviour
{
    UnoCards unoCards = new UnoCards();
    public List<UnoCards> cardsSet = new List<UnoCards>();
    Sprite[] cardSprites;


    // Start is called before the first frame update
    void Start()
    {
        createShuffleCards();
        Debug.Log(cardsSet.Count);
    }

    // Update is called once per frame
    void Update()
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
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            unoCards = cardsSet[r];
            cardsSet[r] = cardsSet[i];
            cardsSet[i] = unoCards;
        }
    }
}