using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueSpeak : MonoBehaviour {
    public float speed; //characters per second
    private string text;
    private int currentChar;
    public Text textBox;
    public string words;
    public RawImage Pic;
    public GameObject emitter;
	// Use this for initialization
	void Start () {
        talk(words);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = new Vector3(emitter.transform.position.x, emitter.transform.position.y, emitter.transform.position.z);
        position = Camera.main.WorldToScreenPoint(position);
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.Return) && emitter.activeSelf && currentChar < text.Length){
            textBox.text = text;
            currentChar = text.Length;
        }
	}

    public void talk(string text){
        emitter.SetActive(true);
        this.text = text;
        currentChar = 0;
        textBox.text = "";
        StartCoroutine(stepText());
    }

    IEnumerator stepText() {
        if(text.Length > currentChar){
            textBox.text += text[currentChar++];
            yield return new WaitForSeconds(1/speed);
            StartCoroutine(stepText());
        } else {
            yield return new WaitForSeconds(10);
            emitter.SetActive(false);
        }
    }
}
