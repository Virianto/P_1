using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// Asignar una cámara cinemachine con la extensión de dolly
/// Controlar la velocidad de movimiento de mi cámara
/// Movimiento de vaiven a lo largo del Spline Container
/// </summary>
public class C_PingPongDollyCam : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    [Range(0f, 1f)]
    float camSpeed = 0.2f;
    float currentDollyPos = 0;
    bool goingForward = false;
    CinemachineSplineDolly c_splineDolly;

    #endregion

    #region METHODS

    private void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();
    }

    private void Update()
    {
        if (currentDollyPos == 1)
            goingForward = false;
        else if (currentDollyPos == 0)
            goingForward = true;
        //if (currentDollyPos == 1 ?  goingForward = false : goingForward = true)

        if (goingForward)
            //Incremento la variable local una fracción de frame
            currentDollyPos = Mathf.Clamp01(currentDollyPos + Time.deltaTime);
        else
            currentDollyPos = Mathf.Clamp01(currentDollyPos - Time.deltaTime);

        c_splineDolly.SplineSettings.Position = currentDollyPos;

        ////Modificar la variable currentDollyPos para que vaya entre 0 y 1
        ////Asignar la variable current... a la pos del cmponente
        //c_splineDolly.SplineSettings.Position = Mathf.PingPong(currentDollyPos, 1);
    }

    #endregion
}
