using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private Vector3 initPosition;
    private float angle = 0;
    private float speed = 0;
    private float range = 0;
    int facing = 0;

    void Start()
    {
        //Get a random 0 or 1, convert to -1 or 1 and then set X scale so facing different ways
        facing = Random.Range(0, 2) == 0 ? -1 : 1;
        gameObject.transform.localScale = new Vector3(facing, 1, 1);

        //Get init pos
        initPosition = transform.position;

        //Randomise values
        speed = Random.Range(10f, 25f);
        range = Random.Range(0.5f, 5f);
    }


    void Update()
    {

        float newX = Mathf.Sin(Mathf.Deg2Rad * angle) * range * facing + initPosition.x;
        transform.position = new Vector3(newX, initPosition.y, initPosition.z);

        //Increase angle and remove 360 once too big
        angle += speed * Time.deltaTime;
        if (angle > 360) angle -= 360;
    }
}
