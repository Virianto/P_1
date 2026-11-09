using Code.Utils;
using System;
using UnityEngine;


/// <summary>
/// Controlar los distintos parámetros de juego, como el tiempo restante o la velocidad, y pasarle la información al Canvas
/// * Referencia al Canvas
/// * Referencia al Player
/// * Referencia de tiempo para el crono
/// </summary>
public class M_FlightSimulator : Singleton<M_FlightSimulator>
{
    #region ATTRIBUTES

    public event Action<float> OnTimeLeftChanged;

    public event Action<float> OnSpeedChanged;

    public event Action<float> OnPointsChanged;

    public event Action<float> OnLifeChanged;

    [SerializeField]
    UI_FlightSimulatorCanvas flightSimulatorCanvas;

    [SerializeField]
    B_PlayerPlane player;

    B_HoveringRing ring;

    [SerializeField]
    [Range(1, 60)]
    float gameTimeLeft = 60;

    #endregion





    #region METHODS

    private void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }

    public void PlayerLifeChanged(float playerLifeLeft)
    {
        OnLifeChanged?.Invoke(playerLifeLeft);
    }

    public void PlayerSpeedChanged(float playerSpeed)
    {
        OnSpeedChanged?.Invoke(playerSpeed);
    }

    public void PlayerPointsChanged(float playerPoints)
    {
        OnPointsChanged?.Invoke(playerPoints);
    }

    public void ModifyTime(float gameTimeLeft)
    {
        this.gameTimeLeft = this.gameTimeLeft + gameTimeLeft;
        OnTimeLeftChanged?.Invoke(this.gameTimeLeft);
    }

    void LauchGameOver()
    {

    }
    #endregion
}