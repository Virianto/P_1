using UnityEngine;

public class M_FlightSim : MonoBehaviour
{
    [SerializeField] Ui_PlaneCanvas UiPlaneCanvas;

    void Start()
    {
        UiPlaneCanvas = GetComponent<Ui_PlaneCanvas>();
    }
}
