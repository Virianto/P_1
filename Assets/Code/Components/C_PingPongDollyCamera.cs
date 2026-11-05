using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// X Asignar una cámara cinemachine con la extensión Dolly
/// * Controlar la vel de movimiento de mi cámara
/// * Movimiento de vaivén a lo largo del Spline
/// </summary>
public class C_PingPongDollyCamera : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    [Range(0f, 1)]
    float cameraSpeed = 0.2f;

    CinemachineSplineDolly c_splineDolly;
    #endregion


    #region METHODS
    private void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();
    }

    void Update()
    {
        // Modificar la variable curentDollyPos para q vaya entre 0 y 1
        // Asignar la variable curentDollyPos a la Position del componente
        c_splineDolly.SplineSettings.Position = Mathf.PingPong(Time.time * cameraSpeed, 1);
    }


    public void SetNewCamSpeed(float newSpeed)
    {
        cameraSpeed = newSpeed;
    }
    #endregion
}
