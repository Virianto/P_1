using UnityEngine;
using System.Collections.Generic;

public class B_MiniContainer : MonoBehaviour
{
    // En esta clase vamos a llevar una cuenta de los objetos que han entrado y
    // cuando llegue a un valor determinado lanzaremos unos fuegos artificiales

    #region ATTRIBUTES

    [SerializeField]
    ParticleSystem fireworks_PS;

    [SerializeField]
    [Range(1,4)]
    int spheresTargetCount = 4;

    List<GameObject> spheresList = new List<GameObject>();

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Cada vez que entre algo en mi trigger quiero....

        // Incluir la esfera en la lista de objetos que tengo declarada
        spheresList.Add(other.gameObject);

        // Comparar si ya he llegado a la cantidad de esferas que espero
        if(spheresList.Count == spheresTargetCount)
        {
            // Este código entre llaves se ejecuta si la respuesta de la comparación es SÍ
            fireworks_PS.Emit(300);
        }
        else
        {
            // Este código entre llaves se ejecuta si la respuesta de la comparación es NO
        }
    }

    #endregion
}
