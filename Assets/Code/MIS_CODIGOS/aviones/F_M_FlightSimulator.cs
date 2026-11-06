using Code.Utils;
using System;
using UnityEngine;

public class F_M_FlightSimulator : Singleton<F_M_FlightSimulator>
{
    #region ATTRIBUTES

    // Eventos que escucha el canvas
    public event Action<float> OnTimeLeftChanged;
    public event Action<float> OnLifeChanged;   // valor entre 0 y 1
    public event Action<int> OnPointsChanged;
    public event Action<float> OnSpeedChanged;

    [SerializeField]
    F_UI_FlightSimulatorCanvas flightSimulatorCanvas;

    [SerializeField]
    F_B_PlayerPlane player;

    [SerializeField]
    [Range(5, 60)]
    float gameTimeLeft = 10;

    [SerializeField]
    float maxLife = 3;

    float currentLife;
    int currentPoints;

    #endregion

    #region METHODS

    void Start()
    {
        currentLife = maxLife;
    }

    void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }

    // Métodos public para poder elegirlos en el UnityEvent del anillo

    // Negativo quita vida, positivo la da
    public void ModifyLife(float amount)
    {
        currentLife += amount;
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);
        OnLifeChanged?.Invoke(currentLife / maxLife);

        if (currentLife <= 0)
        {
            LaunchGameOver();
        }
    }

    public void ModifyPoints(int amount)
    {
        currentPoints += amount;
        OnPointsChanged?.Invoke(currentPoints);
    }

    // Suma (o resta si es negativo) velocidad al avión
    public void ModifySpeed(float amount)
    {
        player.speed += amount;
        OnSpeedChanged?.Invoke(player.speed);
    }

    // Suma (o resta) segundos al cronómetro
    public void ModifyTime(float amount)
    {
        gameTimeLeft += amount;
    }

    void LaunchGameOver()
    {
        // A rellenar cuando tengamos el flujo completo de escena
    }

    #endregion
}