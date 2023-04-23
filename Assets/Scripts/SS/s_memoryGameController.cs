using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class s_memoryGameController : MonoBehaviour
{
    public GameObject cardPrefab;
    public List<GameObject> cards;
    float posX;
    float posY;
    int highlightedCard = 0;
    GameObject firstCard, secondCard;
    public int firstCardIndex, secondCardIndex;

    public List<int> possiblePairs;
    // Use this for initialization
    void Start()
    {
        posX = -5.5f;
        posY = 2.5f;
        possiblePairs = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };

        for (int i = 0; i < 12; i++)
        {
            SpawnCard();
        }

        Invoke("CreateCardFronts", 0.5f);
        HighlightCard(highlightedCard, 0);
    }


    // Update is called once per frame
    void Update()
    {
        #region Input
        if (Input.GetButtonDown("Left"))
        {
            HighlightCard(highlightedCard, -1);
        }
        if (Input.GetButtonDown("Right"))
        {
            HighlightCard(highlightedCard, +1);
        }
        if (Input.GetButtonDown("Up"))
        {
            HighlightCard(highlightedCard, -4);
        }
        if (Input.GetButtonDown("Down"))
        {
            HighlightCard(highlightedCard, +4);
        }
        if (Input.GetButtonDown("A"))
        {
            SelectCard();
        }
        #endregion
    }
    void CreateCardFronts()
    {
        foreach (var _card in cards)
        {
            var _randPair = FindPair();
            _card.SendMessage("InitCard", _randPair);
        }
    }
    int FindPair()
    {
        int index = new System.Random().Next(possiblePairs.Count);
        var name = possiblePairs[index];
        possiblePairs.RemoveAt(index);
        return name;
    }
    void HighlightCard(int index, int _moveTo)
    {
        if ((index + _moveTo) >= 0 && (index + _moveTo) < cards.Count)
        {
            UnhighlightCards();
            highlightedCard = index + (_moveTo);
            cards[highlightedCard].GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void UnselectCards()
    {
        cards[firstCardIndex].SendMessage("FlipBack", "back");
        cards[secondCardIndex].SendMessage("FlipBack", "back");
        firstCardIndex = -1;
        secondCardIndex = -1;
        firstCard = null;
        secondCard = null;
        UnhighlightCards();

    }
    void UnhighlightCards()
    {
        foreach (var _card in cards)
        {
            _card.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    void SelectCard()
    {
        if (firstCard == null)
        {
            firstCard = cards[highlightedCard];
            cards[highlightedCard].SendMessage("FlipCard", "_one");
            secondCardIndex = highlightedCard;
        }
        else if (secondCard == null)
        {
            if (cards[highlightedCard] == firstCard) //cant be the same card
            {
                return;
            }
            cards[highlightedCard].SendMessage("FlipCard", "_two");
            secondCard = cards[highlightedCard];
            firstCardIndex = highlightedCard;
            ComparePairs(firstCard, secondCard);
        }
    }
    void SpawnCard()
    {
        GameObject _card = Instantiate(cardPrefab, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;

        cards.Add(_card);

        posX = posX + 3f;

        if (posX > 5.5f)
        {
            posY = posY - 2.5f;
            posX = -5.5f;
        }
    }

    void ComparePairs(GameObject _firstCard, GameObject _secondCard)
    {
        if (_firstCard == null || _secondCard == null)
            return;

        if (_firstCard.name == _secondCard.name)
        {
            Destroy(cards[firstCardIndex].gameObject);
            cards.Remove(cards[firstCardIndex].gameObject);
            Destroy(cards[secondCardIndex].gameObject);
            cards.Remove(cards[secondCardIndex].gameObject);

            UnselectCards();
        }
        else
        {
            StartCoroutine(KeepDisplayed());
        }

    }

    IEnumerator KeepDisplayed()
    {
        yield return new WaitForSeconds(0.5f);
        UnselectCards();
    }

    void LevelEnd()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
