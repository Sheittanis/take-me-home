using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_C_L2_MiniGameManager : MonoBehaviour
{
    private float nextPress = 0;

    private int INT_NumberOfLetters;
    private int INT_LetterOn;
    private float Timer = 0;
    public float FLT_FallSpeed;
    //public int[] ARRY_INT_Letters;
    public GameObject[] ARRY_GO_Letters;

    // Use this for initialization
    void Start()
    {
        INT_NumberOfLetters = ARRY_GO_Letters.Length;
    }

    // Update is called once per frame
    void Update()
    {
        nextPress -= Time.deltaTime;

        if (INT_LetterOn < INT_NumberOfLetters)
        {
            if (ARRY_GO_Letters[INT_LetterOn].transform.position.y > -2.3f &&
               ARRY_GO_Letters[INT_LetterOn].transform.position.y < 4)
            {
                if (Input.GetButtonDown("Left") || (Input.GetAxis("Horizontal") < -0.25f && nextPress <= 0f))
                {
                    nextPress = 0.3f;
                    ARRY_GO_Letters[INT_LetterOn].GetComponent<CS_C_L2_Letters>().FLT_DirectionX = -4;
                    ARRY_GO_Letters[INT_LetterOn].GetComponent<CS_C_L2_Letters>().flt_FallSpeed = 0;
                    INT_LetterOn++;
                }
                if (Input.GetButtonDown("Right") || (Input.GetAxis("Horizontal") > 0.25f && nextPress <= 0f))
                {
                    nextPress = 0.3f;
                    ARRY_GO_Letters[INT_LetterOn].GetComponent<CS_C_L2_Letters>().FLT_DirectionX = 4;
                    ARRY_GO_Letters[INT_LetterOn].GetComponent<CS_C_L2_Letters>().flt_FallSpeed = 0;
                    INT_LetterOn++;
                }
            }
            else if (ARRY_GO_Letters[INT_LetterOn].transform.position.y <= -2.3f)
            {
                EndLevel(false);
            }
        }
        else
        {
            Timer += Time.deltaTime;
            if (Timer > 1.5f)
            {
                EndLevel(true);
            }
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

    /* public void SelectorPosition()
     {
         GO_Selector.transform.position = transform.position;
         GO_Selector.transform.localRotation = RB2D_CurrentLetter.transform.localRotation;
     }*/
}
