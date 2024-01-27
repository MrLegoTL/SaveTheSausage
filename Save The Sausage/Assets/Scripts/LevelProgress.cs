using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    // Número total de niveles
    private int numeroTotalDeNiveles = 5;
    // Índice del nivel actualmente desbloqueado
    private int nivelDesbloqueado = 1;
    // Prefijo del nombre de las escenas de los niveles
    private string nombreBaseDeEscena = "Nivel";
    // Referencias a los botones de nivel en la interfaz gráfica de usuario (UI)
    public Button[] botonesNivel;

    private void Start()
    {
        // Configurar la visibilidad de los botones de nivel
        ActualizarBotonesDesbloqueados();
    }

    /// <summary>
    /// Método para cargar un nivel cuando se hace clic en su botón
    /// </summary>
    /// <param name="numeroDeNivel"></param>
    public void CargarNivel(int numeroDeNivel)
    {
        // Solo cargar el nivel si está desbloqueado
        if (numeroDeNivel <= nivelDesbloqueado)
        {
            SceneManager.LoadScene(nombreBaseDeEscena + numeroDeNivel);
        }
        else
        {
            Debug.Log("Nivel bloqueado. Completa niveles anteriores para desbloquear.");
        }
    }

    /// <summary>
    /// Método para actualizar la visibilidad de los botones de nivel
    /// </summary>
    private void ActualizarBotonesDesbloqueados()
    {
        for (int i = 0; i < botonesNivel.Length; i++)
        {
            // Desbloquear botones hasta el nivel actual
            botonesNivel[i].interactable = (i + 1 <= nivelDesbloqueado);
        }
    }

    /// <summary>
    /// Método para desbloquear el siguiente nivel
    /// </summary>
    public void DesbloquearSiguienteNivel()
    {
        if (nivelDesbloqueado < numeroTotalDeNiveles)
        {
            nivelDesbloqueado++;
            ActualizarBotonesDesbloqueados();
        }
        else
        {
            Debug.Log("¡Has completado todos los niveles!");
        }
    }

    // Método para reiniciar el progreso de los niveles (puedes usar esto para propósitos de prueba)
    public void ReiniciarProgreso()
    {
        nivelDesbloqueado = 1;
        ActualizarBotonesDesbloqueados();
    }
}
