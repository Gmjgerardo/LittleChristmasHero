using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Transportador : Interactable {
    [SerializeField]
    private UnityEvent _ejecutarEscena;

    public override void Interact() {
        _ejecutarEscena.Invoke();
        }

    private void Start() {
        var foundCanvasObjects = FindObjectsOfType<Mision>();
        Debug.Log(foundCanvasObjects.Length);
        }
}
