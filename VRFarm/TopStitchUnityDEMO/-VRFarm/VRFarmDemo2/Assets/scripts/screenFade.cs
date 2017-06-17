using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class screenFade : MonoBehaviour {


    public static screenFade instance;

    [Range(0, 1)] public float opacity;

    Material FadeMaterial;

    void Awake() {
        instance = this;
        FadeMaterial = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void Update() {
        Color currentColor = FadeMaterial.GetColor("_Color");
        FadeMaterial.SetColor("_Color", new Color(0, 0, 0, opacity));

        //if (Input.GetKeyDown(KeyCode.P)) { StartCoroutine(fadeBetween(1, transform.position)); }
    }

    public IEnumerator fadeBetween(float speed, Vector3 position) {
        //yield return fade(false, speed * 2);
        transform.position = position;
        yield return null;
        //yield return fade(true, speed * 2);
    }

    public IEnumerator fade(bool fadeIn, float speed) {
        float f = 0;
        while (f < 1) {
            f += Time.deltaTime * speed;
            opacity = fadeIn ? 1 - f : f;
            yield return null;
        }
        opacity = fadeIn ? 0 : 1;
    }
}
