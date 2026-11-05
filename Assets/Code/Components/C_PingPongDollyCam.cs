using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// * Asignar una cámara Cinemachine con la extensión "dolly"
/// * Controlar la velocidad de movimiento de la cámara
/// * Recorrer el Spline ida y vuelta repetidamente
/// </summary>
public class C_PingPongDollyCam : MonoBehaviour
{
    #region ATTRIBUTES

    CinemachineSplineDolly c_splineDolly;

    [SerializeField]
    [Range(0, 1)]
    float camSpeed = 0.1f;

    #endregion





    #region METHODS

    private void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();
    }

    private void Update()
    {
        // Modificar la variable de la posición para que vaya entre 0 y 1
        // Asignar la variable a la posición del componente
        c_splineDolly.SplineSettings.Position = Mathf.PingPong(Time.time * camSpeed, 1);
    }

    public void SetNewCameraSpeed(float newSpeed)
    {
        camSpeed = newSpeed;
    }

    #endregion
}