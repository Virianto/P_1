using Code.Utils;
using System;
using UnityEngine;

/// <summary>
/// * Llevar la cuenta del tiempo
/// * Lanzar pantalla de GameOver
/// * Llevar la cuenta de puntos del jugador
/// * Velocidad a la que va
/// </summary>
public class M_FlightSimulator : Singleton<M_FlightSimulator>
{

    #region ATTRIBUTES

    public event Action<float> OnTimeLeftChanged;

    public event Action<int> OnPointCountChanged;

    public event Action<float> OnPlayerSpeedChanged;

    public event Action<float> OnPlayerCurrentLifeChanged;
   

    [SerializeField]
    UI_FlightCanvas flightCanvas;

    [SerializeField]
    B_PlayerPlane player;

    [SerializeField]
    [Range(5,60)]
    public float gameplayTime = 30;

    public int pointsCollected = 0;


    #endregion


    #region METHODS

    void Update()
    {
        
        gameplayTime -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(Mathf.Clamp(gameplayTime, 0, 3000));
    }


    public void EarnPoints(int newPoint)
    {
        pointsCollected += newPoint;
        OnPointCountChanged?.Invoke(pointsCollected);
    }

    public void PlayerSpeedChanged (float playerSpeed)
    {
        OnPlayerSpeedChanged?.Invoke(playerSpeed);
    }
    public void PlayerLifeChanged (float playerLifeLeft)
    {
        OnPlayerCurrentLifeChanged?.Invoke(playerLifeLeft);
    }
    public void ModifyGameplayTime (float newGameplayTime)
    {
        gameplayTime += newGameplayTime;
        OnTimeLeftChanged?.Invoke (gameplayTime);
    }
    
    void LaunchGameOver()
    {
       
            Debug.Log("Has muerto");
      
    }
    #endregion
}
