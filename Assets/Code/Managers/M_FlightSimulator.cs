using Code.Utils;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// X Referencia al canvas de juego
/// X Referencia al player de la escena
/// X Variable de tiempo para el crono
/// </summary>
public class M_FlightSimulator : Singleton<M_FlightSimulator>
{
    #region ATTRIBUTES
    public event Action<float> OnTimeLeftChanged;
    public event Action<float> OnSpeedChanged;
    public event Action<float> OnLifeChanged;
    public event Action<int> OnPointsChanged;

    [SerializeField] [Range (5,120)]
    float gameTimeLeft = 10; // Cuenta en segundos

    [SerializeField]
    int points = 0;

    public UI_FlightCanvas flightCanvas;
    public B_PlayerPlane playerPlane;

    #endregion


    #region METHODS
    public void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }

    public void PlayerLifeChanged(float lifeAmount)
    {
        OnLifeChanged?.Invoke(lifeAmount);
    }

    public void ModifyPoints(int points)
    {
        this.points = this.points + points;
        OnPointsChanged?.Invoke(points);
    }

    public void ModifyTime(int time)
    {
        gameTimeLeft += time;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
        if (gameTimeLeft <= 0)
        {
            LaunchGameOver();
        }
    }

    public void ModifySpeed(float newSpeed)
    {
        playerPlane.speed = newSpeed;
        OnSpeedChanged?.Invoke(newSpeed);
    }

    public void LaunchGameOver()
    {
        // Rellenar cuando haya flujo de juego
        SceneManager.LoadScene(0);
    }
    #endregion
}
