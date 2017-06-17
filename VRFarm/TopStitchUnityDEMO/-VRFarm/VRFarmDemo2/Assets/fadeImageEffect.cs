using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class fadeImageEffect : MonoBehaviour {

    public Material TransitionMaterial;
    [Range(0, 1.1f)] public float opacity;

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        print("fart");
        TransitionMaterial.SetFloat("_opacity", opacity);
        Graphics.Blit(source, destination, TransitionMaterial); 
    } 
}
