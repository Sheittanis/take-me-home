using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{

	public bool IsStillDirt = true;
    public Sprite Suds;
	
    public void StopBeingDirt()
    {
        IsStillDirt = false;
        GetComponent<SpriteRenderer>().sprite = Suds;
    }    
}
