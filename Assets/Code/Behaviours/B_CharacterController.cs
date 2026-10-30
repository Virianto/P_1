using UnityEngine;

public class B_CharacterController : MonoBehaviour
{   
    // Detectar ciándo he tocado una trampa y restar X a la vida


    // Leer input del teclado y transimitirlo en forma de movimiento al gameObject asociado
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    [Range(0, 10)]
    float playerSpeed = 1;

    [SerializeField]
    [Range(15, 90)]
    float rotationSpeed = 30;
       
    Vector2 movingDirection;
    float movingRotation;

    public int totalCoinsCollected = 0;
    [Range (0,20)]
    public int lifePointsLeft = 20;



    public int totalYellowCoinsCollected = 0;
    public int totalBlueCoinsCollected = 0;
    public int totalGreenCoinsCollected = 0;

    public bool canCollectYellowCoins = false;
    public bool canCollectBlueCoins = false;
    public bool canCollectGreenCoins = false;

    #endregion

    #region METHODS
    void Update()
    {
        // Me creo un Vector2 nuevo y lo inicializo a 0 (por si el jugador no pulsa nada)
        movingDirection = Vector2.zero; // (0, 0)
        float movingRotation = 0;  

        // Relleno el Vector2 con información recibida del teclado para cada eje
        movingDirection.x = Input.GetAxisRaw("Horizontal");
        movingDirection.y = Input.GetAxisRaw("Vertical");

        // Compruebo si, en este frame, el jugador está pulsando esa tecla
        if (Input.GetKey(KeyCode.Q))
        {
            // ¿Qué hago si la comprobación de este if me devuelve un "true"?
            movingRotation = -1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            // ¿Qué hago si la comprobación de este if me devuelve un "true"?
            movingRotation = 1;
        }

        // Me declaro un nuevo Vector3 (temporal) y, de entrada, le meto datos del Vector2
        Vector3 finalMovement = new Vector3(movingDirection.x, 0, movingDirection.y);
        finalMovement *= Time.deltaTime;
        finalMovement *= playerSpeed;

        // Muevo el gameObject utilizando el nuevo Vector3 antes de que se muera
        transform.Translate(finalMovement);

        Vector3 finalRotation = new Vector3(0, movingRotation, 0);
        finalRotation *= Time.deltaTime;
        finalRotation *= rotationSpeed;

        // Roto el gameObject utilizando el float temporal antes de que muera
        transform.Rotate(finalRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar cuándo he tocado una moneda y sumar 1 al contador
        C_Coin3 coinDetected = other.GetComponentInParent<C_Coin3>();

        if (coinDetected != null)
        {
            if (coinDetected.coinType == C_Coin3.CoinType.Coin)
            {
                EarnMoney(1);
            }
            if (coinDetected.coinType == C_Coin3.CoinType.Supercoin)
            {
                EarnMoney(10);
            }
        }

        //B_Coin2 coinDetected = other.GetComponentInParent<B_Coin2>();

        //if (coinDetected != null)
        //{
        //    EarnMoney(1);
        //    // Sumar 1 al contador
        //    //totalCoinsCollected += 1;

        //    //gameManager.NewCoinCollected();
        //}

        // Detectar cuándo he tocado una supermoneda y sumar 10 al contador
        //B_SuperCoin supercoinDetected = other.GetComponentInParent<B_SuperCoin>();

        //if (supercoinDetected != null)
        //{
        //    EarnMoney(10);

        //    gameManager.NewCoinCollected();
        //}

        B_Heart heartDetected = other.GetComponent<B_Heart>();

        if (heartDetected != null)
            lifePointsLeft += 5;

            gameManager.NewLifeCollected();
    }

    public void TakeDamage(int damageAmount)
    {
        // Modificar la cantidad de vida del jugador
        //lifePointsLeft -= damageAmount;
        //Mathf.Clamp(lifePointsLeft, 0, 20);

        lifePointsLeft = Mathf.Clamp(lifePointsLeft -= damageAmount, 0, 20); // En una sola linea

        // Informar del cambio al game Manager
        gameManager.PlayerReceiveDamage();
    }

    public void EarnMoney(int moneyAmount)
    {
        //Cambiar cuanto dinero tengo y comunicárselo al manager
        //totalCoinsCollected += moneyAmount;
        totalCoinsCollected = Mathf.Clamp(totalCoinsCollected + moneyAmount, 0, 100);
        gameManager.NewCoinCollected();
    }
    #endregion
}
