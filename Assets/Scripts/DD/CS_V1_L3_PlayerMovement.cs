using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_V1_L3_PlayerMovement : MonoBehaviour
{
    private bool BOL_Position = false; //false=left | true=right
    public int INT_CurrentLog = 0;
    private CS_V1_L3_MiniGameManager MiniGameMan;
    private SpriteRenderer SpriteRen;
    public Sprite[] SPR_Lumberjack;

	// Use this for initialization
	void Start ()
    {
        MiniGameMan = GameObject.Find("MiniGameMan").GetComponent<CS_V1_L3_MiniGameManager>();
        SpriteRen = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(MiniGameMan.BOL_IsFail == false)
        {
            SpriteRen.sprite = SPR_Lumberjack[0];
            if (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
            {
                if(BOL_Position != false && MiniGameMan.ARRY_INT_TreeGeometry[INT_CurrentLog] != 1) //If not left
                {
                    BOL_Position = false;
                    this.transform.position = new Vector3(-0.75f,-3, 0);
                    this.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
            {
                if (BOL_Position != true && MiniGameMan.ARRY_INT_TreeGeometry[INT_CurrentLog] != 2)
                {
                    BOL_Position = true;
                    this.transform.position = new Vector3(0.75f,-3, 0);
                    this.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            if (Input.GetButtonDown("A"))
            {
                SpriteRen.sprite = SPR_Lumberjack[1];
                if (BOL_Position == false)
                {
                    MiniGameMan.ARRY_RB2D_TreeParts[INT_CurrentLog].isKinematic = false;
                    MiniGameMan.ARRY_RB2D_TreeParts[INT_CurrentLog].AddForce(new Vector2(500, 0));
                    MiniGameMan.ARRY_RB2D_TreeParts[INT_CurrentLog].AddTorque(-1000);
                    if (INT_CurrentLog + 1 < 22 && MiniGameMan.ARRY_INT_TreeGeometry[INT_CurrentLog + 1] == 1)
                    {
                        SpriteRen.sprite = SPR_Lumberjack[2];
                        MiniGameMan.BOL_IsFail = true;
                    }
                }
                if (BOL_Position == true)
                {
                    MiniGameMan.ARRY_RB2D_TreeParts[INT_CurrentLog].isKinematic = false;
                    MiniGameMan.ARRY_RB2D_TreeParts[INT_CurrentLog].AddForce(new Vector2(-500, 0));
                    MiniGameMan.ARRY_RB2D_TreeParts[INT_CurrentLog].AddTorque(1000);
                    if (INT_CurrentLog + 1 < 22 && MiniGameMan.ARRY_INT_TreeGeometry[INT_CurrentLog + 1] == 2)
                    {
                        MiniGameMan.BOL_IsFail = true;
                        SpriteRen.sprite = SPR_Lumberjack[2];
                    }
                }
                MiniGameMan.CheckTree(INT_CurrentLog);
                INT_CurrentLog++;
            }
        }
        else
        {
            MiniGameMan.Fail();
        }
    }
}
