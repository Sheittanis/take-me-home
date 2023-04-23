using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSelect : MonoBehaviour {

	public void Level(int chosen_)
    {
        ImmortalManager IM = GameObject.Find("Immortal Manager").GetComponent<ImmortalManager>();
            
        IM.lastScene = "SceneSelect";

        SceneManager.LoadScene(chosen_ + IM.offset - 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main");
    }
}
