using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_Music : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    List<AudioClip> allClipsList = new();

    [SerializeField]
    AudioSource musicAudioSource;

    int currentSongIndex = -1;



    #endregion



    #region METHODS

    /// <summary>
    /// Nos suscribimos a todos los eventos del Manager de Input en el Start para asegurarnos de que ya existe en escena
    /// </summary>
    void Start()
    {
        M_InputA.Instance.OnPlayerSwitchSong += SwitchToNextSong;
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