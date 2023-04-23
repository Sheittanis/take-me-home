using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImmortalManager : MonoBehaviour
{
    private AudioSource audio;
    private Text title;
    private Text instruction;
    private Image[] buttons;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        audio = GetComponent<AudioSource>();
        title = GetComponents<Text>()[0];
        instruction = GetComponents<Text>()[1];
        buttons = GetComponents<Image>();
    }

    private int offset = 0; //Number of scenes before first line in the build order
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int index = scene.buildIndex - offset;

        //Buttons
        for (int b = 0; b < buttons.Length; b++)
        {
            buttons[b].enabled = buttonStates[index][b];
        }

        //Words
        title.text = lyrics[index];

        //Other Words
        instruction.text = instructions[index];

        //Sound
        audio.clip = songClips[index];
        audio.Play();
    }




    private string[] lyrics =
    {
        //Verse 1
        "Almost heaven, West Virginia",
        "Blue Ridge Mountains, Shenandoah River",
        "Life is old there, older than the trees",
        "Younger than the mountains, blowing like a breeze",
        
        //Chorus
        "Country roads, take me home",
        "To the place I belong",
        "West Virginia, mountain mama",
        "Take me home, country roads",
        
        //Verse 2
        "All my memories gather round her",
        "Miner's lady, stranger to blue water",
        "Dark and dusty, painted on the sky",
        "Misty taste of moonshine, teardrop in my eye",
        
        //Chorus
        "Country roads, take me home",
        "To the place I belong",
        "West Virginia, mountain mama",
        "Take me home, country roads",
        
        //Verse 3
        "I hear her voice, in the morning hour she calls me",
        "The radio reminds me of my home far away",
        "And driving down the road I get a feeling",
        "That I should have been home yesterday, yesterday",
        
        //Chorus
        "Country roads, take me home",
        "To the place I belong",
        "West Virginia, mountain mama",
        "Take me home, country roads",
        
        //Chorus
        "Country roads, take me home",
        "To the place I belong",
        "West Virginia, mountain mama",
        "Take me home, country roads",
        
        //Outro / Credits
        "Take me home, down country roads"
    };

    private string[] instructions =
    {
        //Verse 1
        "Climb the stairs",
        "Catch the fish",
        "Chop the tree",
        "Land on the target",
        
        //Chorus
        "Do a flip and shoot sea gulls",
        "Sort the mail",
        "Climb the mountain",
        "Stay on the road",
        
        //Verse 2
        "Take them home",
        "Scrub the dirt and rinse the suds",
        "Paint a masterpiece",
        "Cry at things",
        
        //Chorus
        "Do a flip and shoot sea gulls",
        "Sort the mail",
        "Climb the mountain",
        "Stay on the road and avoid rocks",
        
        //Verse 3
        "Hit those notes",
        "Tune the radio",
        "Drive home",
        "Pick the correct day to be home",
        
        //Chorus
        "Do a flip and shoot sea gulls",
        "Sort the mail",
        "Climb the mountain",
        "Stay on the road and avoid rocks",
        
        //Chorus
        "Do a flip and shoot sea gulls",
        "Sort the mail",
        "Climb the mountain",
        "Stay on the road and avoid rocks",
        
        //Outro / Credits
        "Take me home, down country roads"
    };

    //flags for being ENABLED in this order: L R U D A B
    private bool[][] buttonStates =
    {
        //Verse 1
        new []{false, false, false, false, true,  false },
        new []{true,  true,  false, false, true,  false },
        new []{true,  true,  false, false, true,  false },
        new []{true,  true,  false, false, false, false },

        //Chorus
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{true,  true,  false, false, false, false },
        
        //Verse 2
        new []{false, false, false, false, false, false },//
        new []{true,  true,  true,  true,  false, false },
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        
        //Chorus
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{true,  true,  false, false, false, false },
        
        //Verse 3
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{true,  true,  false, false, false, false },
        new []{false, false, false, false, false, false },//
        
        //Chorus
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{true,  true,  false, false, false, false },
        
        //Chorus
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{false, false, false, false, false, false },//
        new []{true,  true,  false, false, false, false },
        
        //Outro / Credits
        new []{false, false, false, false, false, false },
    };

    //Might need to do this in inspector, needs 29 clips (so size 28)
    public AudioClip[] songClips =
    {
        //Verse 1
        
        //Chorus
                
        //Verse 2
                
        //Chorus
                
        //Verse 3
                
        //Chorus
                
        //Chorus
                
        //Outro / Credits
    };

    public bool[] success =
    {
        //Verse 1
        false,
        false,
        false,
        false,
        
        //Chorus
        false,
        false,
        false,
        false,
                
        //Verse 2
        false,
        false,
        false,
        false,
                
        //Chorus
        false,
        false,
        false,
        false,
                
        //Verse 3
        false,
        false,
        false,
        false,
                
        //Chorus
        false,
        false,
        false,
        false,
                
        //Chorus
        false,
        false,
        false,
        false,
                
        //Outro / Credits
        true
    };    
}
