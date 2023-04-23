using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V2L3 : MonoBehaviour {

    public GameObject paint;
    public bool gameStatus;
    public int Vspeed;
    public int hspeed;
    public float timer;
    public Text txTimer;
    private float paintimer;


    public bool TR;
    public bool BR;
    public bool TL;
    public bool BL;
    public int paintCount;
    public bool alotofpaint;
    // Use this for initialization
    void Start () {
        gameStatus = false;
        hspeed = 10;
        Vspeed = 10;
        timer = 15;
        TR = false;
        BR = false;
        TL = false;
        BL = false;
        alotofpaint = false;
    }
	
	// Update is called once per frame
	void Update () {


        timer -= Time.deltaTime;
        txTimer.text = "Timer: " + System.Math.Round(timer, 2);

        if ((Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f) && gameStatus == false && timer > 0 && this.transform.position.x < 4.9f) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x + (hspeed * Time.deltaTime), this.transform.position.y, this.transform.position.z); // moves everything up

        }
        if ((Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f) && gameStatus == false && timer > 0 && this.transform.position.x > -5.15f) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x + (-hspeed * Time.deltaTime), this.transform.position.y, this.transform.position.z); // moves everything up

        }
        if ((Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f) && gameStatus == false && timer > 0 && this.transform.position.y < 2f) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (Vspeed * Time.deltaTime), this.transform.position.z); // moves everything up

        }
        if ((Input.GetButton("Down") || Input.GetAxis("Vertical") < -0.25f) && gameStatus == false && timer > 0 && this.transform.position.y > -1.5f) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (-Vspeed * Time.deltaTime), this.transform.position.z); // moves everything up


        }


        if (paintimer < 0 && Input.GetButton("A") && 
            ((Input.GetButton("Down") || Input.GetAxis("Vertical") < -0.25f)
            | (Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f)
            | (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
            | (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)))
        {
            Instantiate(paint, this.transform.position, this.transform.rotation);
            paintimer = 0.02f;
        }
        paintimer = paintimer - Time.deltaTime;

        if (this.gameObject.transform.position.x > 4.6 && this.gameObject.transform.position.y > 1.8) // win condish
        {
            TR = true; 
        }
        if (this.gameObject.transform.position.x > 4.6 && this.gameObject.transform.position.y < -1.4) // win condish
        {
            BR = true;
        }
        if (this.gameObject.transform.position.x < -4.6 && this.gameObject.transform.position.y > 1.8) // win condish
        {
            TL = true;
        }
        if (this.gameObject.transform.position.x < -4.6 && this.gameObject.transform.position.y < -1.4) // win condish
        {
            BL = true;
        }
        paintCount = GameObject.FindGameObjectsWithTag("Paint").Length;
        if (GameObject.FindGameObjectsWithTag("Paint").Length > 250 && TR == true && BR == true && TL == true && BL == true)
        {
            gameStatus = true;
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
        if (timer < 0)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }

        
    }
}
