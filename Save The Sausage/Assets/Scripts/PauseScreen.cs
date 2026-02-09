using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    // Referencia al Canvas de pausa
    public GameObject canvasPausa;
    

    private bool juegoPausado = false;

    private void Start()
    {
        // Asegurarse de que el juego no esté pausado al inicio
        ResumeGame();
    }

    private void Update()
    {
        // Detectar la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alternar entre pausar y reanudar el juego
            if (juegoPausado)
                ResumeGame();
            else
                PauseGame();
        }
    }

    /// <summary>
    /// Método para pausar el juego
    /// </summary>
    public void PauseGame()
    {
        CanvasGroup pauseCanvas = canvasPausa.GetComponent<CanvasGroup>();
        juegoPausado = true;
        Time.timeScale = 0f; // Detener el tiempo en el juego
        pauseCanvas.alpha = 1;
        pauseCanvas.interactable = true;
        pauseCanvas.blocksRaycasts = true;

        canvasPausa.SetActive(true);
    }

    /// <summary>
    /// Método para reanudar el juego
    /// </summary>
    public void ResumeGame()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Restaurar el tiempo normal en el juego
        canvasPausa.SetActive(false);
    }
}
