using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// * Los agentes deben tener vida y poder perderla si pisan una trampa
/// * En el INIT de cada agente se debe indicar su destino
/// </summary>
public class C_Agent : MonoBehaviour
{
    #region ATTRIBUTES

    // NECESITO UNA REFERENCIA AL MANAGER
    M_Agents myManager;
    [SerializeField] Image lifeBarImage;
    NavMeshAgent myNavMeshAgent;
    int maxlifePoints = 10;
    int currentLifePoints = 10;

    #endregion

    #region METHODS

    /// <summary>
    /// Método que se invoca desde el manager para inicializar CADA agente
    /// </summary>
    /// <param name="manager">Referencia que viene desde el gestor</param>
    /// <param name="destinyPos">Ubicación para el SetDestiny()</param>
    public void InitializeNewAgent(M_Agents manager, Vector3 origin, Vector3 destinyPos)
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        transform.position = origin;

        myManager = manager;
                
        myNavMeshAgent.SetDestination(destinyPos);
    }

    public void ModifyAgentLifePoints(int amount)
    {
        // Modifico los puntos de vida según la cantidad que indica el parámetro
        currentLifePoints += amount;

        float newFillAmount = (float)currentLifePoints / maxlifePoints;
        lifeBarImage.fillAmount = newFillAmount;


        if (currentLifePoints <= 0) 
        {
            myManager.FinishAgentLifeCycle(this);
        }
    }

    #endregion
}
