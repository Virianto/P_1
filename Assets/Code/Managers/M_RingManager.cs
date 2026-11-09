using Code.Utils;
using System.Collections;
using UnityEngine;


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
    float timeBetweenSpawns = 5;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject ringPrefab;

    Color newRingColor;

    //Color(0.7647059f, 0.2862746f, 0.302114f, 1f); //rojo
    //Color(0.2669989f, 0.3872348f, 0.754717f, 1f); //azul
    //Color(0.8679245f, 0.7363456f, 0.1760413f, 1f); //amarillo
    //Color(0.2897293f, 0.8666667f, 0.1764706f, 1f); //verde



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
        if (newRingType == RingModificationType.Life)
        {
            newRingColor = new Color(0.7647059f, 0.2862746f, 0.302114f, 1f); //rojo
        }
        if (newRingType == RingModificationType.Speed)
        {
            newRingColor = new Color(0.2669989f, 0.3872348f, 0.754717f, 1f); //azul
        }
        if (newRingType == RingModificationType.Score)
        {
            newRingColor = new Color(0.8679245f, 0.7363456f, 0.1760413f, 1f); //amarillo
        }
        if (newRingType == RingModificationType.Time)
        {
            newRingColor = new Color(0.2897293f, 0.8666667f, 0.1764706f, 1f); //verde
        }


        newRing.InitializeRing(this,newPosition,Random.Range(3,10), Random.Range(0.5f,2),newRingType, newRingColor);
    }

    IEnumerator RingSpawnTimeCycle()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), Random.Range(0, verticalRange), Random.Range(-horizontalZRange, horizontalZRange));
        float newRandomlifeTime = Random.Range(10, 20);
        float newScale = Random.Range(0.5f, 2);
        GenerateNewPrefab(newRandomPosition);
        yield return new WaitForSeconds(timeBetweenSpawns);
        StartCoroutine(RingSpawnTimeCycle());
    }


    public void FinishRingLifeCycle(B_HoveringRing ring)
    {
        Destroy(ring.gameObject);
    }
    #endregion
}
