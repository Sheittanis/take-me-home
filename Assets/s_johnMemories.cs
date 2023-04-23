using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class s_johnMemories : MonoBehaviour
{
    private float buttonTimer = 0;

    bool holdingMemory;
    Collider2D col;
    GameObject heldMemory;
    public Text timerText;
    float timer;
    // Use this for initialization
    void Start()
    {
        timer = 10.0f;
        col = this.gameObject.GetComponent<BoxCollider2D>();
        heldMemory = this.gameObject.transform.Find("HeldMemory").gameObject;
        holdingMemory = false;
    }

    // Update is called once per frame
    void Update()
    {
        buttonTimer -= Time.deltaTime;
        timer -= Time.deltaTime;
        timerText.text = "Timer: " + System.Math.Round(timer, 2); ;
        if (timer < 0)
        {
            var _memoriesLeft = GameObject.FindGameObjectsWithTag("Memory");
            if (_memoriesLeft.Length > 0)
            {
                print("lost");
                EndLevel(false);
            }
            else{
                print("won");
                EndLevel(true);
            }
        }

        #region Input
        if (Input.GetButtonDown("Left") || (Input.GetAxis("Horizontal") < -0.25f && buttonTimer <= 0))
        {
            buttonTimer = 0.2f;
            this.transform.Translate(-1f, 0f, 0f);
        }
        if (Input.GetButtonDown("Right") || (Input.GetAxis("Horizontal") > 0.25f && buttonTimer <= 0))
        {
            buttonTimer = 0.2f;
            this.transform.Translate(1f, 0f, 0f);
        }
        if (Input.GetButtonDown("Up") || (Input.GetAxis("Vertical") > 0.25f && buttonTimer <= 0))
        {
            buttonTimer = 0.2f;
            this.transform.Translate(0f, 1f, 0f);
        }
        if (Input.GetButtonDown("Down") || (Input.GetAxis("Vertical") < -0.25f && buttonTimer <= 0))
        {
            buttonTimer = 0.2f;
            this.transform.Translate(0f, -1f, 0f);
        }
        // if (Input.GetButtonDown("A") && !holdingMemory)
        // {
        //     PickUpMemory();
        // }
        #endregion
    }

    // void PickUpMemory()
    // {
    //     col.enabled = true;
    // }

    void HoldMemory(GameObject _memory)
    {
        holdingMemory = true;
        heldMemory.GetComponent<SpriteRenderer>().sprite = _memory.GetComponent<SpriteRenderer>().sprite;
        heldMemory.GetComponent<SpriteRenderer>().flipX = _memory.GetComponent<SpriteRenderer>().flipX;
        heldMemory.GetComponent<SpriteRenderer>().flipY = _memory.GetComponent<SpriteRenderer>().flipY;
        heldMemory.GetComponent<SpriteRenderer>().color = _memory.GetComponent<SpriteRenderer>().color;
    }
    void DropMemory()
    {
        holdingMemory = false;
        //col.enabled = false;
        heldMemory.GetComponent<SpriteRenderer>().sprite = null;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Memory" && !holdingMemory)
        {
            HoldMemory(col.gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "House")
        {
            DropMemory();
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
