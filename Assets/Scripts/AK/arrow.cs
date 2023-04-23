using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {

    public V3L1 game;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = new Vector3(this.transform.position.x - (Time.deltaTime*7), this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x < -9)
        {
            game.hitormissIguessyounevermisshuh = true;
        }


        if (this.transform.rotation.z == 0 && this.transform.position.x < -5 && this.transform.position.x > -7 && (Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f))
        {
           Destroy(this.gameObject); Debug.Log("up");
        }
        
        else if (this.transform.position.y < -2.29  && this.transform.position.y > -2.31  && this.transform.position.x < -7 && this.transform.position.x > -8 && (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f))
        {
            Destroy(this.gameObject); Debug.Log("left");
        }

        else if ((this.transform.position.y < -3) && this.transform.position.x < -5 && this.transform.position.x > -7 && (Input.GetButton("Down") || Input.GetAxis("Vertical") < -0.25f))
        {
            Destroy(this.gameObject); Debug.Log("down");
        }

        else if (this.transform.position.y > -2.3f && this.transform.position.y < -2.28f && this.transform.position.x < -4 && this.transform.position.x > -5.5 && (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f))
        {
            Destroy(this.gameObject); Debug.Log("right");
           
        }
        
    }
}
