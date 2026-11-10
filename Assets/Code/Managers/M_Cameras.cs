<<<<<<< HEAD

using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

/// <summary>
///tener referemncias a todas las camara virtuales de la escena
///detectar imput de usuario para saltar de una camara a otra 
/// </summary>
public class M_Cameras : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]

=======
using Code.Utils;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// * Detectar Input de usuario para saltar de una cámara a otra
/// </summary>
public class M_Cameras : Singleton<M_Cameras>
{
    #region ATTRIBUTES

    [SerializeField]
>>>>>>> develop
    List<CinemachineCamera> allVirtualCamerasList = new();

    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha0;

    [SerializeField]
<<<<<<< HEAD
    KeyCode secondCameaKey = KeyCode.Alpha1;
=======
    KeyCode secondCameraKey = KeyCode.Alpha1;
>>>>>>> develop

    [SerializeField]
    KeyCode tertiaryCameraKey = KeyCode.Alpha2;

    [SerializeField]
<<<<<<< HEAD
    KeyCode cuartiaryCameraKey = KeyCode.Alpha3;

    [SerializeField]
    KeyCode quintaCameraKey = KeyCode.Alpha4;

    [SerializeField]
    KeyCode sextaCameraKey = KeyCode.Alpha5;
=======
    KeyCode fourthCameraKey = KeyCode.Alpha3;

    [SerializeField]
    KeyCode fifthCameraKey = KeyCode.Alpha4;

    [SerializeField]
    KeyCode sixthCameraKey = KeyCode.Alpha5;
>>>>>>> develop

    int _currentActiveCameraIndex = 0;

    public int CurrentActiveCameraIndex
    {
<<<<<<< HEAD
        get { return _currentActiveCameraIndex; }

        set 
        { 
            _currentActiveCameraIndex = value; 
            SwichToCinemachineCamera();
        }
    }
    #endregion


    #region METHODS 
    private void Update()
    {
        if(Input.GetKeyDown(firstCameraKey))
        {
            CurrentActiveCameraIndex = 0;
        }
    
        if(Input.GetKeyDown(secondCameaKey))
        {
            CurrentActiveCameraIndex = 1;
        }
    
=======
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
        if (Input.GetKeyDown(firstCameraKey)) 
        {
            CurrentActiveCameraIndex = 0;
        }
        if (Input.GetKeyDown(secondCameraKey))
        {
            CurrentActiveCameraIndex = 1;
        }
>>>>>>> develop
        if (Input.GetKeyDown(tertiaryCameraKey))
        {
            CurrentActiveCameraIndex = 2;
        }
<<<<<<< HEAD
        if (Input.GetKeyDown(cuartiaryCameraKey))
        {
            CurrentActiveCameraIndex = 3;
        }
        if (Input.GetKeyDown(quintaCameraKey))
        {
            CurrentActiveCameraIndex = 4;
        }

        if (Input.GetKeyDown(sextaCameraKey))
=======
        if (Input.GetKeyDown(fourthCameraKey))
        {
            CurrentActiveCameraIndex = 3;
        }
        if (Input.GetKeyDown(fifthCameraKey))
        {
            CurrentActiveCameraIndex = 4;
        }
        if (Input.GetKeyDown(sixthCameraKey))
>>>>>>> develop
        {
            CurrentActiveCameraIndex = 5;
        }
    }

<<<<<<< HEAD
    void SwichToCinemachineCamera ()
    {
        for (int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if (i  == CurrentActiveCameraIndex)
            
            {
=======
    // Lo llamamos desde el C_SimpleTrigger en Escena
    public void ChangeCamera(int newCamIndex)
    {
        StartCoroutine(MiRutina(newCamIndex));
    }

    IEnumerator MiRutina(int newCamIndex)
    {
        // Antes de hacer nada, me guardo en qué cámara estaba yo antes:
        int temporaryIndex = CurrentActiveCameraIndex;

        // Saltar de Cámara 0 a cámara newCamIndex
        CurrentActiveCameraIndex = newCamIndex;
        // Esperar Z tiempo (yield return)
        yield return new WaitForSeconds(1);
        // Volver de cámara newCamIndex a cámara 0
        // OP 1 - CurrentActiveCameraIndex = temporaryIndex;
        // OP 2 - CurrentActiveCameraIndex = 0;
    }

    void SwitchToCinemachineCamera()
    {
        // Recorrer la lista entera de cinemachine cameras
        for(int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if(i == CurrentActiveCameraIndex)
            {
                // Para cada cámara, si es la del índice que quiero, le cambio la priroridad a 1
>>>>>>> develop
                allVirtualCamerasList[i].Priority = 1;
            }
            else
            {
<<<<<<< HEAD
                allVirtualCamerasList[i].Priority = 0;
            }
        }
     
        

    }
=======
                // Para cada cámara, si NO es la que quiero, le cambio la prioridad a 0
                allVirtualCamerasList[i].Priority = 0;
            }
        }
    }

>>>>>>> develop
    #endregion
}
