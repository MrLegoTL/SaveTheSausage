using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void PauseGame()
    {

        juegoPausado = true;
        Time.timeScale = 0f; // Detener el tiempo en el juego

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
