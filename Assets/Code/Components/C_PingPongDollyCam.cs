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

    #endregion

    #region METHODS

    void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();
    }

    void Update()
    {
        // Modificar la variable currentDollyPos para que vaya entre 0 y 1               
        // Asignar la variable currentDollyPos a la Position del componente
        c_splineDolly.SplineSettings.Position = Mathf.PingPong(Time.time * camSpeed, 1);
    }

    #endregion
}