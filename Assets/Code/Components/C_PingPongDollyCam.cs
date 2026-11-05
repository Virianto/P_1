using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// X Asignar una cámara cinemachine con la extensión de dolly
/// ¿ Controlar la velocidad de movimiento de mi cámara ?
/// * Movimiento de vaivén a lo largo del Spline Container
/// </summary>
public class C_PingPongDollyCam : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    [Range(0, 1)]
    float camSpeed = 0.2f;

    CinemachineSplineDolly c_splineDolly;

    float currentDollyPos = 0;
    bool goingForward = true;

    #endregion

    #region METHODS

    void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();                
    }

    void Update()
    {
        c_splineDolly.SplineSettings.
    }

    #endregion
}
