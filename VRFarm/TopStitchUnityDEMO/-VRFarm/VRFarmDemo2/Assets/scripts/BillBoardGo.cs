using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardGo : MonoBehaviour {

    public Transform MyCameraTransform;
    protected Transform MyTransform;
    public bool alignNotLook = true;

    void Start() {
        MyTransform = this.transform;
        MyCameraTransform = Camera.main.transform;
    }

    void LateUpdate() {
        if (alignNotLook)
            MyTransform.forward = MyCameraTransform.forward;
        else
            MyTransform.LookAt(MyCameraTransform, Vector3.up);
    }
}
