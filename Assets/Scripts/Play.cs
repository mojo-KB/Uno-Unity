using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{

    private GameObject deck;
    // Start is called before the first frame update
    void Start()
    {
        deck = GameObject.Find("PlayingDeck");
        SpriteRenderer renderer = deck.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
