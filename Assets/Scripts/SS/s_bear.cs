using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_bear : MonoBehaviour
{
    float cooldown;
    Collider2D col;

    public Sprite bearIdle;
    public Sprite bearAttacking;
	public s_bearFishingController bearFishingController;
    SpriteRenderer bearSprite;
    // Use this for initialization
    void Start()
    {
        cooldown = 0.0f;
        col = this.gameObject.GetComponent<PolygonCollider2D>();
        bearSprite = this.gameObject.GetComponent<SpriteRenderer>();
        bearFishingController = GameObject.Find("BearFishingController").GetComponent<s_bearFishingController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
        else
        {
            col.enabled = false;
            bearSprite.sprite = bearIdle;
        }

        #region Input
        if (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
        {
            this.transform.Translate(new Vector3(-0.1f, 0f, 0), 0);
        }
        if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
        {
            this.transform.Translate(new Vector3(0.1f, 0f, 0), 0);
        }
        if (Input.GetButton("A") && cooldown <= 0)
        {
            Swipe();
        }

        // if (Input.GetButton("B") && cooldown <= 0)
        // {
        //     Swipe();
        // }
        #endregion

    }
    void Swipe()
    {

        bearSprite.sprite = bearAttacking;
        cooldown = 0.5f;
        col.enabled = true;
    }

    
    void OnTriggerEnter2D(Collider2D fish)
    {
        if (fish.gameObject.tag == "Fish")
        {
            Destroy(fish.gameObject);
			bearFishingController.IncreaseScore();
        }
    }

}
