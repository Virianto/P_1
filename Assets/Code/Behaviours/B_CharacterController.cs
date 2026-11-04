using UnityEngine;

public class B_CharacterController : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    [Range(0, 60)]
    float playerSpeed = 1;

    [SerializeField]
    [Range(15, 90)]
    float rotationSpeed = 30;

    [SerializeField]
    int maxLifePoints = 20;

    Vector2 movingDirection;

    public int totalCoinsCollected = 0;
    public int lifePointsLeft = 20;

    public bool IsDead => lifePointsLeft <= 0;

    #endregion

    #region METHODS

    void Update()
    {
        // Si el jugador ha muerto, no se mueve
        if (IsDead) return;

        // Dirección con información del teclado
        movingDirection.x = Input.GetAxisRaw("Horizontal");
        movingDirection.y = Input.GetAxisRaw("Vertical");

        // Evita que en diagonal vaya más rápido que en recto
        movingDirection = Vector2.ClampMagnitude(movingDirection, 1f);

        // Rotación con Q y E
        float movingRotation = 0;
        if (Input.GetKey(KeyCode.Q)) movingRotation = -1;
        if (Input.GetKey(KeyCode.E)) movingRotation = 1;

        // Movimiento
        Vector3 finalMovement = new Vector3(movingDirection.x, 0, movingDirection.y);
        finalMovement *= Time.deltaTime * playerSpeed;
        transform.Translate(finalMovement);

        // Rotación
        Vector3 finalRotation = new Vector3(0, movingRotation, 0);
        finalRotation *= Time.deltaTime * rotationSpeed;
        transform.Rotate(finalRotation);
    }

    void OnTriggerEnter(Collider other)
    {
        // Moneda: sumar 1 al contador
        B_Coin coinDetected = other.GetComponentInParent<B_Coin>();
        if (coinDetected != null)
        {
            EarnMoney(1);
        }

        // Trampa: restar vida
        B_Trampa trapDetected = other.GetComponentInParent<B_Trampa>();
        if (trapDetected != null)
        {
            TakeDamage(trapDetected.
                danoJugador);
        }
    }

    public void EarnMoney(int moneyAmount)
    {
        totalCoinsCollected = Mathf.Clamp(totalCoinsCollected + moneyAmount, 0, 100);

        if (gameManager != null)
            gameManager.NewCoinCollected();
    }

    public void TakeDamage(int damageAmount)
    {
        if (IsDead) return;

        lifePointsLeft = Mathf.Clamp(lifePointsLeft - damageAmount, 0, maxLifePoints);

        if (gameManager != null)
            gameManager.PlayerReceivedDamage();
    }

    #endregion
}

