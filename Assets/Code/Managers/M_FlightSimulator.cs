using Code.Utils;
using System;
using UnityEngine;

/// <summary>
/// X Referencia al canvas de juego
/// X Referencia al player de la escena
/// X Variable de tiempo para el crono
/// </summary>
public class M_FlightSimulator : Singleton<M_FlightSimulator>
{
    #region ATTRIBUTES

    public event Action<float> OnTimeLeftChanged;

    [SerializeField]
    UI_FlightSimulatorCanvas flightSimulatorCanvas;

    [SerializeField]
    B_PlayerPlane player;

    [SerializeField]
    [Range(5, 60)]
    float gameTimeLeft = 10;

    #endregion

    #region METHODS

    void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }

    void LaunchGameOver()
    {
        // A rellenar cuando tengamos el flujo completo de escena
    }

    #endregion
}
