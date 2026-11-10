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
    public event Action<float> OnPlayerLifeLeftChanged;

    public event Action<float> OnPlayerSpeedVelocityChanged;

    [SerializeField]
    UI_FlightSimulatorCanvas SimulatorCnavas;

    [SerializeField]
    B_PlayerPlane player;

    [SerializeField]
    [Range(5, 60)]
    float gameTimeLeft = 10;

    #endregion

    #region METHODS

    public void PlayerLifeChanged(float playerLifeLeft)
    {
        OnPlayerLifeLeftChanged?.Invoke(playerLifeLeft);
    }

    void Update()
    {
        ModifyGameTimeLeft(-Time.deltaTime);
    }
    public void PlayerSpeedChange(float playerSpeedVelocity)
    {
        OnPlayerSpeedVelocityChanged?.Invoke(playerSpeedVelocity);
    }

    public void ModifyGameTimeLeft(float amount)
    {
        gameTimeLeft += amount;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }
    void LaunchGameOver()
    {
        // A rellenar cuando tengamos el flujo completo de escena
    }

    #endregion
}
