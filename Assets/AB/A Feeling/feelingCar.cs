using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class feelingCar : MonoBehaviour {

    float speed = 5f;
    float timer = 10f;
    public Text txTimer;

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            transform.localScale = new Vector3(-1, 1);
            GetComponent<Rigidbody2D>().AddTorque(1);
        }
        
        if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            transform.localScale = Vector3.one;
            GetComponent<Rigidbody2D>().AddTorque(-1);
        }


        if(transform.position.x < -7 && transform.position.y < -2)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }

        timer -= Time.deltaTime;
        txTimer.text = timer.ToString();
        if (timer < 0)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
    }
}
