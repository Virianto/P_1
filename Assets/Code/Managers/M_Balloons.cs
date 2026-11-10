using System.Collections;
using UnityEngine;

/// <summary>
/// * Generar instancias del prefab "EvilBalloon" en ubicaciones aleatorias
/// * Gestionar el ciclo de vida de los globos
/// * NO CREAR MÁS GLOBOS SI YA HAY (límite editable) EN ESCENA
/// </summary>
public class M_Balloons : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    // Referencia al prefab
    [SerializeField]
    GameObject balloonPrefab;

    [Header("EDITABLE VALUES")]

    // Límite de enemigos simultáneos en escena
    [SerializeField]
    [Range(1, 10)]
    int maxBalloonsInScene = 3;

    [SerializeField]
    [Range(1, 4)]
    float timeBetweenGenerations = 2;

    // Límites de espacio para ubicar cada nuevo prefab
    [SerializeField]
    [Range(1, 30)]
    float horizontalRandomLimit = 5;

    [SerializeField]
    [Range(1, 30)]
    float depthRandomLimit = 5;

    [SerializeField]
    [Range(1, 30)]
    float verticalRandomLimit = 10;

    int currentEnemiesInScene = 0;

    #endregion

    #region METHODS

    // MétodoS de generación de nuevo globo (Start + Rutina + Método void)
    void Start()
    {
        StartCoroutine(GenerateBalloonRoutine());
    }

    IEnumerator GenerateBalloonRoutine()
    {
        // Si aún no he alcanzado el límite, genero un enemigo nuevo
        if(currentEnemiesInScene < maxBalloonsInScene)
        {
            GenerateNewEvilBalloon();
        }

        yield return new WaitForSeconds(timeBetweenGenerations);

        // Repito llamada a la rutina para que sea cíclica
        StartCoroutine(GenerateBalloonRoutine());
    }

    void GenerateNewEvilBalloon()
    {
        // Invento un punto aleatorio de la escena para el nuevo enemigo
        Vector3 newBalloonPos = new Vector3(
            Random.Range(-horizontalRandomLimit, horizontalRandomLimit),
            Random.Range(-verticalRandomLimit, verticalRandomLimit),
            Random.Range(-depthRandomLimit, depthRandomLimit));

        // Crear instancia nueva del enemigo
        B_EvilBalloon newBalloon = Instantiate(balloonPrefab).GetComponent<B_EvilBalloon>();

        // Inicializo el script del enemigo para que sepa dónde ir
        newBalloon.InitializeBalloon(this, newBalloonPos);

        // Añado un enemigo al contador para alcanzar el límite
        currentEnemiesInScene += 1;
    }

    public void FinishBalloon(B_EvilBalloon balloon)
    {
        Destroy(balloon.gameObject);
        currentEnemiesInScene -= 1;     
    }

    #endregion
}
