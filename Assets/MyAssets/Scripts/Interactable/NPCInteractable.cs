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

    public override void Interact()
    {
        //base.Interact();    // Es lo mismo que llamar al método padre
        //Debug.Log("10.- Interactuando con un NPC");
        _dialogueController.setDialogue(_name, _dialogue);
    }

    private void Start()
    {
        // Aplicar a singletons unicamente
        _dialogueController = FindObjectOfType<DialogueController>();

        if(!_dialogueController)
        {
            Debug.LogError("La escena no tiene un dialogue controller");
        }
    }
}
