using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour {
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;


    private void Update() {
        if (Preset == null)
            return;

        if (Application.isPlaying) {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime * 0.01f;
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            }
        UpdateLighting(TimeOfDay / 24f);
        }


    private void UpdateLighting(float timePercent) {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null) {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
            }

        }

    // Al cargar el script o modificar sus variables en el inspector
    private void OnValidate() {
        if (DirectionalLight != null)
            return;

        // Agregar la posibilidad "sun" a la directional light de la escena
        if (RenderSettings.sun != null) {
            DirectionalLight = RenderSettings.sun;
            }
        // Encontrar la luz que sea direccional
        else {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights) {
                if (light.type == LightType.Directional) {
                    DirectionalLight = light;
                    return;
                    }
                }
            }
        }
    }