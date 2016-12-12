using UnityEngine;
using System.Collections;

public class EnemyLookAt : MonoBehaviour {
    public GameObject looker;
    public GameObject _bulletEmitter;
    public GameObject _bulletPrefab;
    float timeToShoot;
	void Start () {
        timeToShoot = 100f; 
    }

	void Update () {
		timeToShoot -= 1f;
        if(looker != null){
        Vector3 ship_pos = Camera.main.WorldToScreenPoint(looker.transform.position);
        ship_pos.z = 5.23f;
        //The distance between the camera and object
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        ship_pos.x = ship_pos.x - object_pos.x;
        ship_pos.y = ship_pos.y - object_pos.y;
        var angle = Mathf.Atan2(ship_pos.y, ship_pos.x) * Mathf.Rad2Deg;

        //Correct by 90
        var ShipRotation = new Vector3 (0, 0, angle - 90);
        Quaternion shipRotation = Quaternion.Euler (ShipRotation);
        transform.rotation = shipRotation;
        
		//Correct by 90
        
            if(Time.time >= timeToShoot){
                //Shoot a bullet
                var bullet = (GameObject) Instantiate(_bulletPrefab, _bulletEmitter.transform.position, transform.rotation);
                Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
                Destroy(bullet, 5f);
                var force = ship_pos.normalized * 200;
                body.AddForce(force);
                //To add backwards force to enemy ship
                //Rigidbody2D shipRigid = GetComponent<Rigidbody2D>();
				//shipRigid.AddForce(-(ship_pos.normalized * 70));
                timeToShoot = Time.time + (50f / Time.timeScale);
            }
        }
	}
}
