using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Mision", menuName = "Mision")]

public class InfoMision : ScriptableObject {
    [SerializeField]
    private string titulo, descripcion;

    public string GetTitulo() {
        return titulo;
        }
    public string GetDescripcion() {
        return descripcion;
        }
    }
