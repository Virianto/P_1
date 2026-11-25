using Code.Utils;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_InputManager : Singleton<M_InputManager>
{
   
    #region ATTRIBUTES

    public event Action<float> OnHorizontalInputValueChanged;

    public event Action<float> OnVerticalInputValueChanged;

    public event Action OnPlayerShot;

    public event Action OnMusicForward;

    public event Action OnMusicBack;


    float hTiltValue;
    float vTiltValue;

    #endregion


    #region METHODS

  void OnShooting()
    {
        OnPlayerShot?.Invoke();
    }
    
    void OnHorizontalTilt(InputValue value)
    {
        hTiltValue = value.Get<float>();
        OnHorizontalInputValueChanged?.Invoke(hTiltValue); 

    }

    void OnVerticalTilt(InputValue value) 
    {
        vTiltValue = value.Get<float>();
        OnVerticalInputValueChanged?.Invoke(vTiltValue);

    }

    void OnForward()
    {
        OnMusicForward?.Invoke();
    }

    void OnBack()
    {
        OnMusicBack?.Invoke();
    }

    #endregion
}
