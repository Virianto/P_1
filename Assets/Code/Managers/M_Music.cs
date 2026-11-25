using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Queremos que cuando el player pulse una tecla cambie la música
/// </summary>
public class M_Music : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("REFERENCIAS EXTERNAS")]

    /// <summary>
    /// Lista de clips en la carpeta Assets/Src/Sounds/Music para alimentar el musicAudioSource
    /// </summary>
    [SerializeField]
    List<AudioClip> playlist = new();

    /// <summary>
    /// Señala en la lista de clips qué canción estamos escuchando actualmente
    /// </summary>
    int currentSongIndex = 0;

    /// <summary>
    /// Es único en la escena, ya está configurado y siempre reproduce hilo musical (canal de AudioMixer)
    /// </summary>
    [SerializeField]
    AudioSource audioSource;
    #endregion

    #region METHODS
    /// <summary>
    /// Nos suscribimos a todos los eventos del Manager de Input en el Start para asegurarnos de que ya existe en escena
    /// </summary>
    void Start()
    {
        M_Input.Instance.OnNextSong += NextSong;
    }

    /// <summary>
    /// Actualiza el índice de canción y le asigna el clip de la lista correspondiente al AudioSource para que se escuche
    /// </summary>
    void NextSong()
    {
        // Incrementamos en 1 el índice para cambiar de canción y hacemos '%' para asegurarnos de no exceder el límite
        currentSongIndex = (currentSongIndex + 1) % playlist.Count;

        // Le asignamos el nuevo clip al AudioSource
        audioSource.clip = playlist[currentSongIndex];

        // Nos aseguramos de que se reproduce la música aunque haya cambiado el clip
        audioSource.Play();
    }
    #endregion
}