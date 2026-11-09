using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_PlaneCameras : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    List<CinemachineCamera> allVirtualCamerasList = new();

    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha0;
    [SerializeField]
    KeyCode secondCameraKey = KeyCode.Alpha1;
    [SerializeField]
    KeyCode thirdCameraKey = KeyCode.Alpha2;
    

    int _currentActiveCameraIndex = 0;

    public int CurrentActiveCameraIndex
    {
        // Cómo se comporta la lectura
        get { return _currentActiveCameraIndex; }

        // Cómo se comporta la escritura (cambios de la variable)
        set
        {
            // Modifico el valor de mi variable privada
            _currentActiveCameraIndex = value;

            // Utilizo el nuevo valor de forma automática
            SwitchToCinemachineCamera();
        }
    }

    #endregion



    #region METHODS

    void Update()
    {

        // Detectar Input del usuario para cambiar la cámara principal

        if (Input.GetKeyDown(firstCameraKey))
        {

            // Saltamos a cámara 0
            // SwitchToCinemachineCamera(0);
            CurrentActiveCameraIndex = 0;

        }
        if (Input.GetKeyDown(secondCameraKey))
        {

            // Saltamos a cámara 1
            // SwitchToCinemachineCamera(1);
            CurrentActiveCameraIndex = 1;

        }
        if (Input.GetKeyDown(thirdCameraKey))
        {

            // Saltamos a cámara 2
            // SwitchToCinemachineCamera(2);
            CurrentActiveCameraIndex = 2;

        }
        

    }

    // Lo llamamos desde el C_SimpleTrigger en Escena
    public void ChangeCamera(int newCamIndex)
    {
        // Lanza una subrutina
        StartCoroutine(MiRutina(newCamIndex));
    }

    public IEnumerator MiRutina(int newCamIndex)
    {
        // Antes de hacer nada, me guardo en qué cámara estaba yo antes:
        int temporaryIndex = CurrentActiveCameraIndex;

        // Saltar de Cámara 0 a cámara newCamIndex
        CurrentActiveCameraIndex = newCamIndex;
        // Esperar Z tiempo (yield return)
        yield return new WaitForSeconds(1);
        // Volver de cámara newCamIndex a cámara 0
        CurrentActiveCameraIndex = temporaryIndex;
        // OP 1 - CurrentActiveCameraIndex = temporaryIndex;
        // OP 2 - CurrentActiveCameraIndex = 0;
    }

    void SwitchToCinemachineCamera()
    {

        // Recorrer la lista entera de Cinemachine cameras
        for (int i = 0; i < allVirtualCamerasList.Count; ++i)
        {


            if (i == CurrentActiveCameraIndex)
            {
                // Para cada cámara, si es la del índice que quiero, le cambio la prioridad a 1
                allVirtualCamerasList[i].Priority = 1;

            }
            else
            {
                // Para cada cámara, si NO es la que quiero, le cambio la prioridad a 0
                allVirtualCamerasList[i].Priority = 0;
            }



        }


    }

    #endregion
}