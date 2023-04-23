using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CS_V2_L4_MoonShine : MonoBehaviour {

    private CS_V2_L4_MiniGameManager MiniGameMan;
	// Use this for initialization
	void Start ()
    {
        MiniGameMan = GameObject.Find("MiniGameMan").GetComponent<CS_V2_L4_MiniGameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        MiniGameMan.TargetsLeft--;
        Destroy(col.gameObject);
        Destroy(this.gameObject);
    }
}
