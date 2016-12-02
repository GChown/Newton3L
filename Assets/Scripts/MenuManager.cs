using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void NewGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirstLevel");
    }
    public void Quit(){
        Application.Quit();
    }
    public void Credits(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScene");
    }
    public void MainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

    }
}
