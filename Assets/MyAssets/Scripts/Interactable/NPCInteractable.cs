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

    public override void Interact()
    {
        //base.Interact();    // Es lo mismo que llamar al método padre
        //Debug.Log("10.- Interactuando con un NPC");
        _dialogueController.setDialogue(_name, _dialogue);
        if(_mision != null) {
            string tituloM = _mision.GetTitulo();
            string descripcionM = _mision.GetDescripcion();

            _missionController.setNuevaMision(tituloM, descripcionM);
            }
        else {
            Debug.Log("NPC no tiene misión asignada");
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
        }
}
