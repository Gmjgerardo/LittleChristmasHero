using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveInteractable : Interactable {
    [SerializeField]
    private InfoMision _mision;
    [SerializeField]
    private Mesh _regaloAbierto;

    private GameObject objetoPadre;
    private MissionController _missionController;

    public override void Interact() {
        if(_mision.GetEstado() == 2) { 
            Debug.Log("Completaste la misión");
            //objetoPadre.SetActive(false);
            AbrirCajaMision();

            Invoke(nameof(MostrarObjetoMision), 3);
            }
        }

    private void AbrirCajaMision() {
        _mision.CompletarMision();
        transform.GetComponent<MeshFilter>().mesh = _regaloAbierto;
        }

    private void MostrarObjetoMision() {
        transform.GetComponent<MeshRenderer>().enabled = false; // Desactivar objeto caja
        objetoPadre.GetComponent<MeshRenderer>().enabled = true;    // Activar objeto deseado
        }

    private void Start() {
        _missionController = FindObjectOfType<MissionController>();
        objetoPadre = this.transform.parent.gameObject;
        Debug.Log(_mision.GetTitulo());
        }

    private void Update() {
        if(_mision.GetEstado() == 3) {
        transform.Rotate(30f * Time.deltaTime * Vector3.up);
            }
        }
}
