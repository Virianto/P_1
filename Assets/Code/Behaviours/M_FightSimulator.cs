using Code.Utils;
using System;

using UnityEngine;

// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class M_FightSimulator : Singleton<M_FightSimulator>
{
    #region ATTRIBUTES
    public event Action<float> OnTimeLeftChanged;
    [SerializeField]
    UI_FlightSimulatorCanvas flightSimulatorCanvas;
    [SerializeField]
    [Range(5, 60)]
    float gameTimeLeft;
    [SerializeField]
    B_PlayerPlane PlayerPlane;

    #endregion

    #region METHODS
    private void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }
    #endregion
}
