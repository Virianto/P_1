using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_AgentLife : MonoBehaviour
{
    // Recibir la orden de dirigirse hacia un punto del mapa
    // Va a moverse hasta ese punto por el camino más óptimo q encuentre
    #region ATTRIBUTES
    NavMeshAgent myAgent;

    [SerializeField]
    B_CharacterController myPlayer;

    [Tooltip("Velocidad a la que se mueve mi obstáculo")]
    [SerializeField]
    [Range(0.1f, 10)]
    float speed = 2;

    bool playerIsInsideArea = false;

    #endregion


    #region METHODS
    public void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }


    //private void Update()
    //{
        
    //}
    private void OnTriggerEnter(Collider other)
    {
        // Intentamos obtener el componente del jugador desde el objeto colisionado
        B_CharacterController player = other.gameObject.GetComponent<B_CharacterController>();
        StartCoroutine(HurtPlayer(player));
    }

    // Declarar un método (subrutina) con gestión de tiempo para dañar al jugador
    IEnumerator HurtPlayer(B_CharacterController player)
    {
        float trapFrecuencyDamage = 1;
        int trapDamage = 1;

        // dañar al jugador
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrecuencyDamage);

        // Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            // Volver a llamar a la subrutina
            StartCoroutine(HurtPlayer(player));
        }
    }

    // Detectar cuándo ha salido el jugador en el área de efecto
    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

    public void SetNewAgentDestination(Vector3 NewDestination)
    {
        // Cambiar el destino de mi agente
        myAgent.SetDestination(NewDestination);
    }

    #endregion
}
