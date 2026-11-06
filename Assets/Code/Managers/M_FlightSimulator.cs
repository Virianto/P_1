using Code.Utils;
using System;
using UnityEngine;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class M_FlightSimulator : Singleton<M_FlightSimulator>
{
    #region ATTRIBUTES
    [SerializeField] UI_FlightSimulatorCanvas flightCanvas;
    [SerializeField][Range(5, 60)] float gameTimeLeft;
    public  event Action<float> OnTimeLeftChanged;
    #endregion

    #region METHODS
    private void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft);
    }

    void LaunchGameOver()
    {
        //a rellenar cuando tengamos el flujo completo de escena
            }

    #endregion
}
