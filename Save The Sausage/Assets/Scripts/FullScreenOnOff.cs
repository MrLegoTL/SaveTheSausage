using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenOnOff : MonoBehaviour
{
    // Referencia al toggle de pantalla completa en la interfaz gráfica de usuario
    public Toggle togglePantallaCompleta;

    private void Start()
    {
        // Configurar el estado inicial del toggle según la configuración actual
        togglePantallaCompleta.isOn = Screen.fullScreen;
    }

    /// <summary>
    /// Método llamado cuando se cambia el estado del toggle
    /// </summary>
    public void CambiarPantallaCompleta()
    {
        // Cambiar entre pantalla completa y modo ventana
        Screen.fullScreen = togglePantallaCompleta.isOn;
    }
}
