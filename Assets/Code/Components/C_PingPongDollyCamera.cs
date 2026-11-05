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

    float currentDollyPos = 0;
    bool goingForward = true;
    #endregion


    #region METHODS
    private void OnEnable()
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
            // Incremento la variable local una fracción de frame
            currentDollyPos = Mathf.Clamp01(currentDollyPos + Time.deltaTime * cameraSpeed);
        }
        else
        {
            // Incremento la variable local una fracción de frame
            currentDollyPos = Mathf.Clamp01(currentDollyPos - Time.deltaTime * cameraSpeed);
        }

        c_splineDolly.SplineSettings.Position = currentDollyPos;

        // Modificar la variable curentDollyPos para q vaya entre 0 y 1
        // Asignar la variable curentDollyPos a la Position del componente
        //c_splineDolly.SplineSettings.Position = Mathf.PingPong(currentDollyPos, 1);
    }

    #endregion
}
