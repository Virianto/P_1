using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NewMoneyAgent : MonoBehaviour
{

    // Monedas que hace perder esta trampa
    [SerializeField]
    [Range(1, 3)]
    int coinsLost = 1;

    // Frecuencia con que hace roba dinero esta trampa
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequency = 1;

    [SerializeField] GameObject player;
    NavMeshAgent myAgent;

    bool playerIsInsideArea = false;

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        myAgent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        // Detectar cuándo ha entrado el jugador en su área de efecto
        playerIsInsideArea = true;

        StartCoroutine(StealCoinsToPlayer(other.GetComponent<B_CharacterController>()));
    }
    IEnumerator StealCoinsToPlayer(B_CharacterController player)
    {
        // Le pongo un '-' delante a la variable porque el método suma únicamente
        player.EarnMoney(-coinsLost);

        // Esperamos la frecuencia indicada en la variable
        yield return new WaitForSeconds(trapFrequency);

        // Comprobamos si sigue dentro para seguir robando
        if (playerIsInsideArea)
        {
            StartCoroutine(StealCoinsToPlayer(player));
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

}