using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreservarInformacion : MonoBehaviour {
    private string _misiones;
    [SerializeField]
    private bool _continuarReloj;

    private void Start() {
        var objetosImportantes = Object.FindObjectsOfType<PreservarInformacion>();

        // Verificar cada objeto en la lista de importantes y destruir los repetidos en la nueva escena
        for(int i = 0 ; i < objetosImportantes.Length ; i++) {
            if(objetosImportantes[i] != this) {
                if(objetosImportantes[i].name == gameObject.name) {
                    Object.Destroy(gameObject);
                    }
                }
            }

        DontDestroyOnLoad(gameObject);
        }

    public void GuardarMisiones(string msj) {
        _misiones = msj;
        }

    public string GetMisiones() {
        return _misiones;
        }

    public void SetContinuar(bool c) {
        _continuarReloj = c;
        }

    public bool GetContinuarReloj() {
        return _continuarReloj;
        }
    }
