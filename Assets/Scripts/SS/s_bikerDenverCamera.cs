using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_bikerDenverCamera : MonoBehaviour
{
    public GameObject denver;
    private float followDistance = -4.5f;
    private float yOffset = 3.5f;

    void Update()
    {
        float newX = denver.transform.position.x >= followDistance ? denver.transform.position.x - followDistance : transform.position.x;
        float newY = denver.transform.position.y > yOffset + 1 ? denver.transform.position.y - 3.5f : 0;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
