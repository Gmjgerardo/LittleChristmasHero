using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI contador;
    private bool _continuar = false;

    #region Variables para controlar la ejecución del update cada segundo
    private float _nextActionTime = 0.0f;    // En que momento se ejecutara por primera vez (1f despues de un segundo)
    [SerializeField]
    private float _period = 1f; // Cada segundo se actualizara
    #endregion

    #region Variables para controlar el tiempo de actualizado de la UI
    private float segundos = 01f;
    private float minutos = 10f;
    #endregion

    private void Start() {
        contador.text = "00:00";
        _continuar = true;
        }

    private void Update() {
        if(_continuar) {
            ActualizarReloj();
            }
        }

    private void ActualizarReloj() {
        // Si el tiempo transcurrido es mayor al tiempo en el que se debe ejecutar la siguiente acción
        if (Time.time > _nextActionTime) {
            _nextActionTime += _period; // Calculo del tiempo de la siguiente ejecución

            #region Actualización de la UI del reloj
            segundos--;
            contador.text = minutos.ToString("00") + ":" + segundos.ToString("00");
            if (segundos == 0) {
                minutos -= 1f;
                segundos = 60f;
                }
            }
        #endregion
    }
}
