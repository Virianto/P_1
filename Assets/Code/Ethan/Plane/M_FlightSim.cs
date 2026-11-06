using Code.Utils;
using System;
using UnityEngine;

public class M_FlightSim : Singleton<M_FlightSim>
{
    public event Action<float> OnTimeLeftChange;
    public event Action<int> OnPointsChange;
    public event Action<float> OnPlayerLifeLeftChanged;

    [SerializeField] Ui_PlaneCanvas UiPlaneCanvas;
    [SerializeField] EthanPlaneController planeController;
    [SerializeField] [Range(5, 60)] float gameTime;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject GameOverHUD;
    public int playerPoints;
    public float playerLife;

    public void PlayerLifeChanged(float playerLifeLeft)
    {
        OnPlayerLifeLeftChanged?.Invoke(playerLife -= playerLifeLeft);
    }

    void Update()
    {
        gameTime -= Time.deltaTime;
        OnTimeLeftChange?.Invoke(gameTime);
        if (playerLife <= 0)
        {
            HUD.SetActive(false);
            GameOverHUD.SetActive(true);
            planeController.enabled = false;
        }
    }
    public void UpdatePoints(int newAmount)
    {
        OnPointsChange?.Invoke(playerPoints += newAmount);
    }

    void LaunchGameOver()
    {

    }
}
