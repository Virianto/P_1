using Code.Utils;
using System;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class M_ManagerCanvasAvion : Singleton<M_ManagerCanvasAvion>
{
    #region ATTRIBUTES

    public event Action<float> OnTimeLeftChanged;
    public event Action<int> PointsChanged;
    public event Action<float> SpeedChanged;
    public event Action<string> PlaneStatus;
    public event Action<float> OnPlayerLifeLeftChanged;

    [SerializeField]
    UI_FlightCanvas flightCanvas;

    [SerializeField]
    B_PlayerPlane playerPlane;

    [SerializeField]
    [Range(5, 60)]
    float gameTimeLeft = 10;

    [SerializeField]
    int points = 0;

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
    public void CurrentsPoints(int points)
    {
        this.points += points;
        PointsChanged?.Invoke(points);
    }

    public void CurrentSpeed(float speed)
    {
        SpeedChanged?.Invoke(speed);
    }
    public void PlaneStatusChange(String status)
    {
        PlaneStatus.Invoke(status);
    }
    public void PlayerLifeChanged(float playerLifeLeft)
    {
        OnPlayerLifeLeftChanged?.Invoke(playerLifeLeft);
    }
    public void PlayerTimeChanged(float playerTimeLeft)
    {
        gameTimeLeft = playerTimeLeft + gameTimeLeft;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }
    #endregion
}

