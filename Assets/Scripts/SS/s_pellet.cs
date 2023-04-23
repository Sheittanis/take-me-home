using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_pellet : MonoBehaviour
{
    float killTimer;
    // Use this for initialization
    void Start()
    {
        killTimer = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        killTimer -= Time.deltaTime;
        this.transform.Translate(new Vector3(10.0f * Time.deltaTime, Random.Range(-0.1f, 0.1f), 0f), 0);
        if (killTimer < 0)
            KillMe();
    }

	void KillMe(){
		Destroy(this.gameObject);
	}

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Bird"){
            //Destroy(col.gameObject);
            col.gameObject.SendMessage("KillIt", "");
        }
    }
}
