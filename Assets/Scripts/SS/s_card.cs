using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_card : MonoBehaviour
{

    public SpriteRenderer cardFace;
    Sprite cardBack;
    Sprite frontSprite;
    // Use this for initialization
    void Start()
    {
        cardFace = this.gameObject.GetComponent<SpriteRenderer>();
        cardBack = Resources.Load<Sprite>("Sprites/SS_Card_Back");
        
        cardFace.sprite = cardBack;
    }

    void FlipCard(string test)
    {
        cardFace.sprite = frontSprite;
    }
    void FlipBack(string test)
    {
        cardFace.sprite = cardBack;
    }
    void InitCard(int test)
    {
        frontSprite = Resources.Load<Sprite>("Sprites/SS_Card_" + test);

        this.name = this.name + test.ToString();
    }
}
