using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_MusicManager : MonoBehaviour
{

    #region ATTRIBUTES


    [SerializeField]
    List<AudioSource> musicSources = new();

    int currentMusicIndex = (int)Mathf.Clamp(0,0,Mathf.Infinity);
    #endregion


    #region METHODS


    void Start()
    {
        M_InputManager.Instance.OnMusicForward += PlayNextMusic;
        M_InputManager.Instance.OnMusicBack += PlayLastMusic;
        musicSources[currentMusicIndex].Play();
    }

    void PlayNextMusic()
    {
        musicSources[currentMusicIndex].Stop();
        currentMusicIndex = (currentMusicIndex + 1) % musicSources.Count;
        musicSources[currentMusicIndex].Play();
    }

    void PlayLastMusic()
    {
            musicSources[currentMusicIndex].Stop();
            currentMusicIndex = (currentMusicIndex - 1) % musicSources.Count;
            musicSources[currentMusicIndex].Play();
    }

    #endregion
}
