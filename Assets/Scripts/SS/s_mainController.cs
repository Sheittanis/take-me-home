using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_mainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void StartGame()
    {
        GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().lastScene = "Main";
        SceneManager.LoadScene(2); //After main menu and scene select
    }

	public void Credits()
    {
        GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().lastScene = "Main";
        SceneManager.LoadScene("Credits");
	}

    public void SceneSelect()
    {
        GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>().lastScene = "Main";
        SceneManager.LoadScene("SceneSelect");
    }

    public void QuitGame(){
		Application.Quit();
	}
}
