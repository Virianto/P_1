
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Va a tener una vida
/// Va a entrar dentro de una lista de enemigos
/// Va a seguir una ruta
/// 
/// </summary>
public class B_Enemy : MonoBehaviour
{

    #region ATTRIBUTES
    M_EnemiesManager myManager;

    [SerializeField]
    [Range(0.1f, 1f)]
    float switchDistance = 0.5f;
    [SerializeField]
    [Range(0, 55)]
    float speed = 0.5f;

    
    [SerializeField]
    int totalLife = 5;
    List<Vector3> patrolPointsList = new();

    int currentDestinyIndex = 0;

    #endregion


    #region METHODS

    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, patrolPointsList[currentDestinyIndex]);

        if (currentDistance <= switchDistance)
        {
            currentDestinyIndex = (currentDestinyIndex + 1) % patrolPointsList.Count;
        }
        else
        {
            Vector3 middlePoint = Vector3.Lerp(transform.position, patrolPointsList[currentDestinyIndex], Time.deltaTime * speed);
            transform.position = middlePoint;
        }
    }

    public void InitializeEnemy(M_EnemiesManager manager, Vector3 newPosition)
    {
        myManager = manager;
        transform.position = newPosition;
        FillPatrolPointsList();
    }

    void FillPatrolPointsList()
    {
        for (int i = 0; i <9; i++)
        {
            Vector3 newPoint = new Vector3(Random.Range(-20, 20), Random.Range(0, 26), Random.Range(-50,50));
            patrolPointsList.Add(newPoint);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        B_PlayerPlane player = other.GetComponentInParent<B_PlayerPlane>();
        if (player != null) 
        {
            player.ModifyLifePoints(-2);
            M_FlightScoolCameraManager.Instance.ChangeToHitCamera(1);
            myManager.FinishEnemyLifeCycle(this);
        }
    }

    public void ModifyEnemyLifePoints (int amount)
    {
        totalLife += amount;

        if(totalLife <= 0)
        {
            myManager.FinishEnemyLifeCycle(this);
        }
    }



    #endregion
}
