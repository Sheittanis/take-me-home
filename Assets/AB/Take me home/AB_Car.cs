using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AB_Car : MonoBehaviour
{

    private float speed = 6f;
    private float rotationSpeed = 360f;

    public int difficulty;

    void Start()
    {
        speed = 6 + difficulty * 2;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);

        if (Input.GetButton("Left") || Input.GetAxis("Horizontal") < -0.25f)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f)
        {
            transform.Rotate(-1 * Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
    }

    void OnCollisionEnter2D(Collision2D col_)
    {
        if (col_.collider.name.Contains("Rock"))
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }

        
        if (col_.collider.name == "Target")
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
    }
}
