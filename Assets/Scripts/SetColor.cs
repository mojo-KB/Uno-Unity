using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    GameObject playingDeck;

    private void Start()
    {
        playingDeck = GameObject.Find("PlayingDeck");
    }
    public void PickColor()
    {
        if (gameObject.name.Contains("Green"))
        {
            playingDeck.GetComponent<SpriteRenderer>().color = Color.green;
            playingDeck.GetComponent<SpriteRenderer>().sprite.name = "Green";
            this.transform.parent.gameObject.SetActive(false);
        }
        else if (gameObject.name.Contains("Blue"))
        {
            playingDeck.GetComponent<SpriteRenderer>().color = Color.blue;
            playingDeck.GetComponent<SpriteRenderer>().sprite.name = "Blue";
            this.transform.parent.gameObject.SetActive(false);
        }
        else if (gameObject.name.Contains("Yellow"))
        {
            playingDeck.GetComponent<SpriteRenderer>().color = Color.yellow;
            playingDeck.GetComponent<SpriteRenderer>().sprite.name = "Yellow";
            this.transform.parent.gameObject.SetActive(false);
        }
        else if (gameObject.name.Contains("Red"))
        {
            playingDeck.GetComponent<SpriteRenderer>().color = Color.red;
            playingDeck.GetComponent<SpriteRenderer>().sprite.name = "Red";
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
