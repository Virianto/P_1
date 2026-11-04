using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class B_Agent : MonoBehaviour
{
    #region ATTRIBUTES

    public M_3GameManager gameManager;
    //public M_3GameManager gameManager3;
    [SerializeField]
    Image lifeBarImage;
    [SerializeField]
    [Range(0, 10)]
    int agentDamage = 1;
    [SerializeField]
    [Range(0.5f, 3)]
    float agentFreqDamage = 1;
    public int currentHP = 10;
    int maxLifePoints = 10;
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
            myAgent.SetDestination(new
                Vector3(1.38037574f, 2.89589525e-06f, -10.2678566f));//Vector3(8.5f, 5, 18));

        //aTimer.Stop();
        //aTimer.Dispose();
    }

    //private void Update() comentado para ejercicio AgentGen
    //{
    //    if (myAgent.name.ToLower().Contains("steal"))
    //        myAgent.SetDestination(gameManager.player.transform.position);
    //}

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
    }

    //public IEnumerator HurtAgent(B_Agent agent)
    //{
    //    //Dañar al agent
    //    TakeDamage(agentDamage);

    //    yield return new WaitForSeconds(agentFreqDamage);

    //    //Comprobar si el agent sigue estando dentro
    //    if (playerIsTouched)
    //    {
    //        //Volver a llamar a esta subrutina
    //        StartCoroutine(HurtAgent(agent));
    //    }
    //}

    public void InitializeHuman(M_3GameManager m_3GameManager, Vector3 newRandomPosition)
    {
        gameManager = m_3GameManager;
        transform.position = newRandomPosition;

        //transform.localScale = new Vector3(3, transform.localScale.y * 3, 3);
    }

    public void TakeDamage(int damage)
    {
        if (currentHP > 0)
        {
            float newFillAmount;

            currentHP -= damage;
            Mathf.Clamp(currentHP, 0, 10); //Para que no nos sume más del valor max de vida
                                           //ni quite menos del min
                                           //lifePointsLeft = Mathf.Clamp(lifePointsLeft - damage, 0, 20); //otra forma. Limita valores variable
                                           //gameManager.PlayerIULife();

            newFillAmount = currentHP / maxLifePoints;
            lifeBarImage.fillAmount = newFillAmount;

            Debug.Log(currentHP);

            if (currentHP == 0)
                GetComponent<B_Agent>().gameObject.SetActive(false);
                //gameManager.gameOverCanvas.gameObject.SetActive(true);
        }
        //else
        //    gameManager.gameOverCanvas.gameObject.SetActive(true);
    }
    #endregion
}
