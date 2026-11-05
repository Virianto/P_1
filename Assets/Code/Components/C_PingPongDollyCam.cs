using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// Esta clase se encarga de mover una cámara a través de un spline a lo largo del recorrido
/// * Asignar una cámara cinemachine con la extensión dolly
/// * Controlar la velocidad de movimiento de mi cámara
/// * Movimiento de vaivén a lo largo del Spline Container
/// </summary>
public class C_PingPongDollyCam : MonoBehaviour
{

    #region ATTRIBUTES

    CinemachineSplineDolly c_splineDolly;

    [SerializeField]
    [Range(0f, 1f)]
    float cameraSpeed =0.2f;

    #endregion


    #region METHODS

    void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();
       
            //= Mathf.PingPong(currentDollyPos,1):
        
    }

    void Update()
    {
        c_splineDolly.SplineSettings.Position = Mathf.PingPong(Time.time * cameraSpeed, 1);
    }

    public void SetNewCameraSpeed(float newSpeed)
    {
        cameraSpeed = newSpeed;
    }

    #endregion
}
