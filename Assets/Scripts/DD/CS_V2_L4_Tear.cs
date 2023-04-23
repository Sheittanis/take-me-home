using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_V2_L4_Tear : MonoBehaviour {

    public float FLT_MovementX;
    public float FLT_MovementY;
    // Use this for initialization
    void Start ()
    {
        FLT_MovementX = this.transform.position.x;
        FLT_MovementY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position += new Vector3(FLT_MovementX * Time.deltaTime, FLT_MovementY * Time.deltaTime, 0);
	}
}
