using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MissionController : MonoBehaviour {
    [SerializeField]
    private GameObject _missionsPnl, _nuevaMisionPnl;

    #region Componentes dentro del panel
    private TextMeshProUGUI __misionesTMP, _tituloTMP, _descripcionTMP;
    private Button _cerrarBtn, _aceptarBtn;
    #endregion

    #region Componentes de la misión
    private Mision _mision;
    private string _listaMisiones = "";
    #endregion

    private void Start() {
        // "Suscribir" a la función finalizoDialogo al evento llamado generado por dialoguecontroller
        DialogueController.OnFinishDialogue += FinalizoDialogo;

        if (_missionsPnl == null) {
            Debug.LogError("No se arrastro el panel de misiones");
            }

        __misionesTMP = _missionsPnl.transform.GetComponentInChildren<TextMeshProUGUI>();

        // NewMissionPanel = GetChild(2)
        //_nuevaMisionPnl = _missionsPnl.transform.GetChild(2).gameObject;
        _tituloTMP = _nuevaMisionPnl.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _descripcionTMP = _nuevaMisionPnl.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _aceptarBtn = _nuevaMisionPnl.transform.GetChild(4).GetComponent<Button>();
        _cerrarBtn = _nuevaMisionPnl.transform.GetChild(3).GetComponent<Button>();

        #region Verificacion de la obtencion de los TMP y botones
        if (__misionesTMP == null) {
            Debug.LogWarning("No hay TMP hijo del panel de misiones");
            }

        if (_tituloTMP == null) {
            Debug.LogWarning("No hay TMP hijo del panel de nueva misión, o estan mal ordenados");
            }

        if (_descripcionTMP == null) {
            Debug.LogWarning("No hay TMP hijo del panel de nueva misión, o estan mal ordenados");
            }
        if(_aceptarBtn == null || _cerrarBtn == null) {
            Debug.LogWarning("Checa los botones");
            }
        else {
            _aceptarBtn.onClick.AddListener(delegate { AceptarMision(); });
            _cerrarBtn.onClick.AddListener(delegate { CerrarPanelNuevaMision(); });
        }
        #endregion
        }

    // Función se activa cuando se termina el dialogo con un NPC cualquiera
    public void FinalizoDialogo() {
        // Mientras haya una misión cargada en el controlador y que no haya sido terminada
        if(_mision != null && _mision.GetEstado() != 3)
            _nuevaMisionPnl.SetActive(true);
        }

    public void SetNuevaMision(Mision mision) {
        _mision = mision;

         // Si la misión ya fue aceptada
        if(_mision.GetEstado() == 1) {
            TextMeshProUGUI headerTMP = _nuevaMisionPnl.GetComponentInChildren<TextMeshProUGUI>();
            _aceptarBtn.transform.GetComponentInChildren<TextMeshProUGUI>().text = "Listo";
            headerTMP.text = "MISION";
            }

        _tituloTMP.text = _mision.GetTitulo();
        _descripcionTMP.text = _mision.GetDescripcion() + "\nPista: " + _mision.GetPista();
        }

    private void AceptarMision() {
        if(_mision.GetEstado() == 0) {
            // Añadir una linea mas a la "lista" de misiones activas
            _listaMisiones += _mision.GetIndicacion() + "\n";

            __misionesTMP.text = _listaMisiones; // Cambiar el texto en la UI

            // Cambiar estado de la misión
            _mision.SetEstado(1);
            }

        CerrarPanelNuevaMision();
        }

    public void BorrarMision(string mBorrar) {
        string[] misiones = _listaMisiones.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        Debug.Log("Se encontraron " + misiones.Length + " Misiones");
        _listaMisiones = "";

        foreach(string mision in misiones) {
            if(mision != "\n" && mision != mBorrar)
                _listaMisiones += mision + "\n";
                }

        __misionesTMP.text = _listaMisiones;
    }

    private void CerrarPanelNuevaMision() {
        _nuevaMisionPnl.SetActive(false);
        _mision = null;
        }

    // Eliminar referencia al evento cuando se destruye o desactiava el objeto
    private void OnDisable() {
        DialogueController.OnFinishDialogue -= FinalizoDialogo;
        }
    }
