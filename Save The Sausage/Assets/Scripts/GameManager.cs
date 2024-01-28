using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Nombre de la escena a la que queremos cambiar
    private string nombreDeEscenaActual;
    
    // Referencia al Canvas de opciones
    public GameObject canvasOpciones;

    [Header("Menus")]
    public CanvasGroup winMenu;
    public CanvasGroup defeatMenu;
    public CanvasGroup pauseMenu;
    public CanvasGroup uiCanvas;

    [Header("Collectables")]
    public Image[] collectables;
    public int countCollectables;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // Desactivar el Canvas de opciones al inicio
        if (canvasOpciones != null)
        {
            canvasOpciones.SetActive(false);
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
    /// Método para cambiar la escena
    /// </summary>
    public void CambiarEscena(string nombreDeEscena)
    {
        SceneManager.LoadScene(nombreDeEscena);
        nombreDeEscenaActual = nombreDeEscena;
    }

    public void VictoryPanel()
    {
        //Time.timeScale = 0;
        winMenu.alpha = 1;
        winMenu.interactable = true;
        winMenu.blocksRaycasts = true;
        MusicManager.instance.PlayVictoryMusic();

        if (countCollectables==0)
        {
            collectables[0].color = new Color(0, 0, 0);
            collectables[1].color = new Color(0, 0, 0);
            collectables[2].color = new Color(0, 0, 0);
        }
        if (countCollectables == 1)
        {
            collectables[0].color = new Color(255, 255, 255);
            collectables[1].color = new Color(0, 0, 0);
            collectables[2].color = new Color(0, 0, 0);
        }
        if (countCollectables == 2)
        {
            collectables[0].color = new Color(255, 255, 255);
            collectables[1].color = new Color(255, 255, 255);
            collectables[2].color = new Color(0, 0, 0);
        }
        if (countCollectables == 3)
        {
            collectables[0].color = new Color(255, 255, 255);
            collectables[1].color = new Color(255, 255, 255);
            collectables[2].color = new Color(255, 255, 255);
        }

    }

    public void DefeatPanel()
    {
        defeatMenu.alpha = 1;
        defeatMenu.interactable = true;
        defeatMenu.blocksRaycasts = true;
    }

    public void DesactivateUI()
    {
        uiCanvas.alpha = 0;
        uiCanvas.interactable = false;
        uiCanvas.blocksRaycasts = false;
    }

    public void ActivateUI()
    {
        uiCanvas.alpha = 1;
        uiCanvas.interactable = true;
        uiCanvas.blocksRaycasts = true;

        winMenu.alpha = 0;
        winMenu.interactable = false;
        winMenu.blocksRaycasts = false;

        defeatMenu.alpha = 0;
        defeatMenu.interactable = false;
        defeatMenu.blocksRaycasts = false;
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
