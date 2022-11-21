using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    #region Componentes del dialogo
    [Header("Panel de dialogos")]
    #pragma warning disable 0649
    [SerializeField]
    private GameObject _dialoguePnl;    // Asignado en inspector
#pragma warning restore 0649
    #endregion
    #region Componentes dentro del panel
    private TextMeshProUGUI _dialogueTMP, _nameTMP,_NextTMP;
    private Button _NextBtn;
    #endregion
    #region Componentes del NPC
    private string _name;
    private List<string> _dialogueList;
    private int _dialogueIdx;
    #endregion

    void Start()
    {
        #region comprobar asignacion del panel de dialogo
        if(_dialoguePnl == null)
        {
            Debug.LogError("No se arrastro el panel de dialogos al dialogueController (Script)");
        }
        #endregion
        #region Obtener Texto del dialogo
        // Primer hijo
        _dialogueTMP = _dialoguePnl.transform.GetComponentInChildren<TextMeshProUGUI>(); // Busqueda recursiva


        if(_dialogueTMP != null)
        {
            _dialogueTMP.text = "Obtenido dialogueTMP";
        } else
        {
            Debug.LogWarning("No se encontro un TMP como hijo del panel");
        }
        #endregion
        #region Obtener Texto del nombre
        // Obtener el hijo del segundo hijo del panel
        _nameTMP = _dialoguePnl.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();

        if (_nameTMP != null)
        {
            _nameTMP.text = "Nombresito";
        }
        else
        {
            Debug.LogWarning("No se encontro un TMP como hijo del panel de nombre");
        }
        #endregion
        #region Obtener Texto del bot�n
        _NextBtn = _dialoguePnl.transform.GetChild(2).GetComponent<Button>();
        
        if(_NextBtn != null) {
            _NextBtn.onClick.AddListener(delegate { continueDialogue(); });
            _NextTMP = _NextBtn.transform.GetComponentInChildren<TextMeshProUGUI>();

            if(_NextTMP != null) {
                _NextTMP.text = "Salir";
                }
            else {
                Debug.LogWarning("No se encontro un TMP como hijo del bot�n");
                }
        } else {
            Debug.LogWarning("No se encontro el bot�n");
            }
        #endregion
    }

    public void setDialogue(string name, string[] dialogue)
    {
        #region Inicializar variables
        _name = name;
        _dialogueList = new List<string>(dialogue.Length);
        _dialogueList.AddRange(dialogue);
        _dialogueIdx = 0;
        #endregion
        #region Primer contacto
        _nameTMP.text = _name;
        showDialogue();
        _NextTMP.text = "Continuar";
        _dialoguePnl.SetActive(true);
        #endregion
    }

    private void continueDialogue()
    {
        if(_dialogueIdx == _dialogueList.Count - 1)
        {
            Debug.Log("Se termina el di�logo con " + _name);
            _dialoguePnl.SetActive(false);
        }
        else if(_dialogueIdx == _dialogueList.Count - 2) // Pen�ltimo
        {
            _dialogueIdx++;
            showDialogue();
            _NextTMP.text = "Salir";
        }
        else
        {
            _dialogueIdx++;
            showDialogue();
        }
    }

    public void showDialogue()
    {
        Debug.Log("Di�logo: #" + _dialogueIdx);
        _dialogueTMP.text = _dialogueList[_dialogueIdx];
    }
}
