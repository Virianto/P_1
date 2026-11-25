
using UnityEngine;
using UnityEngine.InputSystem;

public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES

    [Range(0, 300)]
    public float speed = 3;

    [Range(0, 180)]
    public float angularSpeed = 90;

    [SerializeField]
    InputActionReference moveAction;

    [SerializeField]
    [Range(1, 100)]
    float maxLifePoints = 20;

    float currentLifePoints;

    #endregion

    #region METHODS

    void Awake()
    {
        currentLifePoints = maxLifePoints;
    }

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        // El avion avanza constantemente
        transform.position += transform.forward * Time.deltaTime * speed;

        // Leemos el movimiento del jugador
        Vector2 movement = moveAction.action.ReadValue<Vector2>();

        // Arriba y abajo: mover el morro del avion
        transform.Rotate(
            Vector3.right * movement.y * Time.deltaTime * angularSpeed
        );

        // Izquierda y derecha: inclinar el avion
        transform.Rotate(
            Vector3.forward * -movement.x * Time.deltaTime * angularSpeed
        );
    }

    public void ModifyPlayerLife(float amount)
    {
        currentLifePoints += amount;

        M_FlightSimulator.Instance.PlayerLifeChanged(
            currentLifePoints / maxLifePoints
        );
    }

    #endregion
}
