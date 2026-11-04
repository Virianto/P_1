using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class C_Agent : MonoBehaviour
{
    #region ATTRIBUTES
    M_Agents myManager;

    NavMeshAgent myNavMeshAgent;

    [SerializeField]
    Image lifeBarImage;

    int maxLifePoints = 10;
    int currentLifePoints = 10;
    #endregion

    /// <summary>
    /// Es el método q se invoca desde el manager para inicializar CADA agente
    /// </summary>
    /// <returns></returns>
    #region METHODS
    public void InitializeNewAgent(M_Agents manager, Vector3 origin, Vector3 destinyPos)
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        transform.position = origin;

        myManager = manager;

        //Set destination
        myNavMeshAgent.SetDestination(destinyPos);
    }

    public void MofifyAgentLifePoints(int damageAmount)
    {
        //Modifico los puntos de vida del agente según la cantidad indicada
        currentLifePoints = Mathf.Clamp(currentLifePoints -= damageAmount, 0, 10);

        float newFillAmount = (float) currentLifePoints / maxLifePoints;

        lifeBarImage.fillAmount = newFillAmount;

        //Compruebo si sigo vivo y si no, se lo digo al manager
        if (currentLifePoints <= 0)
        {
            //Le comunico al manager mi defunción
            myManager.FinishAgentLifeCycle(this);
        }
    }

    #endregion
}
