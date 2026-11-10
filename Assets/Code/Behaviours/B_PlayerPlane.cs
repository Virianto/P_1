<<<<<<< HEAD

using System;
using UnityEngine;

/// <summary>
/// mover de manera contante el objeto asocido hacia delante
/// detectac imput pra gira y rotar rl objeto
/// añadir tecla de teletranoprte
=======
using UnityEngine;

/// <summary>
/// * Mover de manera constante el objeto asociado hacia delante
/// * Detectar input de usuario para girar/rotar el objeto asociado
/// * Añadir tecla de teletransporte
>>>>>>> develop
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES

    [Range(0, 300)]
    public float speed = 3;

    [Range(0, 180)]
<<<<<<< HEAD
    public float angularspeed = 90;

    [SerializeField]
    KeyCode vNegativeTilKey = KeyCode.W;
    [SerializeField]
    KeyCode vPositiveTilKey = KeyCode.S;

    [SerializeField]
    KeyCode hNegativeTilKey = KeyCode.A;

    [SerializeField]
    KeyCode hPositiveTilKey = KeyCode.D;
    #endregion
    [SerializeField]
    [Range(1, 100)]
    float MaxLifePoints = 20;
    float currentLifePoint = 20;

    float currentSpeedVelocity = 20;

    #region METHODS 

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

            if(Input.GetKey(vNegativeTilKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularspeed);
        }

        if (Input.GetKey(vPositiveTilKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularspeed);
        }

        if ( Input.GetKey(hNegativeTilKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularspeed);
        }

        if (Input.GetKey(hPositiveTilKey))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * angularspeed);
=======
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

    #endregion

    #region METHODS

    void Awake()
    {
        // Me aseguro de que el jugador empieza el nivel con toda la vida siempre
        currentLifePoints = maxLifePoints;
    }

    void Update()
    {        
        transform.position += transform.forward * Time.deltaTime * speed;

        // Detectar input de usuario para rotar el objeto y así maniobrar
        if (Input.GetKey(vNegativeTiltKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(vPositiveTiltKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        }

        if (Input.GetKey(hNegativeTiltKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(hPositiveTiltKey))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
>>>>>>> develop
        }
    }

    public void ModifyPlayerLife(float amount)
    {
<<<<<<< HEAD
        currentLifePoint += amount;
        M_simulador.Instance.PlayerLifeChanged(currentLifePoint / MaxLifePoints);

    }

    public void ModifyPlayerSpeed(float amount)
    {
        currentSpeedVelocity += amount;
        M_simulador.Instance.PlayerSpeedChange(currentSpeedVelocity);

    }
=======
        currentLifePoints += amount;
        M_FlightSimulator.Instance.PlayerLifeChanged(currentLifePoints/maxLifePoints);
    }

>>>>>>> develop
    #endregion
}
