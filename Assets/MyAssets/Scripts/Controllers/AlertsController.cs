using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class AlertsController : MonoBehaviour {
    [SerializeField]
    private GameObject _alertsPnl;
    private UnityEvent _agreeAction;

    #region Componentes dentro del panel
    private TextMeshProUGUI _alertaTMP;
    private Button _cerrarBtn, _aceptarBtn;
    #endregion

    private Clock _clockController;

    private void Start() {
        if (_alertsPnl == null) {
            Debug.LogError("No se arrastro el panel de alertas");
            }

        _clockController = FindObjectOfType<Clock>();
        PreservarInformacion info = FindObjectOfType<PreservarInformacion>();


        if (_clockController != null) {
            _agreeAction = new UnityEvent();
            _agreeAction.AddListener(_clockController.CambiarEstado);
            }

        _alertaTMP = _alertsPnl.transform.GetComponentInChildren<TextMeshProUGUI>();
        _cerrarBtn = _alertsPnl.transform.GetChild(2).GetComponent<Button>();
        _aceptarBtn = _alertsPnl.transform.GetChild(3).GetComponent<Button>();

        _aceptarBtn.onClick.AddListener(delegate { AgreeAction(); });
        _cerrarBtn.onClick.AddListener(delegate { CloseAlert(); });

        if(info != null) {
            if(info.GetContinuarReloj()) {
                CloseAlert();
                }
            }
        }

    public void ShowAlert(string mensaje, UnityEvent agreefuncion = null) {
        // Verificar que haya una acción aceptar agregada (función) agreefuncion.GetPersistentEventCount() > 0
        if (agreefuncion != null) {
            _agreeAction = agreefuncion;
            _aceptarBtn.gameObject.SetActive(true);
            }

        _alertaTMP.text = mensaje;
        _alertsPnl.SetActive(true);
        }

    public void CloseAlert() {
        _agreeAction = null;
        _alertsPnl.SetActive(false);
        _cerrarBtn.gameObject.SetActive(true);
        }

    public void AgreeAction() {
        if (_agreeAction != null)
            _agreeAction.Invoke();

        _aceptarBtn.gameObject.SetActive(false);
        CloseAlert();
        }
    }
