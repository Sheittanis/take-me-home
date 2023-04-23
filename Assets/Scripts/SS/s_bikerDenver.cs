using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class s_bikerDenver : MonoBehaviour
{
    public float shootCooldown;
    float jumpCooldown;
    int numberOfPellets;
    public GameObject pelletPrefab;
    float maxSpeed;

    public int difficulty;
    float currentSpeed;

    bool isGrounded;
    public bool isFlipped;
    Rigidbody2D rb;
    [SerializeField]
    float eulerAngZ;

    float levelTimer;
    public Text timerText;
    // Use this for initialization
    void Start()
    {
        levelTimer = 10.0f;
        maxSpeed = 2.0f + difficulty;
        jumpCooldown = 0.5f;
        shootCooldown = 0.5f;
        numberOfPellets = 10;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        eulerAngZ = transform.localEulerAngles.z;
        currentSpeed = Mathf.Round(this.gameObject.GetComponent<Rigidbody2D>().velocity.x);

        if ((eulerAngZ >= 0 && eulerAngZ <= 45) ||
            (eulerAngZ >= 315 && eulerAngZ <= 360))
        {
            isFlipped = false;
        }
        levelTimer -= Time.deltaTime;
        timerText.text = "Timer: " + System.Math.Round(levelTimer, 2);
        if (levelTimer < 0)
        {
            EndLevel(false);
        }
        #region Input
        if ((Input.GetButton("Up") || Input.GetAxis("Vertical") > 0.25f) && !isGrounded)
        {
            this.transform.Rotate(0, 0f, 5f, Space.Self);
        }
        if ((Input.GetButton("Down") || Input.GetAxis("Vertical") < - 0.25f) && !isGrounded)
        {
            this.transform.Rotate(0, 0f, 5f, Space.Self);
        }
        if (Input.GetButtonDown("A") && isGrounded)
        {
            Jump();
        }
        if ((Input.GetButton("Right") || Input.GetAxis("Horizontal") > 0.25f) && currentSpeed < maxSpeed && !isFlipped)
        {
            Throttle();
        }

        if (Input.GetButtonDown("B") && shootCooldown <= 0)
        {
            Shoot();
        }
        #endregion
    }

    void Update()
    {
        if (jumpCooldown > 0)
            jumpCooldown -= Time.deltaTime;
        if (shootCooldown > 0)
            shootCooldown -= Time.deltaTime;

        if (isGrounded)
        {
            rb.freezeRotation = true;
        }
    }
    void Shoot()
    {
        shootCooldown = 0.5f;
        for (int i = 0; i < numberOfPellets; i++)
        {
            GameObject _pellet = Instantiate(pelletPrefab, new Vector3(this.transform.position.x, this.transform.position.y + Random.Range(0.5f, 1.5f), 0), Quaternion.identity) as GameObject;
        }
    }
    void Throttle()
    {
        rb.AddForce(Vector2.right, ForceMode2D.Impulse);
    }
    void Jump()
    {
        isGrounded = false;
        jumpCooldown = 0.5f;
        rb.AddForce(new Vector2(0, 8.5f), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (col.collider.name == "Target")
        {
            EndLevel(true);
        }
        
        if (col.collider.name.Contains("Barrel"))
        {
            EndLevel(false);
        }
    }

    public void EndLevel(bool won)
    {
        if (won)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
        else
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
    }

}