using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

/// <summary>
/// * Mover de manera constante el objeto asociado hacia delante
/// * Detectar input de usuario para girar/rotar el objeto asociado
/// * Añadir tecla de teletransporte
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES

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

    float isTilt;
    float isPan;
    bool isTurbo = false;

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

        if(isTilt != 0)
        {
            transform.Rotate(isTilt *Vector3.right * Time.deltaTime * angularSpeed);
        }

        if (isPan != 0)
        {
            transform.Rotate(-isPan * Vector3.forward * Time.deltaTime * angularSpeed);
        }

        // Detectar input de usuario para rotar el objeto y así maniobrar
        // if (Input.GetKey(vNegativeTiltKey))
        //{
        //transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        //}
        //if (Input.GetKey(vPositiveTiltKey))
        //{
        //transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        // }

        //if (Input.GetKey(hNegativeTiltKey))
        //{
        // transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
        //}
        //if (Input.GetKey(hPositiveTiltKey))
        //{
        // transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
        //}
    }

    public void ModifyPlayerLife(float amount)
    {
        currentLifePoints += amount;
        M_FlightSimulator.Instance.PlayerLifeChanged(currentLifePoints/maxLifePoints);
    }
    void OnTilt(InputValue value)
    {
        isTilt = value.Get<float>();
    }
    void OnPan(InputValue value)
    {
        isPan = value.Get<float>();
    }

    #endregion
}
