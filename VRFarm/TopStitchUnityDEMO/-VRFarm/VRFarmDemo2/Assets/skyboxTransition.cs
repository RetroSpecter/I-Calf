using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class skyboxTransition : MonoBehaviour {

    public Material skyboxMat;

    [Range(0, 10)] public float transition;
    public Color colorTint;

    // Use this for initialization
    void Start () {
        startup();
    }

	// Update is called once per frame
	void Update () {
        if (!Application.isPlaying) {
            startup();
        }
        skyboxMat.SetFloat("_Exposure", transition);
        skyboxMat.SetColor("_Tint", colorTint);
    }

    public void startup() {
        skyboxMat = RenderSettings.skybox;
    }
}
