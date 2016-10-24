using UnityEngine;
using System.Collections;

public class EnemyLookAt : MonoBehaviour {
    public GameObject looker;

	void Start () {}

	void Update () {
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
	}
}
