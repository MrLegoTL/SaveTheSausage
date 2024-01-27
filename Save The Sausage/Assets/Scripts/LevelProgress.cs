using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    // N�mero total de niveles
    private int numeroTotalDeNiveles = 5;
    // �ndice del nivel actualmente desbloqueado
    private int nivelDesbloqueado = 1;
    // Prefijo del nombre de las escenas de los niveles
    private string nombreBaseDeEscena = "Nivel";
    // Referencias a los botones de nivel en la interfaz gr�fica de usuario (UI)
    public Button[] botonesNivel;

    private void Start()
    {
        // Configurar la visibilidad de los botones de nivel
        ActualizarBotonesDesbloqueados();
    }

    /// <summary>
    /// M�todo para cargar un nivel cuando se hace clic en su bot�n
    /// </summary>
    /// <param name="numeroDeNivel"></param>
    public void CargarNivel(int numeroDeNivel)
    {
        // Solo cargar el nivel si est� desbloqueado
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
    /// M�todo para actualizar la visibilidad de los botones de nivel
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
    /// M�todo para desbloquear el siguiente nivel
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
            Debug.Log("�Has completado todos los niveles!");
        }
    }

    // M�todo para reiniciar el progreso de los niveles (puedes usar esto para prop�sitos de prueba)
    public void ReiniciarProgreso()
    {
        nivelDesbloqueado = 1;
        ActualizarBotonesDesbloqueados();
    }
}
