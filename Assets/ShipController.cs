using UnityEngine;

public class ShipController : MonoBehaviour {
    public GameObject _bulletEmitter;
    public GameObject _bulletPrefab;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f;
        //The distance between the camera and object
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        var angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //Correct by 90
        var ShipRotation = new Vector3 (0, 0, angle - 90);
        Quaternion bulletRotation = Quaternion.Euler (ShipRotation);
        transform.rotation = bulletRotation;
        Debug.DrawRay(transform.position, ShipRotation, Color.green);
        if(Input.GetKeyDown(KeyCode.Space)){
            //Shoot a bullet
            var bullet = (GameObject) Instantiate(_bulletPrefab, _bulletEmitter.transform.position, transform.rotation);
            Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
            Rigidbody2D shipRigid = GetComponent<Rigidbody2D>();
            var force = mouse_pos.normalized * 20;
            body.AddForce(force);
            shipRigid.AddForce(-force);
        }
    }
}
