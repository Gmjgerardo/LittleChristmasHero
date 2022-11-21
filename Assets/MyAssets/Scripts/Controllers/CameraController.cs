using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    #region Variables Principales
    [SerializeField]
    private Transform _Player, _PlayerCamera, _focusPoint;

    [SerializeField]
    private float _cameraHeight = 1f;
    #endregion

    #region Acercamiento c�mara
    [SerializeField]
    private float _zoom = -5f, _zoomSpeed = 4f;
    [SerializeField]
    private float _zoomMax = 0, _zoomMin = -20;
    #endregion

    #region Movimiento c�mara
    [SerializeField]
    private float _camRotx, _camRotY; // YAW, PITCH
    [SerializeField]
    private float _cameraSensitivity = 2f;
    #endregion

    private void Start() {
        #region Revisar asignaciones
        if (_Player == null) {
            Debug.LogWarning("EL jugador no se asign� al controlador de c�mara");
            }
        if (_PlayerCamera == null) {
            Debug.LogWarning("La c�mara no se asigno al controlador");
            }
        if (_focusPoint == null) {
            Debug.LogWarning("El punto de pivote no se asigno al controlador");
            }
        #endregion
        #region Asignar parentesco
        _PlayerCamera.SetParent(_focusPoint);
        _focusPoint.SetParent(_Player);
        #endregion
        #region Inicializar posici�n y rotaci�n
        _focusPoint.localPosition = new Vector3(0,_cameraHeight, 0);
        _focusPoint.localRotation = Quaternion.Euler(0, 0, 0);
        _PlayerCamera.localPosition = new Vector3(0, 0, _zoom);
        _PlayerCamera.LookAt(_Player);
        #endregion
        }

    private void Update() {
        #region acercamiento
        _zoom += Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        _zoom = Mathf.Clamp(_zoom, _zoomMin, _zoomMax);
        _PlayerCamera.localPosition = new Vector3(0, 0, _zoom);
        _PlayerCamera.LookAt(_Player);
        #endregion

        #region Movimiento c�mara
        if(Input.GetMouseButton(0)) // Mientras este presionado el b�ton
        {
            _camRotx += Input.GetAxis("Mouse X") * _cameraSensitivity;  // Yaw
            _camRotY += Input.GetAxis("Mouse Y") * _cameraSensitivity;  // Pitch

            _focusPoint.localRotation = Quaternion.Euler(_camRotY, 0, 0);
            _Player.localRotation = Quaternion.Euler(0, _camRotx, 0);
            }
        #endregion
        }
    }
