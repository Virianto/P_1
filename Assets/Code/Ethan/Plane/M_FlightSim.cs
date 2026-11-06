using Code.Utils;
using System;
using UnityEngine;

public class M_FlightSim : Singleton<M_FlightSim>
{
    public event Action<float> OnTimeLeftChange;
    public event Action<int> OnPointsChange;
    [SerializeField] Ui_PlaneCanvas UiPlaneCanvas;
    [SerializeField] EthanPlaneController planeController;
    [SerializeField] [Range(5, 60)] float gameTime;
    public int playerPoints;
    void Start()
    {
        planeController = GetComponent<EthanPlaneController>();
        UiPlaneCanvas = GetComponent<Ui_PlaneCanvas>();
    }

    void Update()
    {
        gameTime -= Time.deltaTime;
        OnTimeLeftChange?.Invoke(gameTime);
    }
    public void UpdatePoints(int newAmount)
    {
        OnPointsChange?.Invoke(playerPoints += newAmount);
        //playerPoints += newAmount;
    }
    void LaunchGameOver()
    {

    }
}
