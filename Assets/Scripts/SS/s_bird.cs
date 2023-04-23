using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_bird : MonoBehaviour
{
    public int difficulty;
    public GameObject denver;
    public Sprite exploded;
    bool dead;
    float deadTimer;
    // Use this for initialization
    void Start()
    {
        deadTimer = 1.0f;
        denver = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (denver != null && !dead)
        {
            float step = 3f * Time.deltaTime * difficulty;
            if (Mathf.Abs(transform.position.x - denver.transform.position.x) < 12)
            {
                transform.position = Vector2.MoveTowards(transform.position, denver.transform.position, step);
            }
            // move sprite towards the target location
        }
        if (dead)
            deadTimer -= Time.deltaTime;

        if (deadTimer < 0)
            Destroy(this.gameObject);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            denver.GetComponent<s_bikerDenver>().EndLevel(false);
            //Destroy(this.gameObject);
            //end the level
        }

    }
    void KillIt(string nothing)
    {
        dead = true;
        this.GetComponent<PolygonCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = exploded;
    }
}
