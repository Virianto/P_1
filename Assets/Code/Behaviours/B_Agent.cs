using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;
    [SerializeField]
    [Range(0, 10)]
    int agentDamage = 1;
    [SerializeField]
    [Range(0.5f, 3)]
    float agentFreqDamage = 1;
    NavMeshAgent myAgent;
    bool playerIsTouched = false;

    #endregion

    #region METHODS
    //Recibir orden de dirigirse a un punto
    //Va a moverse por el camino más optimo para llegar

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();

        //Timer aTimer = new Timer(5000);
        //aTimer.Start();
        if (!myAgent.name.ToLower().Contains("steal"))
            myAgent.SetDestination(new Vector3(8.5f, 5, 18));

        //aTimer.Stop();
        //aTimer.Dispose();
    }

    private void Update()
    {
        if (myAgent.name.ToLower().Contains("steal"))
            myAgent.SetDestination(gameManager.player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pillado!");
        playerIsTouched = true;
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsTouched = false;
    }

    public void SetNewDestinationByPlayer(Vector3 newDestination)
    {
        //Cambiar el destino de mi agente
        myAgent.SetDestination(newDestination);
    }

    public void SetNewDestination(Vector3 newDestination)
    {
        //Cambiar el destino de mi agente
        myAgent.SetDestination(newDestination);
    }

    //método con gestión de tiempo para dañar al jugador
    IEnumerator HurtPlayer(B_CharacterController player)
    {
        //Dañar al jugador
        player.TakeDamage(agentDamage);

        //Debug.Log("Dañar al jugador antes de la espera");
        //Debug.Log($"Se llama {player.name}");

        yield return new WaitForSeconds(agentFreqDamage);

        //Comprobar si el jugador sigue estando dentro
        if (playerIsTouched)
        {
            //Volver a llamar a esta subrutina
            StartCoroutine(HurtPlayer(player));
        }
    #endregion
    }
}
