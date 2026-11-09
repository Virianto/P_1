using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RingType
{
    Points,
    Life,
    Time,
    Speed
}
public enum RingColor
{
    Blue,
    Red,
    Yellow,
    Green
}

public class M_SpawnAnillos : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject ringPrefab;

    RingType ringTypeEfects;
    RingType ringTypeColor;
    int currentSequenceIndex = 0;

    [SerializeField]
    List<Transform> allSpawnsPointsList = new();

    List<B_Ring> allInstantiatedRingsLists = new();

    #endregion
    #region METHODS

    void GenerateRingPrefab(Vector3 newPosition, RingType tipo, Color color)
    {
        B_Ring newRing = Instantiate(ringPrefab).GetComponent<B_Ring>();
        allInstantiatedRingsLists.Add(newRing);
        newRing.InitializeRing(this, newPosition, tipo, color);
    }

    private void Start()
    {
        StartCoroutine(InvocarAnillo());
    }
    IEnumerator InvocarAnillo()
    {
        Vector3 posicion = GenerateRandomPosition();
        Color color = GenerateRandomColor();
        RingType ringType = GenerateRandomTypeRing();

        GenerateRingPrefab(posicion, ringType, color);
        yield return new WaitForSeconds(Random.Range(3,10));
        StartCoroutine(InvocarAnillo());
    }
    private Vector3 GenerateRandomPosition()
    {
        currentSequenceIndex = UnityEngine.Random.Range(0, allSpawnsPointsList.Count);
        Vector3 spawnPosition = allSpawnsPointsList[currentSequenceIndex].position;
        return spawnPosition;
    }
    private RingType GenerateRandomTypeRing()
    {
        ringTypeEfects = (RingType)Random.Range(0, 4);
        return ringTypeEfects;
    }
    private Color GenerateRandomColor()
    {
        ringTypeColor = (RingType)Random.Range(0, 4);

        Color color = Color.white;

        if (ringTypeColor == 0)
        {
            color = Color.blue;
        }
        if ((int)ringTypeColor == 1)
        {
            color = Color.red;
        }
        if ((int)ringTypeColor == 2)
        {
            color = Color.yellow;
        }
        if ((int)ringTypeColor == 3)
        {
            color = Color.green;
        }

        return color;
    }
    #endregion
}

