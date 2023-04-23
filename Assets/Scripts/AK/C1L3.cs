using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class C1L3 : MonoBehaviour
{
    public Denvo john;


    public bool gameStatus;
    public bool johnHit;
    public int Vspeed;
    public int hspeed;
    public float timer;
    public Text txTimer;

    // Use this for initialization
    void Start()
    {

        gameStatus = false;
        // game man cor count
        hspeed = 10;
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        johnHit = john.hit;
        gameStatus = john.onTopOfTheWorld;
        timer -= Time.deltaTime;
        txTimer.text = "Timer: " + System.Math.Round(timer, 2);
        if ((Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f) && gameStatus == false && timer > 0 && this.transform.position.x < 2.3f) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x + (hspeed * Time.deltaTime), this.transform.position.y, this.transform.position.z); // moves everything up

        }
        if ((Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f) && gameStatus == false && timer > 0 && this.transform.position.x > -2.3f) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x + (-hspeed * Time.deltaTime), this.transform.position.y, this.transform.position.z); // moves everything up

        }
        if ((Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f) && gameStatus == false && timer > 0 && this.transform.position.y < 31.2f) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (Vspeed * Time.deltaTime), this.transform.position.z); // moves everything up

        }
        if ((Input.GetButton("Down") || Input.GetAxis("Vertical") < -0.25f) && gameStatus == false && timer > 0 && this.transform.position.y > 0) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (-Vspeed * Time.deltaTime), this.transform.position.z); // moves everything up


        }




        if (timer < 0 | johnHit == true)
        {

            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
        else if (gameStatus == true)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }

    }
}
