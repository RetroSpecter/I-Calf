using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStatecontroller : MonoBehaviour {

    public int targetLayer;

    public void changeAnimation(int layer) {
        targetLayer = layer;
    }

    public void playAnimation(string state) {
        GetComponent<Animator>().Play(state, targetLayer);
    }
}