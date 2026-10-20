using UnityEngine;

public class B_CharacterController : MonoBehaviour
{
    // Leer input del teclado y transmitirlo en forma de movimiento al gameObject asociado

    #region ATTRIBUTES
    [SerializeField] [Range(0, 10)] float playerSpeed = 1;

    [SerializeField] [Range(10, 90)] float rotationSpeed = 45;

    Vector2 movingDirection;
    float movingRotation;


    public bool canCollectYellow = false;
    public bool canCollectRed = false;
    public bool canCollectBlue = false;

    public int totalYellowCoinsCollected = 0;
    public int totalRedCoinsCollected = 0;
    public int totalBlueCoinsCollected = 0;

    #endregion





    #region METHODS

    private void Update()
    {
        // Creamos un Vector2 y lo inicializamos
        movingDirection = Vector2.zero; // (0, 0)
        float movingRotation = 0;

        // Rellenamos el Vector2 con la información recibida por el teclado
        movingDirection.x = Input.GetAxisRaw("Horizontal");
        movingDirection.y = Input.GetAxisRaw("Vertical");

        // Comprobamos si, en ese frame, el jugador está pulsando una tecla
        if (Input.GetKey(KeyCode.Q))
        {
            movingRotation = -1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            movingRotation = 1;
        }

        // Declaramos un nuevo Vector3 temporal y le damos los datos del Vector2
        Vector3 finalMovement = new Vector3(movingDirection.x, 0, movingDirection.y);
        finalMovement *= Time.deltaTime;
        finalMovement *= playerSpeed;

        // Movemos el gameObject utilizando el Vector2 (movingDirection)
        // transform.Translate(new Vector3(movingDirection.x, 0, movingDirection.y));
        transform.Translate(finalMovement);

        Vector3 finalRotation = new Vector3(0, movingRotation, 0);
        finalRotation *= Time.deltaTime;
        finalRotation *= rotationSpeed;

        // Rotamos el gameObject utilizando el float (movingRotation)
        // transform.Rotate(new Vector3(0, movingRotation, 0));
        transform.Rotate(finalRotation);

        // Mostramos por consola la información
        // Debug.LogFormat("En horizontal tengo {0} y en vertical tengo {1}", movingDirection.x, movingDirection.y);



    }

    #endregion
}
