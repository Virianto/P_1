using Unity.Mathematics;
using UnityEngine;

public class B_EthanEnemies : MonoBehaviour
{
    M_PlaneEnemies enemyManager;
    [SerializeField][Range(0, 3)] int enemyLife = 3;


    public void InitializeEnemy(M_PlaneEnemies enemy, Vector3 newPosition, quaternion newRotation)
    {
        enemyManager = enemy;
        transform.position = newPosition;
        transform.rotation = newRotation;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 4;
        if (enemyLife <= 0) { Destroy(gameObject); }

    }
}
