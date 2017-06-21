using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class groupSpriteRenderer : MonoBehaviour {

    [Range(0, 1)] public float opacity;
    SpriteRenderer[] sprites;

    void Start() {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update() {
        if (!Application.isPlaying) {
            sprites = GetComponentsInChildren<SpriteRenderer>();
        }

        foreach (SpriteRenderer rend in sprites) {
            Color curr = rend.color;
            curr.a = opacity;
            rend.color = curr;
        }
    }
}
