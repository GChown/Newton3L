using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {
    public GameObject _target;

    // Use this for initialization
    void Start () {
        Vector2 offset = _target.transform.position.normalized;
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }

    // Update is called once per frame
    void Update () {
        Vector2 targetPos = _target.transform.position;
        Vector2 offset = Camera.main.ScreenToWorldPoint(targetPos).normalized;
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
    }
}
