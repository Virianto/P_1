using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NewHurtAgent : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    NavMeshAgent myAgent;
    AgentManager agentManager;
    bool playerIsInsideArea = false;

    int agentDamage = 1;
    public int lifePointsLeft = 3;

    float trapFrequencyDamage = 1;

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        myAgent.SetDestination(playerGO.transform.position);
    }

    public void InitializeHurtAgent(AgentManager manager, Vector3 position, GameObject player)
    {
        agentManager = manager;
        transform.position = position;
        playerGO = player;
    }

    void OnTriggerEnter(Collider other)
    {
        // Detectar cuándo ha entrado el jugador en su área de efecto
        if (other.CompareTag("Player"))
        {
            playerIsInsideArea = true;
            // Invocar una subrutina facilitando en parámetros el componente del player
            StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
        }

       
    }

    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }
    public void TakeDamage(int damageAmount)
    {
        lifePointsLeft = Mathf.Clamp((lifePointsLeft - damageAmount), 0, 20);
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
