using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingLayer : MonoBehaviour {

    SpriteRenderer[] spriteRenderers;
    public int[] baseLayers;

    private void Start(){
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        baseLayers = new int[spriteRenderers.Length];

        for (int i = 0; i < baseLayers.Length; i++) {
            baseLayers[i] = spriteRenderers[i].sortingOrder;
        }

        StartCoroutine("sortLayerFromCamera");
    }

    IEnumerator sortLayerFromCamera() {
        while (true) {
            float distanceFromCamera = Vector3.Distance(Camera.main.transform.position, this.transform.position);

            for (int i = 0; i < baseLayers.Length; i++) {
                spriteRenderers[i].sortingOrder = baseLayers[i] - (int)distanceFromCamera;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}
