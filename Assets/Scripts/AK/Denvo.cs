using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Denvo : MonoBehaviour
{
    public GameObject camera;
    public bool hit;
    public bool onTopOfTheWorld;
    // Use this for initialization
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.y < camera.transform.position.y - 4)
        {
            hit = true;
        }
        if (this.transform.position.y > 27.5f)
        {
            onTopOfTheWorld = true;
        }

    }
}


