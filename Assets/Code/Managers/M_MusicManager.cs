using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Se ocupa de todas las modificaciones de sonido en la escena
/// </summary>
public class M_Audio : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    /// <summary>
    /// Es único en la escena, ya está configurado y siempre reproduce hilo musical (canal de AudioMixer)
    /// </summary>
    [SerializeField]
    AudioSource musicAudioSource;

    /// <summary>
    /// Lista de clips en la carpeta Assets/Src/Sounds/Music para alimentar el musicAudioSource
    /// </summary>
    [SerializeField]
    List<AudioClip> allClipsList = new();

    /// <summary>
    /// Señala en la lista de clips qué canción estamos escuchando actualmente
    /// </summary>
    int currentSongIndex = -1;

    #endregion

    #region METHODS

    /// <summary>
    /// Nos suscribimos a todos los eventos del Manager de Input en el Start para asegurarnos de que ya existe en escena
    /// </summary>
    void Start()
    {
        M_TotalInput.Instance.OnPlayerSwitchSong += SwitchToNextSong;
    }

    /// <summary>
    /// Actualiza el índice de canción y le asigna el clip de la lista correspondiente al AudioSource para que se escuche
    /// </summary>
    void SwitchToNextSong()
    {
        // Incrementamos en 1 el índice para cambiar de canción y hacemos '%' para asegurarnos de no exceder el límite
        currentSongIndex = (currentSongIndex + 1) % allClipsList.Count;

        // Le asignamos el nuevo clip al AudioSource
        musicAudioSource.clip = allClipsList[currentSongIndex];

        // Nos aseguramos de que se reproduce la música aunque haya cambiado el clip
        musicAudioSource.Play();
    }

    #endregion
}