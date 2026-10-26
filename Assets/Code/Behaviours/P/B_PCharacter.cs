using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class B_PCharacter : MonoBehaviour
{
    #region ATTRIBUTES

    public M_PManager gameManager;

    [SerializeField]
    [Range(0, 10)]
    float playerSpeed = 6;

    [SerializeField]
    [Range(15, 90)]
    float rotationSpeed = 60;

   
    Vector2 movingDirection;
    float movingRotation;

    public int totalCoinsCollected = 0;

    public UI_PGameplayCanvas timeSpent;

    bool isItBig =false;
    bool isItBigger =false;

    


    #endregion


    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        B_PCoin coinDetected = other.GetComponentInParent <B_PCoin>();
        B_PSuperCoin superCoinDetected = other.GetComponentInParent <B_PSuperCoin>();
        B_PMinusCoin minusCoinDetected = other.GetComponentInParent<B_PMinusCoin>();
        

        if (coinDetected != null) 
        {
            EarnMoney(1);
            EarnTime();
        }
        
        if (superCoinDetected != null)
        {
            EarnMoney(5);
            EarnTime();
            EarnTime();
            EarnTime();
            EarnTime();
            EarnTime();
        }

        if (minusCoinDetected != null)
        {
            EarnMoney(-1);
            
        }
    }


    void Update()
    {
        //Debug.LogFormat("Me quedan {0} segundos", timeSpent.gameplayTime);
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

        if (totalCoinsCollected >= 20) 
        {
            playerSpeed = 5;
            if (isItBig == false)
            {
                GetBigger();
            }
        }

        if (totalCoinsCollected >= 40)
        {
            playerSpeed = 4;
        }

        if (totalCoinsCollected >= 60)
        {
            playerSpeed = 3.5f;
            if(isItBigger == false)
            {
                GetEvenBigger();
            }
            
            
        }

        if (totalCoinsCollected >= 80)
        {
            playerSpeed = 3;
        }

        if (totalCoinsCollected == 100)
        {
            SceneManager.LoadScene(2);
        }

        //Si se acaba el tiempo y no tienes 100 monedas, se acaba el juego y sale la pantalla de game over
       
        if (totalCoinsCollected < 100 && timeSpent.gameplayTime <= 0f)
        {
            SceneManager.LoadScene(3);
        }
        
    }
    void GetBigger()
    {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            transform.position += new Vector3 (0f, 0.5f, 0f);
            isItBig = true;
       
    }
    void GetEvenBigger()
    {
        transform.localScale = new Vector3(2f, 2f, 2f);
        transform.position += new Vector3 (0f, 0.5f, 0f);
        isItBigger = true;
    }


    public void EarnMoney(int moneyAmount)
    {
        totalCoinsCollected = Mathf.Clamp(totalCoinsCollected + moneyAmount, 0, 100);
        gameManager.NewCoinCollected();
    }

    public void EarnTime()
    {
        gameManager.TimeEarned();
    }
    #endregion
}
