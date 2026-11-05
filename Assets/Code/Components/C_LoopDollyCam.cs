using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// x Asignar una cámara Cinemachine con la extenisón de Dolly
/// * Controlar la velocidad de movimiento de mi cámara
/// * Movimiento en bucle a lo largo del Spline Container
/// </summary>
public class C_LoopDollyCam : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    [Range(0, 1)]
    float cameraSpeed = 0.2f;

    CinemachineSplineDolly c_splineDolly;

    /*float currentDollyPos = 0;
    bool goingForward = true;*/

    #endregion



    #region METHODS

    private void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();

        
    }

    private void Update()
    {        
       
        /*if(currentDollyPos == 1)
        {
            goingForward = false;
        }
        if(currentDollyPos == 0)
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

        }*/


        //c_splineDolly.SplineSettings.Position = currentDollyPos;
        // Modificar la variable currentDollyPos para que vaya entre 0 y 1


        // Asignar la variable currentDollyPos a la Position del componente
        //c_splineDolly.SplineSettings.Position = Mathf.PingPong(0, 1);
        
        c_splineDolly.SplineSettings.Position = Mathf.PingPong(Time.time * cameraSpeed, 1);


    }

    public void SetNewCameraSpeed(float newSpeed)
    {
        cameraSpeed = newSpeed;

    }


    #endregion
}