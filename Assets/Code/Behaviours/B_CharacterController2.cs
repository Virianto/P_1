using UnityEngine;

public class B_CharacterController2 : MonoBehaviour
{
    // Detectar cu�ndo he tocado una trampa y restar X a la vida

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

    public int lifePointsLeft = 20;
    B_Coin2 coinDetected;

    #endregion

    #region METHODS

    void Update()
    {
        // Me creo un Vector2 nuevo y lo inicializo a 0 (por si el jugador no pulsa nada)
        movingDirection = Vector2.zero; // (0, 0)
        float movingRotation = 0;

        // Relleno el Vector2 con informaci�n recibida del teclado para cada eje
        movingDirection.x = Input.GetAxisRaw("Horizontal");
        movingDirection.y = Input.GetAxisRaw("Vertical");

        // Compruebo si, en este frame, el jugador est� pulsando esa tecla
        if (Input.GetKey(KeyCode.Q))
        {
            // �Qu� hago si la comprobaci�n de este if me devuelve un "true"?
            movingRotation = -1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            // �Qu� hago si la comprobaci�n de este if me devuelve un "true"?
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
        // Detectar cu�ndo he tocado una moneda y sumar 1 al contador
        coinDetected = other.GetComponentInParent<B_Coin2>();

        // SI la variable que me acabo de crear TIENE ALGO DE INFORMACI�N DENTRO...
        if (coinDetected != null && coinDetected.myCoinType==B_Coin2.CoinType.Normal)
        {
            // Sumar 1 al contador
            EarnMoney(1);
        } 
        if (coinDetected != null && coinDetected.myCoinType == B_Coin2.CoinType.Mega)
        {
            // Sumar 5 al contador
            EarnMoney(5);
        }

        //Debug.Log("monedas: " + totalCoinsCollected);
        gameManager.NewCoinCollector();
    }

    public void TakeDamage(int damageAmount)
    {
        //Mathf.Clamp(lifePointsLeft-damageAmount, 0, 20); -> limita los posibles valores de lifePointsLeft, entre 0 y 20
      
        //modificar vida jugador
        lifePointsLeft -= damageAmount;

        //informar al gameManager
        gameManager.PlayerReceiveDamage();

        if (lifePointsLeft == 0)
        {
            gameManager.FinishGame();
        }
    }

    public void RestoreLife(int restoredLife)
    {
        
        if(lifePointsLeft >= 20)
        {
            lifePointsLeft = 20;
        } 
        gameManager.PlayerReceiveDamage();
    }

    public void EarnMoney(int moneyAmount)
    {
        //totalCoinsCollected += moneyAmount;
        totalCoinsCollected = Mathf.Clamp(totalCoinsCollected + moneyAmount, 0, 100); //se modifica la cantidad de monedas respetando los limites marcados. 
        gameManager.NewCoinCollector();
    }

    #endregion
}
