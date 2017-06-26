using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassSkew : BillBoardGo {

    float animationOffset;

    float randomSway;
    float randomSpeed;


    void Start() {
        

        randomSway = Random.Range(0.25f, 4);
        randomStart = Random.Range(0,5);
        randomSpeed = Random.Range(1, 6);

        //animationOffset = Random.Range(8, 15);

        MyTransform = this.transform;
        MyCameraTransform = Camera.main.transform;

        if (alignNotLook)
            MyTransform.forward = MyCameraTransform.forward;
        else
            MyTransform.LookAt(MyCameraTransform, Vector3.up);


    }

    float randomStart;
    void LateUpdate() {

        //if (Time.time > animationOffset) {
        //animationOffset = Time.time + animationOffset * Random.Range(2, 4);
        //GetComponent<Animator>().Play("grass sway", 0, Random.Range(0.1f, 1));
        //}

        Vector3 skale = transform.localScale;

        //skale.x = Mathf.Sign(skale.x) * Mathf.Min(0.75f, Mathf.Abs(skale.x));
        //transform.localScale = skale;

        float rotate =  Mathf.Sin(randomStart + Time.time/randomSpeed) * randomSway - randomSway/2 ;

        Quaternion lookAtCamera = Quaternion.LookRotation(MyCameraTransform.position);

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, rotate);
    }
}
