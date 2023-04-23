using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class V3L1 : MonoBehaviour {
    public bool hitormissIguessyounevermisshuh;
    // Use this for initialization
    void Start () {
        hitormissIguessyounevermisshuh = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        this.transform.position = new Vector3(-6, 0, 0);
        
        if (Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f)
        {
            this.transform.position = new Vector3(this.transform.position.x, 1.5f, this.transform.position.z);
        }
        else if (Input.GetButton("Down") || Input.GetAxis("Vertical") < -0.25f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -1.5f, this.transform.position.z);
        }
        else if (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
        {
            this.transform.position = new Vector3(-7.5f, this.transform.position.y, this.transform.position.z);
        }
        else if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
        {
            this.transform.position = new Vector3(-4.5f, this.transform.position.y, this.transform.position.z);
        }


        if (GameObject.FindGameObjectsWithTag("Arrow").Length == 0 | hitormissIguessyounevermisshuh == true)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
        else if (GameObject.FindGameObjectsWithTag("Arrow").Length == 0)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
    }
}
