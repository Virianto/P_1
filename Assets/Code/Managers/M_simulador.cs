using Code.Utils;
using System;
using UnityEngine;

/// <summary>
/// cuenta del tiempo
/// lanzar un game over(salir de la escena o activar otro cancvas para reiniciar el juego)
/// 
/// </summary>
public class M_simulador : Singleton<M_simulador>

{
    public event Action<float> OnTimeLeftChanged;
    public event Action<float> OnPlayerLifeLeftChanged;
    public event Action<float> OnPlayerSpeedVelocityChanged;

    #region ATTRIBUTES
    [SerializeField]
    Ui_SimulatorCnavas SimulatorCnavas;

    [SerializeField]
    B_PlayerPlane Player;

    [SerializeField]

    [Range(5, 60)]
    float gameTimeLeft = 10;

    #endregion


    #region METHODS 

    public void PlayerLifeChanged(float playerLifeLeft)
    {
        OnPlayerLifeLeftChanged?.Invoke(playerLifeLeft);
    }

    public void PlayerSpeedChange(float playerSpeedVelocity)
    {
        OnPlayerSpeedVelocityChanged?.Invoke(playerSpeedVelocity);
    }
    void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }


    void LaunchGameOver()
    { }
    #endregion
}
