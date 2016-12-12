using UnityEngine;
using System.Collections;

public class BulletCollider : MonoBehaviour {
	public GameObject _explosionPrefab;
	public GameObject _bulletPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 5f);
	}

    void OnCollisionEnter2D(Collision2D coll) {
		if((coll.gameObject.tag == "enemy") || (coll.gameObject.tag == "player") || (coll.gameObject.tag == "bullet") || coll.gameObject.tag == "metior") {
			var explosion = Instantiate (_explosionPrefab,_bulletPrefab.transform.position,transform.rotation);
            //Destroy(explosion, 5f);
			Destroy(gameObject);
        }
    }
}
