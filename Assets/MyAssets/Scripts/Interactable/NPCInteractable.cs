using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private string[] _dialogue;     // Vector de strings
    private DialogueController _dialogueController;
    private MissionController _missionController;

    [SerializeField]
    private InfoMision _mision;
    private bool _estadoInteraccion = true;

    public override void Interact() {
        //base.Interact();    // Es lo mismo que llamar al método padre
        //Debug.Log("10.- Interactuando con un NPC");
        if(_estadoInteraccion) { 
            _dialogueController.SetDialogue(_name, _dialogue);
            _estadoInteraccion = false;
            } else { 
            _dialogueController.SetDialogue(_name, new string[] { "Nada nuevo..." });
            }

        if(_mision != null && _mision.GetEstado() == 0) {
            _mision.SetEstado(1); // Permite mostrar la misión de ese NPC
            }
        }

    // Función se activa cuando se termina el dialogo con un NPC cualquiera
    private void FinalizoDialogo() {
        if (_mision != null) {
            _missionController.SetNuevaMision(_mision);
            }
        }

    private void Start() {
        // Aplicar a singletons unicamente
        _dialogueController = FindObjectOfType<DialogueController>();
        _missionController = FindObjectOfType<MissionController>();

        if (!_dialogueController) {
            Debug.LogError("La escena no tiene un dialogue controller");
            }
        if (!_missionController) {
            Debug.LogError("La escena no tiene un controlador de misiones");
            }
        else {
            _dialogueController.OnFinishDialogue += FinalizoDialogo;
            }
        }

    // Eliminar referencia al evento cuando se destruye o desactiava el objeto
    private void OnDisable() {
        _dialogueController.OnFinishDialogue -= FinalizoDialogo;
    }
}
