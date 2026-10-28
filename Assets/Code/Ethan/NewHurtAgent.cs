using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NewHurtAgent : MonoBehaviour
{
    [SerializeField] GameObject player;
    NavMeshAgent myAgent;
    Vector3 destinationPoint = Vector3.zero;
    bool playerIsInsideArea = false;

    int agentDamage = 1;
   
    float trapFrequencyDamage = 1;

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        myAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar cuándo ha entrado el jugador en su área de efecto
        playerIsInsideArea = true;

        // Invocar una subrutina facilitando en parámetros el componente del player
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }


    IEnumerator HurtPlayer(B_CharacterController player)
    {
        // Dañar al jugador
        player.TakeDamage(agentDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);

        // Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            // Volver a llamar a esta subrutina
            StartCoroutine(HurtPlayer(player));
        }
    }

}
