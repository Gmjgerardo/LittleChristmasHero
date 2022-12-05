using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Clock : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI contador;

    #region Variables para controlar el tiempo de actualizado de la UI
    private float _nextActionTime = 0.0f;    // En que momento se ejecutara por primera vez (1f despues de un segundo)
    [SerializeField]
    private float _period = 1f; // Cada segundo se actualizara

    private float tiempo = 60f;
    #endregion

    private void Start() {
        contador.text = "00:" + tiempo;
        if (tiempo == 0)
        {
            SceneManager.LoadScene("GameOver");
        }


        //ActualizarClock(tiempo);
    }

    private void Update() {
        if (Time.time > _nextActionTime) {
            _nextActionTime += _period;
            tiempo--;
            contador.text = "00:" + tiempo.ToString("f0");
            if (tiempo == 0){
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
