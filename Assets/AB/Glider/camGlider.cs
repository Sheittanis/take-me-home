using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camGlider : MonoBehaviour {

    public GameObject glider;
    private float followDistance = -6.5f;
    private float yOffset = 3.5f;

    void Update()
    {
        float newX = glider.transform.position.x >= followDistance ? glider.transform.position.x - followDistance : transform.position.x;
        float newY = glider.transform.position.y > yOffset + 1 ? glider.transform.position.y - 3.5f : 1;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
