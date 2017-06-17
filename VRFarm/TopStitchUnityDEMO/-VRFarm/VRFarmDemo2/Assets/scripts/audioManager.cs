using UnityEngine;
using System.Collections;

public class audioManager : MonoBehaviour {

    private AudioSource source;
    public AudioClip soundFX;
    public static audioManager instance;

    void Awake() {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip sound) {
        Play(sound, 0.75f, 1);
    }

    public void Play(AudioClip sound, float volume) {
        Play(sound, volume, 1);
    }

    public void Play(AudioClip sound, float volume, float pitch) {
        source.clip = sound;
        source.volume = volume;
        source.volume = pitch;
        source.PlayOneShot(sound);
    }
}
