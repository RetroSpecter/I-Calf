using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowScroll : MonoBehaviour {

    public float minSpeed, maxSpeed;
    float speed;

    private void Start() {
        speed = Random.Range(minSpeed,maxSpeed);
    }

    void Update () {
        transform.position += new Vector3(0, 0, speed);
	}
}
