using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour {
    float speed = 10f;
    public bool IsStillSponge = true;
    public Sprite Shower;
    void Update()
    {
        if (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * -1);
        }
        
        if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetButton("Down") || Input.GetAxis("Vertical") < -0.25f)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime * -1);
        }

        if (Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col_)
    {
        Dirt dirt = col_.gameObject.GetComponent<Dirt>();
        if (dirt.IsStillDirt)
        {
            dirt.StopBeingDirt();
        }
        else
        {
            if (IsStillSponge) return;
            Destroy(dirt.gameObject);
        }
    }

    public void StopBeingSponge()
    {
        IsStillSponge = false;
        GetComponent<SpriteRenderer>().sprite = Shower;
    }
}
