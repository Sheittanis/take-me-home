using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_C_L2_Letters : MonoBehaviour
{
    private CS_C_L2_MiniGameManager MiniGameMan;
    private SpriteRenderer SpriteRen;
    public Sprite[] ARRY_SPR_PossibleColours;
    public bool BOL_LetterColour;
    public float flt_FallSpeed;
    public float FLT_DirectionX = 0;
    

    // Use this for initialization
    void Start ()
    {
        MiniGameMan = GameObject.Find("MiniGameMan").GetComponent<CS_C_L2_MiniGameManager>();
        flt_FallSpeed = MiniGameMan.FLT_FallSpeed;
        SpriteRen = GetComponent<SpriteRenderer>();

        if(BOL_LetterColour == false)
        {
            SpriteRen.sprite = ARRY_SPR_PossibleColours[0]; //Blue
        }
        else //true
        {
            SpriteRen.sprite = ARRY_SPR_PossibleColours[1]; //Red
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = new Vector3(this.transform.position.x + (FLT_DirectionX * Time.deltaTime),
                                              this.transform.position.y - (flt_FallSpeed * Time.deltaTime),
                                              0);
        
        if(BOL_LetterColour == false)
        {
           this.transform.Rotate(0, 0, 5, Space.Self);
        }
        else
        {
            this.transform.Rotate(0, 0, -5, Space.Self);
        }

        if(this.transform.position.x < -2.5f && BOL_LetterColour == true)
        {
            MiniGameMan.EndLevel(false);
        }
        if (this.transform.position.x > 2.5f && BOL_LetterColour == false)
        {
            MiniGameMan.EndLevel(false);
        }

        if(this.transform.position.x > 5.5f || this.transform.position.x < -5.5)
        {
            Destroy(this.gameObject);
        }
    }
}
