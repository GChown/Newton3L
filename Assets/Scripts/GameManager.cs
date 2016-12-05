using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject _pauseDisplay;
    bool paused;
    // Use this for initialization
    void Start () {
        _pauseDisplay.SetActive(false); 
        paused = false;
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!paused){
                _pauseDisplay.SetActive(true); 
                paused = true;
                //Time.time = 0f;
                Time.timeScale = 0f;
            }else{
                _pauseDisplay.SetActive(false); 
                paused = false;
                Time.timeScale = 1f;
            }
        }
    }
}
