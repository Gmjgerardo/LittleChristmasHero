using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables Movimiento
    [SerializeField]
    private float _MovementSpeed = 5f;

    // Sirve para mostrar las variables en el inspector
    [SerializeField]
    private float _horizontalInput, _fowardInput;
    #endregion

    #region Variables Brinco
    [SerializeField]
    private bool _jumpRequest = false;

    [SerializeField]
    private float _jumpForce = 7f;

    [SerializeField]
    private int _maxJumps = 4, _availableJumps = 0;
    #endregion

    private Rigidbody _playerRB;

    //private PlayerAnimation _playerAnimation;

    private bool _isRunnning = false;
    private float _maxMovementSpeed = 10f;

    private void Start() {
        #region Obtener Rigidbody
        _playerRB = GetComponent<Rigidbody>();
        if (_playerRB == null) {
            Debug.LogWarning("El jugador es gasparin! (atraviesa todo)");
            }
        #endregion
        #region Obtener Animacion
        //_playerAnimation = GetComponent<PlayerAnimation>();

        //if (_playerAnimation == null)
        //{
        //    Debug.LogWarning("El jugador no tiene un controlador de animaci?n");
        //}
        #endregion

        if (_isRunnning) {
            _MovementSpeed = _maxMovementSpeed;
            }
        else {
            _MovementSpeed = _maxMovementSpeed * 0.4f;
            }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            _isRunnning = !_isRunnning;
            if (_isRunnning) {
                _MovementSpeed = _maxMovementSpeed;
                }
            else {
                _MovementSpeed = _maxMovementSpeed * 0.4f;
                }
            }

        #region Movimiento
        _horizontalInput = Input.GetAxis("Horizontal");
        _fowardInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_horizontalInput, 0, _fowardInput); //Y: Izquierda y derecha Z: Adelante
        transform.Translate(movement * Time.deltaTime * _MovementSpeed);
        float velocity = Mathf.Max(Mathf.Abs(_horizontalInput), Mathf.Abs(_fowardInput));
        velocity *= _MovementSpeed / _maxMovementSpeed;
//        _playerAnimation.setSpeed(velocity);
        #endregion
        #region Peticion Brinco
        if (Input.GetKeyDown(KeyCode.Space) && _availableJumps > 0) {
            _jumpRequest = true;
            }
        #endregion
        }

    private void FixedUpdate() {
        #region Brinco
        // Generalmente se dejan cosas de fisica
        if (_jumpRequest) {
            _availableJumps--;
            _playerRB.velocity = Vector3.up * _jumpForce;
            _jumpRequest = false;
            }
        #endregion
        }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.CompareTag("Ground")) {
            _availableJumps = _maxJumps;
            }
        }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Interactable")) {
            Interactable interacted = other.GetComponent<Interactable>();
            if (interacted == null) {
                Debug.Log("EL objeto no tiene script para interactuar");
                }
            else {
                interacted.Interact();
                }
            }
        }
    }
