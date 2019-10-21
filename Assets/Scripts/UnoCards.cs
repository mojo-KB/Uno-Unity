using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnoCardsColors
{
    Red,
    Blue,
    Yellow,
    Green,
    Black
}

public enum UnoCardsValues
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Block,
    Reverse,
    AddTwo,
    AddFour,
    ChangeColor
}
public class UnoCards : MonoBehaviour
{
    public UnoCardsColors color;
    public UnoCardsValues value;
    private List<UnoCards> cards = new List<UnoCards>();

    public UnoCards()
    {
        
    }

    public UnoCards(UnoCardsColors _color, UnoCardsValues _value)
    {
        color = _color;
        value = _value;
    }

    public List<UnoCards> createCards()
    {
        foreach(UnoCardsColors color in System.Enum.GetValues(typeof(UnoCardsColors)))
        {
            if(color != UnoCardsColors.Black)
            {
                foreach(UnoCardsValues value in System.Enum.GetValues(typeof(UnoCardsValues)))
                {
                    switch (value)
                    {
                        case UnoCardsValues.One:
                        case UnoCardsValues.Two:
                        case UnoCardsValues.Three:
                        case UnoCardsValues.Four:
                        case UnoCardsValues.Five:
                        case UnoCardsValues.Six:
                        case UnoCardsValues.Seven:
                        case UnoCardsValues.Eight:
                        case UnoCardsValues.Nine:
                            cards.Add(new UnoCards(color, value));
                            cards.Add(new UnoCards(color, value));
                            break;
                        case UnoCardsValues.Block:
                        case UnoCardsValues.Reverse:
                        case UnoCardsValues.AddTwo:
                            cards.Add(new UnoCards(color, value));
                            cards.Add(new UnoCards(color, value));
                            break;
                        case UnoCardsValues.Zero:
                            cards.Add(new UnoCards(color, value));
                            break;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 4 ; i++)
                {
                    cards.Add(new UnoCards(color, UnoCardsValues.AddFour));
                    cards.Add(new UnoCards(color, UnoCardsValues.ChangeColor));
                }
            }
        }

        return cards;
    }
}
