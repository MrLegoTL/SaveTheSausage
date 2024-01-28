using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Nombre de la escena a la que queremos cambiar
    private string nombreDeEscenaActual;
    
    // Referencia al Canvas de opciones
    public GameObject canvasOpciones;

    // Referencia al Canvas de niveles
    public GameObject canvasNiveles;

    private void Start()
    {
        // Desactivar el Canvas de opciones al inicio
        if (canvasOpciones != null)
        {
            canvasOpciones.SetActive(false);
        }
        // Desactivar el Canvas de niveles al inicio
        if (canvasNiveles != null)
        {
            canvasNiveles.SetActive(false);
        }
    }

    /// <summary>
    /// Método para mostrar u ocultar el Canvas de opciones
    /// </summary>
    public void MostrarOcultarCanvasOpciones()
    {
        if (canvasOpciones != null)
        {
            // Alternar la visibilidad del Canvas de opciones
            canvasOpciones.SetActive(!canvasOpciones.activeSelf);
        }
    }

    /// <summary>
    /// Método para mostrar u ocultar el Canvas de niveles
    /// </summary>
    public void MostrarOcultarCanvasNiveles()
    {
        if (canvasNiveles != null)
        {
            canvasNiveles.SetActive(!canvasNiveles.activeSelf);
        }
    }

    /// <summary>
    /// Método para cambiar la escena
    /// </summary>
    public void CambiarEscena(string nombreDeEscena)
    {
        SceneManager.LoadScene(nombreDeEscena);
        nombreDeEscenaActual = nombreDeEscena;
    }

    /// <summary>
    /// Método para salir del juego
    /// </summary>
    public void SalirDelJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
