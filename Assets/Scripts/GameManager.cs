using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject _pauseDisplay;
    public static bool paused;
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
        }else if(!paused){
            if(Input.GetKey(KeyCode.Space)){
                Time.timeScale = 1f;
            }else{
                Time.timeScale = 0.1f;
            }
        }
    }
}
