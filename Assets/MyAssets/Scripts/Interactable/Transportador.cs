using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Transportador : Interactable {
    private AlertsController _alertCtrl;
    [SerializeField]
    private UnityEvent _ejecutarEscena;
    [SerializeField]
    private string _destino;
    [SerializeField]
    private bool _activado = false;

    public override void Interact() {
        if(_activado)
            _alertCtrl.ShowAlert("¿Deseas viajar al " + _destino + "?", _ejecutarEscena);
        else
            _alertCtrl.ShowAlert("No puedes viajar en este momento, completas las misiones necesarias");
    }

    private void Start() {
        _alertCtrl = FindObjectOfType<AlertsController>();

        if (!_alertCtrl) {
            Debug.LogError("La escena no tiene un controlador de alertas");
            }
        }

    public void CambiarEstado() {
        _activado = !_activado;
        Debug.LogWarning("El estado ahora es: " + (_activado ? "Verdadero" : "Falso"));
        }
    }
