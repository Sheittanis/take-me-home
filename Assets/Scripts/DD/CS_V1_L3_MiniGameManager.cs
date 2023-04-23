using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_V1_L3_MiniGameManager : MonoBehaviour
{
    private CS_V1_L3_PlayerMovement PlayMove;
    //private int INT_LastKnownLog = 0;
    public bool BOL_IsFail;
    public int[] ARRY_INT_TreeGeometry;
    public Rigidbody2D[] ARRY_RB2D_TreeParts;

    // Use this for initialization
    void Start()
    {
        PlayMove = GameObject.Find("Lumberjack").GetComponent<CS_V1_L3_PlayerMovement>();
    }

    public void CheckTree(int _int_current)
    {
        if (_int_current < 21)
        {
            for (int _i = _int_current; _i < 22; _i++)
            {
                ARRY_RB2D_TreeParts[_i].transform.position = new Vector3(0,
                                                                         ARRY_RB2D_TreeParts[_i].transform.position.y - 1,
                                                                         0);

            }
        }
        else
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

    public void Fail()
    {
        EndLevel(false);
    }
}
