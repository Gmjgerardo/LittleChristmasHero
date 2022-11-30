using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI contador;
    private float tiempo = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
        contador.text = "00:" + tiempo;
        
        //ActualizarClock(tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        tiempo--; ;
        contador.text = "00:" + tiempo.ToString("f0");
        if (tiempo == 0) tiempo = 60f;
        
    }
}
