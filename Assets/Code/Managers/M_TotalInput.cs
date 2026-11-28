using Code.Utils;
using System;
using UnityEngine.InputSystem;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_TotalInput : Singleton<M_TotalInput>
{
    #region ATTRIBUTES

    #region Input Related Events

    public event Action OnPlayerSwitchCamera;
    public event Action OnPlayerSwitchSong;
    public event Action OnPlayerShoot;
    public event Action<float> OnPlayerTilt;
    public event Action<float> OnPlayerPan;

    #endregion

    float _tiltValue;
    float _panValue;

    #endregion

    #region METHODS

    /// <summary>
    /// Se invoca cada vez que el jugador quiera cambiar de cámara (de tercera a primera persona y viceversa)
    /// </summary>
    void OnCamera()
    {
        OnPlayerSwitchCamera?.Invoke();
    }

    /// <summary>
    /// Se invoca cada vez que el jugador quiera cambiar de canción (en principio solamente avanza una hacia delante)
    /// </summary>
    void OnRadio()
    {
        // Lanzamos el evento para que el manager de audio lo detecte y realice los cambios necesarios
        OnPlayerSwitchSong?.Invoke();
    }

    /// <summary>
    /// No lleva InputValue de parámetro porque es un botón y no aporta información adicional
    /// </summary>
    void OnShoot()
    {
        // Si hay otra clase esperando que se produzca esta acción, se lo hacemos saber
        OnPlayerShoot?.Invoke();
    }

    /// <summary>
    /// Inclinación vertical
    /// </summary>
    /// <param name="value">Toma valores -1 | 0 | 1 para multiplicar por la rotación vertical (eje X) del avión</param>
    void OnTilt(InputValue value)
    {
        _tiltValue = value.Get<float>();

        // Si hay otra clase esperando que se produzca esta acción, se lo hacemos saber y, además, le facilitamos el valor
        OnPlayerTilt?.Invoke(_tiltValue);
    }

    /// <summary>
    /// Inclinación horizontal
    /// </summary>
    /// <param name="value">Toma valores -1 | 0 | 1 para multiplicar por la rotación horizontal (eje Z) del avión</param>
    void OnPan(InputValue value)
    {
        _panValue = value.Get<float>();

        // Si hay otra clase esperando que se produzca esta acción, se lo hacemos saber y, además, le facilitamos el valor
        OnPlayerPan?.Invoke(_panValue);
    }

    #endregion
}