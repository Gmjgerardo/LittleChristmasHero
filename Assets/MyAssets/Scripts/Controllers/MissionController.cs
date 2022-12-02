using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionController : MonoBehaviour {
    [SerializeField]
    private GameObject _missionsPnl, _nuevaMisionPnl;

    #region Componentes dentro del panel
    private TextMeshProUGUI __misionesTMP, _tituloTMP, _descripcionTMP;
    private Button _cerrarBtn, _aceptarBtn;
    #endregion

    #region Componentes de la misión
    private InfoMision _mision;
    private string _listaMisiones = "";
    #endregion

    void Start() {
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

    public void SetNuevaMision(InfoMision mision) {
        _mision = mision;

        if (_mision.GetEstado() > 0) {
            // En caso de ser nueva mision
            if(_mision.GetEstado() == 1)
                _mision.SetEstado(0); // Evitar que se muestre cuando se termina el dialogo con otro npc
            // Misión ya aceptada
            else {
                TextMeshProUGUI headerTMP = _nuevaMisionPnl.GetComponentInChildren<TextMeshProUGUI>();
                _aceptarBtn.transform.GetComponentInChildren<TextMeshProUGUI>().text = "Listo";
                headerTMP.text = "MISION";
                }

            _tituloTMP.text = _mision.GetTitulo();
            _descripcionTMP.text = _mision.GetDescripcion();
            _nuevaMisionPnl.SetActive(true);
            }
        }

    private void AceptarMision() {
        if(_mision.GetEstado() < 2) {
            // Añadir una linea mas a la "lista" de misiones activas
            _listaMisiones += _mision.GetTitulo() + "\n";

            __misionesTMP.text = _listaMisiones; // Cambiar el texto en la UI

            // Cambiar estado de la misión
            _mision.SetEstado(2);
        }

        CerrarPanelNuevaMision();
        }

    private void CerrarPanelNuevaMision() {
        _nuevaMisionPnl.SetActive(false);
        }

    }
