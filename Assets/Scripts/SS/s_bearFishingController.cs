using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class s_bearFishingController : MonoBehaviour
{
    float levelTimer;
    int fishSlayer;
    bool dir;
    public GameObject fishPrefab;
    public Text scoreText;
    public Text timerText;
    public float timer;
    // Use this for initialization
    void Start()
    {
        levelTimer = 10.0f;
        fishSlayer = 0;
        timer = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
            SpawnFish();

        levelTimer -= Time.deltaTime;
        if (levelTimer < 0)
            LevelEnd();

        scoreText.text = "Caught: " + fishSlayer + "/5";
        timerText.text = "Timer: " + System.Math.Round(levelTimer, 2); ;
    }

    void SpawnFish()
    {
        dir = (Random.Range(0, 100) > 50);

        if (dir)
            Instantiate(fishPrefab, new Vector3(this.transform.position.x + 8, this.transform.position.y + Random.Range(-2.5f, -4.0f), 0), Quaternion.Euler(0f, 0f, 90f));
        else
            Instantiate(fishPrefab, new Vector3(this.transform.position.x - 8, this.transform.position.y + Random.Range(-2.5f, -4.0f), 0), Quaternion.Euler(0f, 0f, 270f));

        timer = 0.3f;
    }

    public void IncreaseScore()
    {
        fishSlayer++;
    }
    void LevelEnd()
    {
        if (fishSlayer >= 5)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
        else
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
    }
}
