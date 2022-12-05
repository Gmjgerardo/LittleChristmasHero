using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Clase para las misiones de encontrar
public class ObjectiveInteractable : Interactable {
    [SerializeField]
    private Mision _mision;
    [SerializeField]
    private Mesh _regaloAbierto;
    [SerializeField]
    private UnityEvent _accionFinalizar;

    private GameObject objetoPadre;
    private MissionController _missionController;

    public override void Interact() {
        // Verifica que la misión estuviera activada (Completar misión)
        if(_mision.GetEstado() == 1) {
            AbrirCajaMision();

            Invoke(nameof(MostrarObjetoMision), 3);

            if (_mision.GetDesencadena() != null) {
                Invoke(nameof(DesencadenarMision), 5);
                }

            // Ejecutar la acción/disparador de terminado en caso de tener una
            if (_accionFinalizar.GetPersistentEventCount() > 0)
                _accionFinalizar.Invoke();

            _missionController.BorrarMision(_mision.GetIndicacion());
            }
        }

    private void AbrirCajaMision() {
        _mision.CompletarMision();
        transform.GetComponent<MeshFilter>().mesh = _regaloAbierto;
        }

    private void MostrarObjetoMision() {
        transform.GetComponent<MeshRenderer>().enabled = false; // Desactivar objeto caja
        objetoPadre.GetComponent<MeshRenderer>().enabled = true;    // Activar objeto deseado

        // Hacer "volar" a los renos
        Invoke(nameof(DesaparecerObjetoMision), 1.5f);
        }

    private void DesaparecerObjetoMision() {
        objetoPadre.SetActive(false);
        }

    private void DesencadenarMision() {
        Mision misionContinua = _mision.GetDesencadena();
        _missionController.SetNuevaMision(misionContinua);
        _missionController.FinalizoDialogo();
        }

    private void Start() {
        _missionController = FindObjectOfType<MissionController>();
        objetoPadre = this.transform.parent.gameObject;
        }

    private void Update() {
        if(_mision.GetEstado() == 2) {
        transform.Rotate(100f * Time.deltaTime * Vector3.up);
            }
        }
}
