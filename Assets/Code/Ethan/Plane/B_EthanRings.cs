using System.Collections.Generic;
using UnityEngine;

public class B_EthanRings : MonoBehaviour
{
    M_RingGoalManager ringManager;
    [SerializeField] ringType newRingType;
    [SerializeField] List<Color> ringTypeColorsList = new();

    public void InitializeRing(M_RingGoalManager manager, Vector3 newPosition, ringType n)
    {
        ringManager = manager;
        transform.position = newPosition;
        newRingType = n;

        ChangeRingColor();
    }


    void OnTriggerEnter(Collider other)
    {
        if(newRingType == ringType.Life)
        {
            M_FlightSim.Instance.RedSceen();
            M_FlightSim.Instance.PlayerLifeChanged(0.25f);
            M_FlightSim.Instance.ChangeCam(1);
        }

        if (newRingType == ringType.Points)
        {
            M_FlightSim.Instance.UpdatePoints(5);
        }
           
        if(newRingType == ringType.Speed)
        {
            M_FlightSim.Instance.ChangeSpeed(20);
        }
    }


    void ChangeRingColor()
    {
        
        Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();

        for (int i = 0; i < allRingRenderers.Length; ++i)
        {
            allRingRenderers[i].material.color = ringTypeColorsList[(int)newRingType];
        }
    }
}
