using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Referencia al valor de puntos
/// ... al valor de velocidad
/// ... al texto timepo
/// ... a la vida
/// </summary>
public class UI_FlightSimulatorCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    Button btnRadio;
    int songCount = 0;
    [SerializeField]
    TMP_Text playerPointsText;
    [SerializeField]
    TMP_Text playerSpeedText;
    [SerializeField]
    TMP_Text timeLeftText;
    [SerializeField]
    Image playerLifeImage;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> playlist;
    [SerializeField]
    TMP_Text songText;

    #endregion

    #region METHODS

    private void Start()
    {
        //Suscripciones a eventos siempre en Start (90%)

        //Enlazar el evento del manager con un método del canvas (updateTime)
        //En la izquierda escribo referencia al manager
        //En la derecha me suscribo a uno de sus eventos
        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;

        M_FlightSimulator.Instance.OnPlayerLifeLeftChanged += UpdateLifeLeftImage;

        M_FlightSimulator.Instance.OnPlayerSpeedChanged += UpdatePlayerSpeedText;

        //M_FlightSimulator.Instance.OnPlayerTimeChanged += UpdateTimeLeftText;

        btnRadio = GetComponent<Button>();

        UpdateSong();
    }

    void ChangeRadioSong()
    {
        if (songCount <= 5)
            UpdateSong();
        else
        {
            songCount = 0;
            UpdateSong();
        }
    }

    void UpdateSong()
    {
        audioSource.generator = playlist[songCount];
        audioSource.Play();
        songText.text = $"Canción:\n{playlist[songCount].name}";
        songCount++;
    }

    void UpdatePlayerPointsText(int playerPointsText)
    {

    }

    void UpdatePlayerSpeedText(float playerSpeedText)
    {
        this.playerSpeedText.text = $"Velocidad: {playerSpeedText.ToString()}0";
    }

    void UpdateTimeLeftText(float currentTimeLeftText)
    {
        timeLeftText.text = TimeFormatter.FormatTime(currentTimeLeftText);
    }

    void UpdateLifeLeftImage(float currentLifeAmount)
    {
        playerLifeImage.fillAmount = currentLifeAmount;
    }

    internal void UpdateCounter(int totalYellowCoinsCollected)
    {
        playerPointsText.text = totalYellowCoinsCollected.ToString();
    }

    #endregion
}
