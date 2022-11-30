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
    private string _tituloMision, _descripcionMision;
    private List<string> _listaMisiones = new List<string>();
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
            _aceptarBtn.onClick.AddListener(delegate { aceptarMision(); });
            _cerrarBtn.onClick.AddListener(delegate { cerrarPanelNuevaMision(); });
        }
        #endregion


        }

    public void setNuevaMision(string title, string description) {
        _tituloMision = title;
        _descripcionMision = description;

        _tituloTMP.text = _tituloMision;
        _descripcionTMP.text = _descripcionMision;
        _nuevaMisionPnl.SetActive(true);
        }

    private void aceptarMision() {
        string misionesStr = "";
        // Inicializar elmentos/objetos relacionados a la misión (renos)
        
        _listaMisiones.Add(_tituloMision);

        foreach(string mision in _listaMisiones) {
            misionesStr += mision + "\n";
            }

        __misionesTMP.text = misionesStr;
        cerrarPanelNuevaMision();
        }

    private void cerrarPanelNuevaMision() {
        _nuevaMisionPnl.SetActive(false);
        }

    }
