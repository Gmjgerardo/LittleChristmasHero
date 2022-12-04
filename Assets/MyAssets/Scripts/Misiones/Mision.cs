using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Mision", menuName = "Mision")]

public class Mision : ScriptableObject {
    [SerializeField]
    private string titulo, descripcion, indicacion;
    [SerializeField]
    private int _estadoMision = 0; // 0: No encontrada, 1: Aceptada, 2: Terminada
    [SerializeField]
    private Mision _activaMision;

    private void OnEnable() {
        _estadoMision = 0;
        }

    public string GetTitulo() {
        return titulo;
        }
    public string GetDescripcion() {
        return descripcion;
        }

    public string GetIndicacion() {
        return indicacion;    
        }

    public int GetEstado() {
        return _estadoMision;
        }

    public Mision GetDesencadena() {
        return _activaMision;
        }

    public void CompletarMision() {
        // Marcar misión como terminada
        _estadoMision = 2;
        }

    public void SetEstado(int estado) {
        _estadoMision = estado;
        }
    }
