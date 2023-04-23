using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class s_calendarController : MonoBehaviour
{
    private float buttonTimer = 0;

    public GameObject dayPrefab;
    public List<GameObject> days;
    float posX;
    float posY;
    int highlightedDay = 0;
    DateTime day;
    GameObject _dayObj;
    public GameObject dayTextPrefab;
    public Text monthText;
    public Text levelTimerText;
    float levelTimer;
    public Transform CalendarCanvas;
    // Use this for initialization
    void Start()
    {
        levelTimer = 10.0f;
        posX = -6.5f;
        posY = 1.5f;
        for (int i = 1; i < 36; i++)
        {
            SpawnDays(i);
        }

        day = System.DateTime.Now;
        string today = day.Day.ToString();
        string month = day.ToString("MMMM");
        string year = day.Year.ToString();
        monthText.text = month.ToUpper() + " " + year;
        _dayObj = GameObject.Find(today);
        _dayObj.GetComponent<Text>().color = Color.green;
        HighlightCard(highlightedDay, 0);
    }

    // Update is called once per frame
    void Update()
    {
        buttonTimer -= Time.deltaTime;
        levelTimer -= Time.deltaTime;
        levelTimerText.text = "Timer: " + System.Math.Round(levelTimer, 2); ;
        if (levelTimer < 0)
            EndLevel(false);

        #region Input
        if (Input.GetButtonDown("Left") || (Input.GetAxis("Horizontal") < -0.25f && buttonTimer <= 0))
        {
            buttonTimer = 0.2f;
            HighlightCard(highlightedDay, -1);
        }
        if (Input.GetButtonDown("Right") || (Input.GetAxis("Horizontal") > 0.25f && buttonTimer <= 0))
        {
            buttonTimer = 0.2f;
            HighlightCard(highlightedDay, +1);
        }
        if (Input.GetButtonDown("Up") || (Input.GetAxis("Vertical") > 0.25f && buttonTimer <= 0))
        {
            buttonTimer = 0.2f;
            HighlightCard(highlightedDay, -7);
        }
        if (Input.GetButtonDown("Down") || (Input.GetAxis("Vertical") < -0.25f && buttonTimer <= 0))
        {
            buttonTimer = 0.2f;
            HighlightCard(highlightedDay, +7);
        }
        if (Input.GetButtonDown("A"))
        {
            SelectDay();
        }
        #endregion
    }

    void HighlightCard(int index, int _moveTo)
    {
        if ((index + _moveTo) >= 0 && (index + _moveTo) < days.Count)
        {
            UnhighlightCards();
            highlightedDay = index + (_moveTo);
            days[highlightedDay].GetComponent<Text>().color = Color.red;
        }

    }

    void UnhighlightCards()
    {
        foreach (var _day in days)
        {
            _day.GetComponent<Text>().color = Color.gray;
            _dayObj.GetComponent<Text>().color = Color.green;
        }
    }
    void SelectDay()
    {
        days[highlightedDay].GetComponent<Text>().color = Color.yellow;
        if (highlightedDay == day.Day - 2)
            EndLevel(true);
    }

    void SpawnDays(int _day)
    {
        //GameObject _dayObj = Instantiate(dayPrefab, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
        GameObject _dayObj = Instantiate(dayTextPrefab, new Vector3(posX, posY, 0), Quaternion.identity, CalendarCanvas) as GameObject;

        if (_day > 31)
            _day -= 31;

        _dayObj.name = _day.ToString();
        _dayObj.GetComponent<Text>().text = _dayObj.name;
        days.Add(_dayObj);

        posX = posX + 2.15f;
        if (posX > 8f)
        {
            posY = posY - 1.25f;
            posX = -6.5f;
        }
    }

    void EndLevel(bool _found)
    {
        if (_found)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }
        else
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
    }
}
