using UnityEngine;

public class B_EthanRings : MonoBehaviour
{
    M_RingGoalManager ringManager;
    [SerializeField] ringType newRingType;

    public void InitializeRing(M_RingGoalManager manager, Vector3 newPosition, ringType n)
    {
        ringManager = manager;
        transform.position = newPosition;
        newRingType = n;

        if (newRingType == ringType.Life)
        {
            GetComponentInChildren<Renderer>().material.color = Color.red;
        }

        if (newRingType == ringType.Points)
        {
            GetComponentInChildren<Renderer>().material.color = Color.yellow;
        }

        if (newRingType == ringType.Speed)
        {
            GetComponentInChildren<Renderer>().material.color = Color.blue;
        }
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
            //M_FlightSim.Instance.ChangeCam(2);
        }
    }
}
