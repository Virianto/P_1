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
        if (currentDollyPos == 1)
        {
            goingForward = false;
        }
        if (currentDollyPos == 0)
        {
            goingForward = true;
        }
        if (goingForward)
        {
            currentDollyPos = Mathf.Clamp01(currentDollyPos + Time.deltaTime);
        }
        else
        {
            currentDollyPos = Mathf.Clamp01(currentDollyPos - Time.deltaTime);
        }   
        c_splineDolly.SplineSettings.Position = currentDollyPos;

        //currentDollyPos = Mathf.PingPong(0, 1);
        //Debug.LogFormat("El valor actual es {0}", currentDollyPos);
        // Modificar la variable currentDollyPos para que vaya entre 0 y 1               
        // Asignar la variable currentDollyPos a la Position del componente
        //c_splineDolly.SplineSettings.Position = Mathf.PingPong(0, 1);
    }

    #endregion
}
