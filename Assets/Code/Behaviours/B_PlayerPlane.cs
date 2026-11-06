using UnityEngine;

/// <summary>
/// Mover de manera constante el objeto asociado hacia delante
/// Detectar input de usuario para girar o rotar el objeto
/// Añadir tecla de teletransporte
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
    }

    private void Update()
    {
        //Mover de forma constante el objeto hacia delante
        transform.position += transform.forward * Time.deltaTime * speed;

        //Detectar el input de usuario para rotar y así maniobrar
        if (Input.GetKey(vNegativeTiltKey))
        
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        
        if (Input.GetKey(vPositiveTiltKey))
            
            transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        
        if (Input.GetKey(hNegativeTiltKey))
            
            transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
        
        if (Input.GetKey(hPositiveTiltKey))

            transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
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

    #endregion
}
