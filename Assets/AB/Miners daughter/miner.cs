using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class miner : MonoBehaviour
{

    public GameObject dirt;
    public GameObject cleaner;
    float timer = 10;
    public Text txTimer;

    int numDirt = 0;
    List<Dirt> allDirt = new List<Dirt>();

    void Start()
    {
        numDirt = Random.Range(6, 10);

        for (int i = 0; i < numDirt; i++)
        {
            GameObject currentDirt = Instantiate<GameObject>(dirt,
                                                             new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(-3.8f, 3.8f)),
                                                             Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)));

            allDirt.Add(currentDirt.GetComponent<Dirt>());
        }
    }
    
    void Update()
    {
        if(!allDirt.Any(d => d.IsStillDirt))
        {
            cleaner.GetComponent<cleaner>().StopBeingSponge();
        }

        if(allDirt.TrueForAll(d => d == null))
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, true);
        }

        timer -= Time.deltaTime;
        txTimer.text = timer.ToString();
        if (timer < 0)
        {
            GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().SetSuccess(SceneManager.GetActiveScene().buildIndex, false);
        }
    }
}