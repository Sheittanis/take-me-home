using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSongPlayer : MonoBehaviour
{

    public Sprite[] backgrounds;

    //private AudioSource audiosource;
    private AudioSource audiosource;
    private AudioClip currentClip;
    private int currentClipIndex = 0;
    public ImmortalManager immortal;
    private Image background;

    // Use this for initialization
    void Start()
    {
        immortal = GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>();
        audiosource = FindObjectOfType<AudioSource>();
        audiosource.loop = false;
        background = GameObject.Find("BACK IM").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!audiosource.isPlaying)
        {
            if (currentClipIndex == 28)
            {
                SceneManager.LoadScene("Main");
            }

            currentClipIndex++;
            while (currentClipIndex < 29 && immortal.success[currentClipIndex] == false)
            {
                currentClipIndex++;
            }

            background.sprite = backgrounds[currentClipIndex];
            currentClip = immortal.songClips[currentClipIndex];
            audiosource.clip = currentClip;
            audiosource.Play();

        }
    }
}
