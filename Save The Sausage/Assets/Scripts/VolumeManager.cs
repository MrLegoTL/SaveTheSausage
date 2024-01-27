using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    // Referencia al elemento de la interfaz gr�fica de usuario
    public Slider sliderVolumen;

    // Volumen inicial
    private float volumenInicial = 0.5f;

    private void Start()
    {
        // Configura el valor inicial del slider seg�n el volumen actual
        sliderVolumen.value = AudioListener.volume;

        // Configura el volumen inicial
        EstablecerVolumen(volumenInicial);
    }

    /// <summary>
    /// M�todo llamado cuando se cambia el valor del slider de volumen
    /// </summary>
    public void CambiarVolumen()
    {
        // Establece el volumen seg�n el valor del slider
        EstablecerVolumen(sliderVolumen.value);
    }

    /// <summary>
    /// M�todo para establecer el volumen del juego
    /// </summary>
    /// <param name="volumen"></param>
    private void EstablecerVolumen(float volumen)
    {
        // Se asegura de que el volumen est� en el rango de 0 a 1
        volumen = Mathf.Clamp01(volumen);

        // Establece el volumen global del juego
        AudioListener.volume = volumen;
    }
}
