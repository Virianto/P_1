using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// * Mover de manera constante el objeto asocidao hacia delante
/// * Detectar input del usuario para girar/rotar el objeto asociado
/// * Añadir tecla de teletransporte
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{

    #region ATTRIBUTES

    [Range(0, 300)]
    public float speed = 3;

    [Range(0, 180)]
    public float angularSpeed = 90;


    public float maxPlayerLife = 10;
    [Range(0f, 10f)]
    public float currentPlayerLife = 10;

    //[SerializeField]
    //KeyCode vNegativeTiltKey = KeyCode.W;

    //[SerializeField]
    //KeyCode vPositiveTiltKey = KeyCode.S;

    //[SerializeField]
    //KeyCode hNegativeTiltKey = KeyCode.A;

    //[SerializeField]
    //KeyCode hPositiveTiltKey = KeyCode.D;

    float movementValue;
    float tiltDirection;



    float hTiltValue;
    float vTiltValue;
    #endregion


    #region METHODS

    void Start()
    {
     M_FlightSimulator.Instance.PlayerSpeedChanged(speed);
     M_InputManager.Instance.OnVerticalInputValueChanged += SetNewVerticalValue;
     M_InputManager.Instance.OnHorizontalInputValueChanged += SetNewHorizontalValue;
    }
    void Update()
    {
        //Mover el objeto de forma constante hacia delante
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate(hTiltValue * Vector3.right * Time.deltaTime * angularSpeed);
        transform.Rotate(vTiltValue * Vector3.back * Time.deltaTime * angularSpeed);

    }

    void SetNewVerticalValue(float newValue)
    {
        hTiltValue = newValue;
    }

    void SetNewHorizontalValue (float newValue)
    {
        vTiltValue = newValue;
    }
    public void Accelerate(float newSpeed)
    {
        speed += newSpeed;
        M_FlightSimulator.Instance.PlayerSpeedChanged(speed);
    }
    public void ModifyLifePoints(float newLifePoints)
    {
        currentPlayerLife += newLifePoints;
        M_FlightSimulator.Instance.PlayerLifeChanged(currentPlayerLife / maxPlayerLife);
     
    }
    
    #endregion
}
