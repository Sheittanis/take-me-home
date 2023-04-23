using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V1L1_GameMan : MonoBehaviour
{
    public bool gameStatus;
    public int stepCount;
    public float timer;
    public Text txTimer;
    // Use this for initialization
    void Start()
    {
        gameStatus = false;
        stepCount = 0;
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        txTimer.text = "Timer: " + System.Math.Round(timer, 2);

        if (Input.GetButtonDown("A") && gameStatus == false && timer > 0) // edit this plx
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z); // moves everything up
            stepCount++;
            Debug.Log("space");
        }
        if (stepCount >= 80 && timer > 0)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
        if (timer < 0)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
    }
}
