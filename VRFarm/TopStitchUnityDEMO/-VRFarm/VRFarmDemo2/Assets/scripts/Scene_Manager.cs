using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class Scene_Manager : MonoBehaviour {

    public AudioClip[] test;
    public GameObject currentScene;
    public GameObject[] scenes;
	public GameObject sceneCamera;

    public Material testSkybox;

    void Start() {
        //playNarration(test[0]);
        StartCoroutine(screenFade.instance.fade(true, 0.5f));
        //StartCoroutine(fadeBetweenScenesCor(0.5f, 1));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Animator>().SetTrigger("skip");
        }

        //if (Input.GetKeyDown(KeyCode.P)) { RenderSettings.skybox = testSkybox; }
    }

    public void setSkybox(Material skybox) {
        RenderSettings.skybox = skybox;
    }

    public void D1_Position() {
        sceneCamera.transform.position  = new Vector3(-2.43f, 1.53f, 1.3f);
    }

    public void PositionReset() {
        fadeBetweenPositions(new Vector3(-0.22f, 0.14f, -5.69f));
    }

    public void DebugPositionReset() {
		sceneCamera.transform.position = new Vector3(-0.22f, 0.14f, -5.69f);
    }

    public void fadeToBlack() {
        StartCoroutine(screenFade.instance.fade(false, 0.5f));
    }

    public void fadeBetweenPositions(Vector3 newPosition) {
        StartCoroutine(screenFade.instance.fadeBetween(1, newPosition));
    }

    public void fadeBetweenScenes(int sceneIndex) {
        StartCoroutine(fadeBetweenScenesCor(1, sceneIndex));
    }

    public void jumpBetweenScenes(int sceneIndex) {
        currentScene.SetActive(false);
        currentScene = scenes[sceneIndex];
        currentScene.SetActive(true);
    }

    public void toggleDreamEffects() {
		//sceneCamera.GetComponentInChildren<Bloom>().enabled = !sceneCamera.GetComponent<Bloom>().enabled;
        //Camera.main.GetComponent<VignetteAndChromaticAberration>().enabled = !Camera.main.GetComponent<VignetteAndChromaticAberration>().enabled;
    }

    public IEnumerator fadeBetweenScenesCor(float time, int sceneIndex) {
        //yield return screenFade.instance.fade(false, time * 2);
        currentScene.SetActive(false);
        currentScene = scenes[sceneIndex];
        currentScene.SetActive(true);
        yield return null;
        //yield return screenFade.instance.fade(true, time * 2);
    }

    public void playNarration(AudioClip narration) {
        audioManager.instance.Play(narration);
    }
}
