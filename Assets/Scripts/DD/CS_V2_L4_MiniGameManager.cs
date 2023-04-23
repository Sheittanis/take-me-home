using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CS_V2_L4_MiniGameManager : MonoBehaviour
{

    public int TargetsLeft = 6;
    private float FLT_PosX;
    private float FLT_PosY;
    public GameObject GO_Tear;
    private GameObject INST_Tear;

    public GameObject GO_Eye;
    public Text timerText;
    float timer;

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
        
        if (TargetsLeft <= 0)
        {
            EndLevel(true);
        }
        if (Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f)
        {
            FLT_PosY += 0.5f;
        }
        if (Input.GetButton("Down") || Input.GetAxis("Vertical") < -0.25f)
        {
            FLT_PosY -= 0.5f;
        }
        if (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
        {
            FLT_PosX -= 0.5f;
        }
        if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
        {
            FLT_PosX += 0.5f;
        }
        GO_Eye.transform.position = new Vector3(FLT_PosX, FLT_PosY, 0);
        FLT_PosX = 0;
        FLT_PosY = 0;

        if (Input.GetButtonDown("A"))
        {
            if (GO_Eye.transform.position.x == 0 && //SHOOT NORTH
               GO_Eye.transform.position.y == 0.5f)
            {
                INST_Tear = Instantiate(GO_Tear, new Vector3(0, 2, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            //---------------------------------------------------------------------------------
            if (GO_Eye.transform.position.x == -0.5f && //SHOOT NORTH-WEST
                GO_Eye.transform.position.y == 0.5f)
            {
                INST_Tear = Instantiate(GO_Tear, new Vector3(-1.5f, 1.5f, 0), Quaternion.Euler(new Vector3(0, 0, 45)));
            }
            //---------------------------------------------------------------------------------
            if (GO_Eye.transform.position.x == -0.5f && //SHOOT WEST
                GO_Eye.transform.position.y == 0)
            {
                INST_Tear = Instantiate(GO_Tear, new Vector3(-2, 0, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
            }
            //---------------------------------------------------------------------------------
            if (GO_Eye.transform.position.x == -0.5f && //SHOOT SOUTH-WEST
                GO_Eye.transform.position.y == -0.5f)
            {
                INST_Tear = Instantiate(GO_Tear, new Vector3(-1.5f, -1.5f, 0), Quaternion.Euler(new Vector3(0, 0, 135)));
            }
            //---------------------------------------------------------------------------------
            if (GO_Eye.transform.position.x == 0 && //SHOOT SOUTH
                GO_Eye.transform.position.y == -0.5f)
            {
                INST_Tear = Instantiate(GO_Tear, new Vector3(0, -2, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            //---------------------------------------------------------------------------------
            if (GO_Eye.transform.position.x == 0.5f && //SHOOT SOUTH-EAST
                GO_Eye.transform.position.y == -0.5f)
            {
                INST_Tear = Instantiate(GO_Tear, new Vector3(1.5f, -1.5f, 0), Quaternion.Euler(new Vector3(0, 0, 225)));
            }
            //---------------------------------------------------------------------------------
            if (GO_Eye.transform.position.x == 0.5f && //SHOOT EAST
                GO_Eye.transform.position.y == 0)
            {
                INST_Tear = Instantiate(GO_Tear, new Vector3(2, 0, 0), Quaternion.Euler(new Vector3(0, 0, 270)));
            }
            //---------------------------------------------------------------------------------
            if (GO_Eye.transform.position.x == 0.5f && //SHOOT NORTH-EAST
               GO_Eye.transform.position.y == 0.5f)
            {
                INST_Tear = Instantiate(GO_Tear, new Vector3(1.5f, 1.5f, 0), Quaternion.Euler(new Vector3(0, 0, 315)));
            }
        }
    }
    void EndLevel(bool won)
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
