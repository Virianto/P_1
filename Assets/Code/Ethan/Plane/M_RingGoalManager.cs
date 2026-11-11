using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public enum ringType
{
    Points, Life, Speed
}

public class M_RingGoalManager : MonoBehaviour
{
    [SerializeField] GameObject ringPrefab;
    //[SerializeField] Transform spawnOrigin;

    List<B_EthanRings> allInstantiatedRingsList = new();
    ringType newRingType;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-50, 50), Random.Range(-10, 10), Random.Range(-50, 50));
            GenerateNewRing(newRandomPosition);
        }
    }

    void GenerateNewRing(Vector3 newPosition)
    {
        ringType n = (ringType)Random.Range( 0, 3);

        B_EthanRings newRing = Instantiate(ringPrefab).GetComponent<B_EthanRings>();
        allInstantiatedRingsList.Add(newRing);
        newRing.InitializeRing(this, newPosition, n);
    }


}
