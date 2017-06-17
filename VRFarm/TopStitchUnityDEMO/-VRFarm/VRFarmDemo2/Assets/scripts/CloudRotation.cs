using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRotation : MonoBehaviour {

    public float speed;
    public bool vertical = false;

    void LateUpdate() {
        if (vertical)
        {
            transform.Rotate(0, speed, 0);
        }
        else {
            transform.Rotate(speed, 0, 0);
        }
    }
}
