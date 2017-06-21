using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassSkew : BillBoardGo {

    float animationOffset;

    void Start() {
        //animationOffset = Random.Range(8, 15);
        GetComponent<Animator>().SetFloat("offset", Random.Range(0, 1));
        GetComponent<Animator>().SetBool("mirror", Random.Range(0, 2) > 0.5f);

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

        MyCameraTransform = Camera.main.transform;
        //float rotate =  Mathf.Sin(randomStart + Time.time * 4) * 6 - 3;

        Quaternion lookAtCamera = Quaternion.LookRotation(MyCameraTransform.position);

        //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, rotate);
    }
}
