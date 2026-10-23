using UnityEngine;

public class B_CharacterController : MonoBehaviour
{
    // Leer input del teclado y transimitirlo en forma de movimiento al gameObject asociado

    // Detectar cuándo he tocado una moneda y sumar 1 al contador
    // Detectar cuándo he tocado una trampa y 

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

    /*public int totalYellowCoinsCollected = 0;
    public int totalBlueCoinsCollected = 0;
    public int totalGreenCoinsCollected = 0;*/
    public int totalCoinsCollected = 0;

    /*public bool canCollectYellowCoins = false;
    public bool canCollectBlueCoins = false;
    public bool canCollectGreenCoins = false;*/

    public int lifePointsLeft = 20;

    #endregion

    #region METHODS

    // Este método se lanza cuando hago click sobre el Collider del objeto ligado al script
    void OnMouseDown()
    {
        Debug.Log("Me has dado en la nuca");
        GetComponent<C_Spinner>().enabled = !GetComponent<C_Spinner>().enabled;
    }

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

    void OnTriggerEnter(Collider other)
    {

        // Detectar cuando he tocado una moneda y sumar 1 al contador
        B_Coin coinDetected = other.GetComponentInParent<B_Coin>();

        // Si la varibale que me acabo de crear TIENE ALGO DE INFORMACIÓN DENTRO
        if (coinDetected != null)
        {
            /*// Sumar 1 al contador
            totalCoinsCollected += 1;

            // ComUnicar al manager que ha habido cambios y deben mostrarse en la UI
            gameManager.NewCoinCollected();*/
            EarnMoney(1);

        }
        // Detectar cuando he tocado una moneda y sumar 1 al contador
        B_SuperCoin superCoinDetected = other.GetComponentInParent<B_SuperCoin>();

        // Si la varibale que me acabo de crear TIENE ALGO DE INFORMACIÓN DENTRO
        if (superCoinDetected != null)
        {
            /*// Sumar 1 al contador
            totalCoinsCollected += 5;

            // ComUnicar al manager que ha habido cambios y deben mostrarse en la UI
            gameManager.NewCoinCollected();*/
            EarnMoney(5);

        }
    }

    public void EarnMoney(int moneyAmount)
    {

        // totalCoinsCollected += moneyAmount;
        totalCoinsCollected = Mathf.Clamp(totalCoinsCollected + moneyAmount, 0, 100);
        gameManager.NewCoinCollected();

    }

    public void TakeDamage(int damageAmount)
    {
        Debug.LogFormat("Tengo {0} vida ahora", lifePointsLeft);


        // Modificar la cantidad de vida del jugador
        lifePointsLeft -= damageAmount;


        Debug.LogFormat("Tras recibir daño me queda {0} de vida ", lifePointsLeft);

        // Informar del cambio al gameManager
        gameManager.PlayerRecievedDamage();

    }

    public void HealPlayer(int healAmount)
    {
        Debug.LogFormat("Tengo {0} vida ahora", lifePointsLeft);


        // Modificar la cantidad de vida del jugador
        lifePointsLeft += healAmount;


        Debug.LogFormat("Tras recibir cura me queda {0} de vida ", lifePointsLeft);

        // Informar del cambio al gameManager
        gameManager.PlayerRecievedHeal();
    }

    #endregion
    }
