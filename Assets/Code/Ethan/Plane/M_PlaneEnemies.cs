using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class M_PlaneEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    List<B_EthanEnemies> enemyList = new();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-30, 30), 1, Random.Range(-30, 30));
            Quaternion newRandomRotation = new Quaternion();
            GenerateNewPlaneEnemy(newRandomPosition, newRandomRotation);
        }

    }

    void GenerateNewPlaneEnemy(Vector3 newPosition, Quaternion newRotation)
    {
        B_EthanEnemies newEnemy = Instantiate(enemyPrefab).GetComponent<B_EthanEnemies>();
        enemyList.Add(newEnemy);
        newEnemy.InitializeEnemy(this, newPosition, newRotation);
    }

}
