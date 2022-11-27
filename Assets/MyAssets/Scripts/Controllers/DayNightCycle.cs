using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    [SerializeField]
    private Material skybox;
    [SerializeField]
    private float rotationScale = 2.5f;

    private float _elapsedTime = 0f;
    private static readonly int Rotation = Shader.PropertyToID("_Rotation");
    private static readonly int Exposure = Shader.PropertyToID("_Exposure");

    void Update() {
        _elapsedTime += rotationScale * Time.deltaTime;
        skybox.SetFloat(Rotation, _elapsedTime * rotationScale);
        //skybox.SetFloat(Exposure, Mathf.Clamp(Mathf.Sin(_elapsedTime), 0.15f, 1f));
        transform.Rotate(rotationScale * Time.deltaTime, 0, 0);
        }
    }
