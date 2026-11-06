using Code.Utils;
using System;
using UnityEngine;

/// <summary>
/// Referencia al canvas del juego
/// Referencia al player de la escena
/// Variable de tiempo para crono
/// </summary>
public class M_FlightSimulator : Singleton<M_FlightSimulator>
{
    #region ATTRIBUTES

    [SerializeField]
    UI_FlightSimulatorCanvas flightSimulatorCanvas;

    [SerializeField]
    B_PlayerPlane player;

    [SerializeField]
    [Range(5, 60)]
    float gameTimeLeft = 10;

    public event Action<float> OnTimeLeftChanged;

    #endregion

    #region METHODS

    private void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }

    void LaunchGameOver()
    {

    }

    #endregion
}
