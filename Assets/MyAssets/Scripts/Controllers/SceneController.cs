using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public void LoadGame() {
        SceneManager.LoadScene("WorkshopOutside");
        }
    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
        }

    public void LoadHowToPlay() {
        SceneManager.LoadScene("Instructions");
        }

    public void ExitGame() {
        Application.Quit(); // No sirve en el editor
        }
    }
