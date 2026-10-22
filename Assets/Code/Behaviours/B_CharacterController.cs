using UnityEngine;

public class B_CharacterController : MonoBehaviour
{        
    // Detectar cuándo he tocado una trampa y restar X a la vida

    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    [Range(0, 100)]
    float playerSpeed = 30;

    [SerializeField]
    [Range(15, 90)]
    float rotationSpeed = 30;
       
    Vector2 movingDirection;
    float movingRotation;

    public int totalCoinsCollected = 0;
    public int lifePointsLeft = 20;

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

    void OnTriggerEnter(Collider other)
    {
        // Detectar cuándo he tocado una moneda y sumar 1 al contador
        B_Coin coinDetected = other.GetComponentInParent<B_Coin>();

        // SI la variable que me acabo de crear TIENE ALGO DE INFORMACIÓN DENTRO...
        if (coinDetected != null)
        {
            // Sumar 1 al contador
            totalCoinsCollected += coinDetected.coinValue;

            // Comunicar al manager que ha habido cambios y deben mostrarse en la UI
            gameManager.NewCoinCollected();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        // Modificar la cantidad de vida del jugador
        lifePointsLeft -= damageAmount;

        // Informar del cambio al game Manager
        gameManager.PlayerReceivedDamage();
    }

    #endregion
}
