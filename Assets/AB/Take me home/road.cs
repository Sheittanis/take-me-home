using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{

    public bool straight;
    public GameObject[] signs;
    public GameObject rock;
    public int difficulty;

    void Start()
    {

        int rocks = difficulty - 1;

        if (straight)
        {
            int side = Random.Range(0, 2) == 0 ? -1 : 1;

            if (transform.rotation.z == 0)
            {
                Instantiate<GameObject>(signs[Random.Range(0, signs.Length)], new Vector3(Random.Range(4.5f, 8f) * side, Random.Range(-4f, 4f)) + transform.position, transform.rotation);
                side = Random.Range(0, 2) == 0 ? -1 : 1;
                Instantiate<GameObject>(signs[Random.Range(0, signs.Length)], new Vector3(Random.Range(4.5f, 8f) * side, Random.Range(-4f, 4f)) + transform.position, transform.rotation);
            }
            else
            {
                Instantiate<GameObject>(signs[Random.Range(0, signs.Length)], new Vector3(Random.Range(-4f, 4f), Random.Range(4.5f, 8f) * side) + transform.position, transform.rotation);
                side = Random.Range(0, 2) == 0 ? -1 : 1;
                Instantiate<GameObject>(signs[Random.Range(0, signs.Length)], new Vector3(Random.Range(-4f, 4f), Random.Range(4.5f, 8f) * side) + transform.position, transform.rotation);
            }
        }

        if (rock == null) return;

        for (int i = 0; i < rocks; i++)
        {
            GameObject currentRock = null;
            currentRock = Instantiate<GameObject>(rock, new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f)) + transform.position, transform.rotation);

            int side = Random.Range(0, 2) == 0 ? -1 : 1;
            currentRock.transform.localScale = new Vector3(side, 1, 1);
        }
    }
}