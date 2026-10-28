using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_AgentCoins : MonoBehaviour
{
    // Recibir la orden de dirigirse hacia un punto del mapa
    // Va a moverse hasta ese punto por el camino más óptimo q encuentre
    #region ATTRIBUTES
    [SerializeField]
    B_CharacterController myPlayer;

    [Tooltip("Velocidad a la que se mueve mi obstáculo")]
    [SerializeField]
    [Range(0.1f, 10)]
    float speed = 2;

    [Tooltip("Distancia a la que se da la vuelta")]
    [SerializeField]
    [Range(0.1f, 10)]
    float switchDistance = 2;

    [SerializeField]
    List<Transform> routePointsList = new();

    Transform currentDestinyPoint;

    int currentDestinyIndex = 0;

    bool playerIsInsideArea = false;

    #endregion


    #region METHODS
    public void Awake()
    {
        currentDestinyPoint = routePointsList[currentDestinyIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        // Intentamos obtener el componente del jugador desde el objeto colisionado
        B_CharacterController player = other.gameObject.GetComponent<B_CharacterController>();
        StartCoroutine(StealCoinsToPlayer(player));
    }

    // Declarar un método (subrutina) con gestión de tiempo para quitar monedas al jugador
    IEnumerator StealCoinsToPlayer(B_CharacterController player)
    {
        int coinLost = 1;
        float trapFrecuency = 1;
        //Le pongo un '-' delante a la variable porque el método suma únicamente
        player.EarnMoney(-coinLost);

        yield return new WaitForSeconds(trapFrecuency);

        // Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            // Volver a llamar a la subrutina
            StartCoroutine(StealCoinsToPlayer(player));
        }
    }
    void Update()
    {
        // Necesito sabe si estoy lo bastante cerca o no de mi destino
        float currentDistance = Vector3.Distance(transform.position, currentDestinyPoint.position);

        if (currentDistance <= switchDistance) // Si ya estoy cerca
        {
            // Cambio de destino
            currentDestinyIndex = (currentDestinyIndex + 1) % routePointsList.Count;
            currentDestinyPoint = routePointsList[currentDestinyIndex];

        }
        else // Si estoy lejos
        {
            // Me sigo acercando
            Vector3 middlePoint = Vector3.Lerp(transform.position, currentDestinyPoint.position, Time.deltaTime * speed);
            transform.position = middlePoint;
        }
    }

    // Detectar cuándo ha salido el jugador en el área de efecto
    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

    #endregion
}
