using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class skyboxTransition : MonoBehaviour {

    public Material skyboxMat;

    [Range(0, 1)] public float transition;

    // Use this for initialization
    void Start () {
        startup();
    }

	// Update is called once per frame
	void Update () {
        if (!Application.isPlaying) {
            startup();
        }
        skyboxMat.SetFloat("_Blend", transition);
    }

    public void startup() {
        skyboxMat = RenderSettings.skybox;
    }
}
