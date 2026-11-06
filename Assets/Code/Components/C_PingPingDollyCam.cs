using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// *asignar una camara cinemachine con la extension de dolly
/// *controlar la velocidad de movimiento de mi camara
/// *movimiento de vaiven a lo largo del spline container
/// </summary>
public class C_PingPingDollyCam : MonoBehaviour
{
    #region ATTRIBUTES
    CinemachineSplineDolly C_splineDolly;

    [SerializeField]
    [Range(0, 1)]
    float camSpeed = 0.2f;

    float currentDollyPos = 0;
    bool goingForward = true;
    #endregion


    #region METHODS 
    void OnEnable()
    {
        C_splineDolly = GetComponent <CinemachineSplineDolly>();


    }
    void Update()
    {
        C_splineDolly.SplineSettings.Position = Mathf.PingPong(Time.time * camSpeed, 1);
    }

    public void SetNewCameraSpeed(float newSpeed)
    {
        camSpeed = newSpeed;
    }
    #endregion
}
