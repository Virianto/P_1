using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// * Generar instancias del prefab "Enemy" en ubicaciones aleatorias
/// * Gestionar el ciclo de vida
/// * NO CREAR MÁS GLOBOS SI YA HAY (límite editable) EN ESCENA
/// </summary>
public class M_Enemies : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("VALORES EDITABLES")]
    [SerializeField]
    [Range(1, 30)]
    int totalEnemiesToCreate = 1;

    [SerializeField]
    [Range(1, 30)]
    int MaxEnemiesInScene = 3;
    int currentEnemiesInScene = 0;

    // Variable q me permita definir un rango horizontal (X)
    [SerializeField]
    [Range(1, 100)]
    float horizontalXRange = 10;

    // Variable q me permita definir un rango de profundidad (Y)
    [SerializeField]
    [Range(1, 100)]
    float verticalYRange = 10;

    // Variable q me permita definir un rango de profundidad (Z)
    [SerializeField]
    [Range(1, 100)]
    float horizontalZRange = 10;

    [SerializeField]
    [Range(0.1f, 10)]
    float timeBetweenEnemies = 2;

    [Space(10)]

    [Header("REFERENCIAS EXTERNAS")]
    [SerializeField]
    GameObject enemyPrefab;

    List<B_Enemy> allInstantiateEnemiesList = new();

    #endregion


    #region METHODS
    private void Start()
    {
        StartCoroutine(GenerateEnemyRoutine());
    }

    IEnumerator GenerateEnemyRoutine()
    {
        // Genero un enemigo nuevo si es posible
        if(currentEnemiesInScene < MaxEnemiesInScene)
        {
            GenerateNewPrefabEnemy();
            
            yield return new WaitForSeconds(timeBetweenEnemies);

            //Repito llamada a la rutina para que sea cíclica
            StartCoroutine(GenerateEnemyRoutine());
        }
    }

    void GenerateNewPrefabEnemy()
    {
        Vector3 newEnemyPosition = new Vector3(
            Random.Range(-horizontalXRange, horizontalXRange),
            Random.Range(-verticalYRange, verticalYRange),
            Random.Range(-horizontalZRange, horizontalZRange));

        // Crear instancia del enemigo

        B_Enemy newEnemy = Instantiate(enemyPrefab).GetComponent<B_Enemy>();

        // Inicializo el script del enemigo para que sepa dónde ir
        newEnemy.InitializeEnemy(this, newEnemyPosition);

        // Añado un enemigo al contador para alcanzar el límite
        currentEnemiesInScene += 1;
    }

    public void FinishEnemyLifeCycle(B_Enemy enemy)
    {
        // Elimino el anillo de mi lista
        Destroy(enemy.gameObject);
    }

    #endregion
}
