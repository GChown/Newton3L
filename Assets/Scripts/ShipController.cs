using UnityEngine;

public class ShipController : MonoBehaviour {
    public GameObject _bulletEmitter;
    public GameObject _bulletPrefab;
    public GameObject _explosionPrefab;
    float timeToShoot;
	public Vector3 speed;
    public GameObject _status;
    private float health;

    // Use this for initialization
    void Start () {
        timeToShoot = 0f;
        //_status.SetActive(false);
        _status.gameObject.SetActive(false);
        health = 100f;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update () {
        
		timeToShoot -= 1f;
       
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
        
		if(Input.GetKey(KeyCode.Space)){
            if(timeToShoot <= 0f){
                //Shoot a bullet
                var bullet = (GameObject) Instantiate(_bulletPrefab, _bulletEmitter.transform.position, transform.rotation);
                Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
                var force = mouse_pos.normalized * 200;
                body.AddForce(force);
				//speed = -(mouse_pos.normalized * 50)
                Rigidbody2D shipRigid = GetComponent<Rigidbody2D>();
				shipRigid.AddForce(-(mouse_pos.normalized * 70));
                timeToShoot = 50f;
            }else{
                //Misfire animation?
            }
        }
        if(health <= 0){
            _status.SetActive(true);
            Time.timeScale = 0.5f;
			Instantiate (_explosionPrefab,transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "bullet") {
            health -= 20f;
        }
            health -= coll.rigidbody.velocity.magnitude * 5;
    }
    void OnGUI(){
        //position, float value, float size, float leftValue, float rightValue
        GUI.HorizontalScrollbar(new Rect(Screen.width / 2 - 32, Screen.height / 2 + 60, 75, 20), 0, health, 0, 100);
        //GUI.HorizontalScrollbar(new Rect(10, 40, 200, 40), 0, 100, 0, 100);
    }
}
