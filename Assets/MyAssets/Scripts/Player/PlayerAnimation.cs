using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    private Animator _playrAnimator;

    private void Start() {
        _playrAnimator = GetComponentInChildren<Animator>();

        if (_playrAnimator == null) {
            Debug.LogWarning("El jugador no tiene animator");
            }
        }

    public void SetSpeed(float speed) {
        _playrAnimator.SetFloat("Speed", speed);
        }
    }
