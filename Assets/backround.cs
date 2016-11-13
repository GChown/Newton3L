using UnityEngine;
using System.Collections;

public class backround : MonoBehaviour {
	public GameObject space;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 p = Camera.main.transform.position;
		p.z = -18;
		transform.position = p;
	}
}
