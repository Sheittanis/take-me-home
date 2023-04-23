using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstMove : MonoBehaviour {

    public float x;
    public float y;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Time.deltaTime * new Vector3(x, y, 0));
	}
}
