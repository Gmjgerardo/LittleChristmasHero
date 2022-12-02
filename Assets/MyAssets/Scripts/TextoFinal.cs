using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextoFinal : MonoBehaviour {
    private TextMeshProUGUI _finalTMP;
    #region Variables para controlar el tiempo de actualizado de la UI
    private float nextActionTime = 0.0f;    // En que momento se ejecutara por primera vez (1f despues de un segundo)
    [SerializeField]
    private float period = 1f; // Cada segundo se actualizara
    #endregion
    private void Start() {
        _finalTMP = GetComponent<TextMeshProUGUI>();

        if(_finalTMP == null) {
            Debug.LogError("Hubo un error al intentar encontrar el componente TMP");
            }
        }

    private void Update() {
        if (Time.time > nextActionTime) {
            nextActionTime += period;
            _finalTMP.color = Random.ColorHSV();
            }
    }
}
