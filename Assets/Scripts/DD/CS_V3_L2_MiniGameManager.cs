using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CS_V3_L2_MiniGameManager : MonoBehaviour
{
    public Text timerText;
    float timer;

    public GameObject Wave;

    // Use this for initialization
    void Start()
    {
        timer = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Timer: " + System.Math.Round(timer, 2);
        if (timer < 0)
            EndLevel(false);
        if (Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f)
        {
            if (Wave.transform.localScale.y < 1.5f)
            {
                Wave.transform.localScale += new Vector3(0, 0.01f, 0);
            }
        }
        if (Input.GetButton("Down") || Input.GetAxis("Vertical") < -0.25f)
        {
            if (Wave.transform.localScale.y > 0.3f)
            {
                Wave.transform.localScale -= new Vector3(0, 0.01f, 0);
            }
        }
        if (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
        {
            if (Wave.transform.localScale.x < 1.7f)
            {
                Wave.transform.localScale += new Vector3(0.01f, 0, 0);
            }
        }
        if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
        {
            if (Wave.transform.localScale.x > 1f)
            {
                Wave.transform.localScale -= new Vector3(0.01f, 0, 0);
            }
        }

        if (Wave.transform.localScale.y < 1.05f &&
           Wave.transform.localScale.y > 0.95f &&
           Wave.transform.localScale.x < 1.05f &&
           Wave.transform.localScale.x > 0.95f)
        {
            EndLevel(true);   
        }
    }

        public void EndLevel(bool won)
    {
        if (won)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
        else
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
    }
}
