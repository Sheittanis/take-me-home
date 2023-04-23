using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_fish : MonoBehaviour
{
    bool dir;
    bool hasJumped;
    float lifeSpan;
    float jumpTime;
    SpriteRenderer fishSprite;
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        hasJumped = false;
        lifeSpan = 5.0f;

        jumpTime = Random.Range(0, lifeSpan - 1.0f);
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        dir = (this.transform.position.x <= 0);
        fishSprite = this.gameObject.GetComponent<SpriteRenderer>();
        fishSprite.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (dir)
            this.transform.Translate(new Vector3(0.1f, 0f, 0), 0);
        else
            this.transform.Translate(new Vector3(-0.1f, 0f, 0), 0);

        lifeSpan -= Time.deltaTime;

        if (lifeSpan < 0)
            KillMe();

        jumpTime -= Time.deltaTime;
        if (!hasJumped && jumpTime < 0)
            JumpOutOfWater();
    }

    void KillMe()
    {
        Destroy(this.gameObject);
    }

    void JumpOutOfWater()
    {
        rb.AddForce(new Vector2(0, 0.1f), ForceMode2D.Impulse);
        rb.gravityScale = 1.0f;
        hasJumped = true;
    }
}
