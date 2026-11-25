using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Mover de manera constante el objeto asociado hacia delante
/// Detectar input de usuario para girar o rotar el objeto
/// Añadir tecla de teletransporte
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES

    Rigidbody rb;
    float movementValueX = 0;
    float movementValueY = 0;
    float movementYaw = 0;
    float _tiltValue;
    float _panValue;
    float _yawValue;
    int yawCount = 0;
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

    public M_FlightSimulator gameManager;
    public float maxLifePoints = 20;
    public float lifePointsLeft = 20;
    public int totalYellowCoinsCollected = 0;

    #endregion

    #region METHODS

    void Awake()
    {
        // Me aseguro de que el jugador empieza el nivel con toda la vida siempre
        lifePointsLeft = maxLifePoints;

        //ModifyPlayerSpeed(0);

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        ModifyPlayerSpeed(0);
        M_Input.Instance.OnPlayerForward += SetNewPlayerTiltValue;
        M_Input.Instance.OnPlayerMove += SetNewPlayerPanValue;
        M_Input.Instance.OnPlayerYaw += SetNewPlayerYawValue;
    }

    void SetNewPlayerTiltValue(float newValue)
    {
        _tiltValue = newValue;
    }

    void SetNewPlayerPanValue(float newValue)
    {
        _panValue = newValue;
    }

    void SetNewPlayerYawValue(float newValue)
    {
        _yawValue = newValue;
    }

    private void Update()
    {
        //Mover de forma constante el objeto hacia delante
        transform.position += transform.forward * Time.deltaTime * speed;

        ////Detectar el input de usuario para rotar y así maniobrar
        //if (Input.GetKey(vNegativeTiltKey))

        //    transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);

        //if (Input.GetKey(vPositiveTiltKey))

        //    transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);

        //if (Input.GetKey(hNegativeTiltKey))

        //    transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);

        //if (Input.GetKey(hPositiveTiltKey))

        //    transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);

        if (_panValue != 0)
        {
            transform.Rotate(new Vector3(0, 0, _panValue) * Time.deltaTime * angularSpeed);
        }

        if (_tiltValue != 0) {
            transform.Rotate(new Vector3(_tiltValue, 0, 0) * Time.deltaTime * angularSpeed);
        }

        if (_yawValue != 0)
        {
            //transform.position += (new Vector3(movementYaw, 0, 0)) * Time.deltaTime * speed;
            //yawCount++;

            transform.Rotate(new Vector3(0, _yawValue, 0) * Time.deltaTime * angularSpeed);
        }
        //else if (yawCount == 10)
        //{
        //    yawCount = 0;
        //}
    }

    public void ModifyPlayerSpeed(float amount)
    {
        speed += amount;
        M_FlightSimulator.Instance.PlayerSpeedChanged(speed);
    }

    public void ModifyPlayerLife(float amount)
    {
        lifePointsLeft += amount;
        M_FlightSimulator.Instance.PlayerLifeChanged(lifePointsLeft/maxLifePoints);
    }

    public void EarnMoney(int moneyAmount)
    {
        //totalYellowCoinsCollected += moneyAmount;
        totalYellowCoinsCollected = Mathf.Clamp(totalYellowCoinsCollected + moneyAmount, 0, 100);
        gameManager.NewCoinCollected();
    }

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    ////Detectar el input de usuario para rotar y así maniobrar
    //    //if (input.Get<float>() > 0)
    //    float movementValue = context.ReadValue<float>();
    //        transform.Rotate(new Vector3(0, 0, movementValue) * Time.deltaTime * angularSpeed);
    //    //else
    //        //transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
    //}

    void OnMove(InputValue inputValue)
    {
        ////Detectar el input de usuario para rotar y así maniobrar
        //if (input.Get<float>() > 0)
        movementValueX = inputValue.Get<float>();
        
        //transform.Rotate(new Vector3(0, 0, movementValue) * Time.deltaTime * angularSpeed);
        
        //else
        //transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
    }

    //public void OnForward(InputAction.CallbackContext context)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void OnBackward(InputAction.CallbackContext context)
    //{
    //    throw new System.NotImplementedException();
    //}

    void OnForward(InputValue inputValue)
    {
        movementValueY = inputValue.Get<float>();
    }

    void OnYaw(InputValue inputValue)
    {
        movementYaw = inputValue.Get<float>();
    }

    #endregion
}
