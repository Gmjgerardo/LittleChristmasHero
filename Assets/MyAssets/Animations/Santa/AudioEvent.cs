using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour {
    AudioSource _audio;
    private void Start() {
        _audio = GetComponent<AudioSource>();
        }

    private void SayHoHoHo() {
        _audio.Play();
        }
    }
