using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Glider : MonoBehaviour {

    private float speed = 1000.0f;
    private float angle = 0f;
    private float angleLimitUp = 35f;
    private float angleLimitDown = -75f;
    private float angleChange = 70f;
    private float extraGrav = 25f;
    private float extraRight = 450f;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update ()
    {

        //Move in facing direction
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = Mathf.Sin(angle * Mathf.Deg2Rad);
        Rigidbody2D rig = gameObject.GetComponent<Rigidbody2D>();
        rig.AddForce(speed * Time.deltaTime  * new Vector2(x, y));

        if(rig.velocity.y > -0.1)
        {
            rig.AddForce(Vector2.down * extraGrav);
        }

        rig.AddForce(Vector2.right * extraRight * Time.deltaTime);

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //If Left, tilt up
        if(Input.GetButton("Left") || Input.GetAxis("Horizontal") < - 0.25f)
        { 
            angle += angleChange * Time.deltaTime;
            if (angle > angleLimitUp) angle = angleLimitUp;
        }

        //If Right, tilt down
        if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
        {
            angle -= angleChange * Time.deltaTime;
            if (angle < angleLimitDown) angle = angleLimitDown;
        }

    }    


    void OnCollisionEnter2D(Collision2D col_)
    {

        //Collide with ground bad
        if (col_.collider.name.Contains("Floor"))
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }


        //Collide with target good
        if (col_.collider.name == "Target")
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
    }




    //Touch wind - move


}
