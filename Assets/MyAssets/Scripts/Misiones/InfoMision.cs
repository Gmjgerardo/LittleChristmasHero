using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Mision", menuName = "Mision")]

public class InfoMision : ScriptableObject {
    [SerializeField]
    private string titulo, descripcion;
    [SerializeField]
    private int _estadoMision = 0; // 1: Mostrar 2:Aceptada 3:Terminada 0: No mostrar/No aceptada

    private void OnEnable() {
        _estadoMision = 0;
        }

    public string GetTitulo() {
        return titulo;
        }
    public string GetDescripcion() {
        return descripcion;
        }

    public int GetEstado() {
        return _estadoMision;
        }

    public void CompletarMision() {
        _estadoMision = 3;
        }

    public void SetEstado(int estado) {
        _estadoMision = estado;
        }
    }
