using Code.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.Splines;


/// <summary>
/// Manager que genera anillos de manera secuencial en un área determinada de forma aleatoria
/// 
/// </summary>
public class M_RingManager : Singleton<M_RingManager>
{

    #region ATTRIBUTES

    

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
    float horizontalXRange = 20;

    [SerializeField]
    [Range(1, 300)]
    float horizontalZRange = 20;

    [SerializeField]
    [Range(1, 300)]
    float verticalRange = 20;

    [SerializeField]
    [Range(1, 300)]
    float timeBetweenSpawns = 3;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject ringPrefab;

    #endregion


    #region METHODS

    private void Start()
    {
        StartCoroutine(RingSpawnTimeCycle());
    }

    void GenerateNewPrefab(Vector3 newPosition)
    {   
        B_HoveringRing newRing = Instantiate(ringPrefab).GetComponent<B_HoveringRing>();
        RingModificationType newRingType = (RingModificationType)Random.Range (0, 4);
        
       newRing.InitializeRing(this,newPosition,Random.Range(3,10), Random.Range(0.5f,2),newRingType);
    }

    IEnumerator RingSpawnTimeCycle()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), Random.Range(0, verticalRange), Random.Range(-horizontalZRange, horizontalZRange));
        float newRandomlifeTime = Random.Range(3, 10);
        float newScale = Random.Range(0.5f, 2);
        GenerateNewPrefab(newRandomPosition);
        yield return new WaitForSeconds(timeBetweenSpawns);
        StartCoroutine(RingSpawnTimeCycle());
    }

    #endregion
}
