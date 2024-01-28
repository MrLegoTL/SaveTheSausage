using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip gameMusic;
    public AudioClip mainMenuMusic;
    public AudioClip victoryMusic;
    public AudioClip defeatMusic;

    public static MusicManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Reproduce el audio de juego
    /// </summary>
    [ContextMenu("Play Game Music")]
    public void PlayGameMusic()
    {
        audioSource.clip = gameMusic;
        audioSource.Play();
        audioSource.volume = 0.1f;
    }

    /// <summary>
    /// Pausa el audio de juego
    /// </summary>
    [ContextMenu("Pause Game Music")]
    public void PauseGameMusic()
    {
        audioSource.Pause();
    }

    /// <summary>
    /// Reanuda el audio de juego
    /// </summary>
    [ContextMenu("Reanude Game Music")]
    public void ReanudeGameMusic()
    {
        audioSource.Play();
    }




    /// <summary>
    /// Reproduce el audio de juego
    /// </summary>
    [ContextMenu("Play Menu Music")]
    public void PlayMenuMusic()
    {
        audioSource.clip = mainMenuMusic;
        audioSource.Play();
        audioSource.volume = 0.4f;
    }

    /// <summary>
    /// Ganaste
    /// </summary>
    [ContextMenu("Victory Music")]
    public void PlayVictoryMusic()
    {
        audioSource.clip = victoryMusic;
        audioSource.Play();
        audioSource.volume = 0.4f;
        audioSource.loop = false;
    }

    /// <summary>
    /// Perdiste
    /// </summary>
    [ContextMenu("Defeat Music")]
    public void PlayDefeatMusic()
    {
        audioSource.clip = defeatMusic;
        audioSource.Play();
        audioSource.volume = 0.4f;
        audioSource.loop = false;
    }




}
