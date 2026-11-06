using Code.Utils;
using System;
using UnityEngine;

/// <summary>
/// x Referencia al canvas de juego
/// x Referencia al player de la escena
/// x Variable de tiempo para el chrono
/// </summary>
public class M_FlightSimulator : Singleton<M_FlightSimulator>
{

    #region ATTRIBUTES

    public event Action<float> OnTimeLeftChanged;
    public event Action<float> OnPlayerLifeChanged;
    public event Action<float> OnPlayerSpeedChanged;

    [SerializeField]
    UI_FlightSimulatorCanvas flightSimulatorCanvas;

    [SerializeField]
    B_PlayerPlane player;

    [SerializeField]
    [Range(5, 60)]
    float gameTimeLeft = 10;

    [SerializeField]
    int playerPoints;
    int playerLifeLeft = 2;
    int newPlayerSpeed = 3;

    #endregion



    #region METHODS

    private void Update()
    {

        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);


    }

    void LaunchGameOver()
    {

        // A rellenar cuando tengamos el flujo completo de escena

    }

    public void SetNewPoints(float newPoints)
    {

        // Aumentar puntos del jugador x unidades

    }

    public void PlayerLifeChanged(float playerLifeLeft)
    {

        OnPlayerLifeChanged?.Invoke(playerLifeLeft);  

    }
    public void PlayerSpeedChanged(float newPlayerSpeed)
    {

        OnPlayerSpeedChanged?.Invoke(newPlayerSpeed);

    }

    #endregion
}