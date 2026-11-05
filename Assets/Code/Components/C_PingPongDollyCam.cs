using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// * Asignar una cámara cnemachine con la extensión de dolly
/// * Cpntrolar la velocidad de movimiento de mi cámara
/// * Movimiento de vaivén a lo largo del Spline container
/// </summary>
public class C_PingPongDollyCam : MonoBehaviour
{
    #region ATTRIBUTES

    CinemachineSplineDolly c_splineDolly;
    [SerializeField]
    [Range(0, 1)]
    float camSpeed = 0.2f;
    private float currentDollyPos;
    bool goingForward = true;

    #endregion

    #region METHODS

    void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();
    }

    private void Update()
    {
        if (goingForward)
        {
            //incremento la variable local una fraccion de frame
            currentDollyPos = Mathf.Clamp01(currentDollyPos + Time.deltaTime*camSpeed);
            
        } else
        {
            currentDollyPos = Mathf.Clamp01(currentDollyPos - Time.deltaTime*camSpeed);
        }

        if(currentDollyPos == 1)
        {
            goingForward = false;
        }
        else if (currentDollyPos == 0)
        {
            goingForward = true;
        }
        c_splineDolly.SplineSettings.Position = currentDollyPos;
        //modificar la variable currentDollyPos para que vaya entre 0 y 1.
        //asignar la variable currentDollyPos a la posicion del componente

    }
    #endregion
}
