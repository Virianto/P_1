using System;
using UnityEngine;

/// <summary>
/// * Mover de manera constante el objeto asociado hacia delante
/// * Detectar input de usuario para girar/rotar el objeto asociado
/// * Añadir tecla de teletransporte
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES

    public event Action<float> OnPlayerSpeedChanged;

    [Range(0, 300)]
    public float speed = 3;

    [Range(0, 180)]
    public float angularSpeed = 90;

    [SerializeField]
    KeyCode vNegativeTiltKey = KeyCode.W;

    [SerializeField]
    KeyCode vPositiveTiltKey = KeyCode.S;

    [SerializeField]
    KeyCode hNegativeTiltKey = KeyCode.A;

    [SerializeField]
    KeyCode hPositiveTiltKey = KeyCode.D;

    [SerializeField]
    [Range(1, 100)]
    float maxLifePoints = 20;
    float currentLifePoints;

    float _tiltValue;
    float _panValue;

    #endregion

    #region METHODS

    void Awake()
    {
        // Me aseguro de que el jugador empieza el nivel con toda la vida siempre
        currentLifePoints = maxLifePoints;
    }

    /// <summary>
    /// Nos suscribimos a todos los eventos del Manager de Input en el Start para asegurarnos de que ya existe en escena
    /// </summary>
    void Start()
    {
        M_Input.Instance.OnPlayerTilt += SetNewPlayerTiltValue;
        M_Input.Instance.OnPlayerPan += SetNewPlayerPanValue;
    }

    void SetNewPlayerTiltValue(float newValue)
    {
        _tiltValue = newValue;
    }

    void SetNewPlayerPanValue(float newValue) 
    {
        _panValue = newValue;
    }

    void Update()
    {        
        transform.position += transform.forward * Time.deltaTime * speed;

        transform.Rotate(_tiltValue * Vector3.right * Time.deltaTime * angularSpeed);

        transform.Rotate(_panValue * Vector3.back * Time.deltaTime * angularSpeed);
    }

    public void ModifyPlayerLife(float amount)
    {
        currentLifePoints += amount;
        M_FlightSimulator.Instance.PlayerLifeChanged(currentLifePoints/maxLifePoints);
    }

    public void ModifyPlayerSpeed(float amount) 
    {
        speed += amount;
        OnPlayerSpeedChanged?.Invoke(speed);
    }

    #endregion
}
