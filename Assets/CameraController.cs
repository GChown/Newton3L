using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject _target;

	// Use this for initialization
	void Start () {
        transform.transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {
	
        transform.transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.transform.position.z);
	}
}
