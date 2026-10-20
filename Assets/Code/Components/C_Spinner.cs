using UnityEngine;

public class C_Spinner : MonoBehaviour
{
    #region ATTRIBUTES

    // eje de rotacion
    //Vector3 rotationAxis = new Vector3(0, 0, 0); // FORMA1
    [SerializeField]
    Vector3 anotherRotationAxis = Vector3.forward; // FORMA2

    // velocidad de rotacion
    [SerializeField]
    [Range(-180, 180)]
    float rotationSpeed = 45; 

    #endregion

    #region METHODS

    // rotar en el eje indicado aplicando la velocidad seleccionada
    void Update()
    {
        // acceder al transfrom del objeto asociado a este script
        // modificar la rotacion de ese tansfrom usando las variables
        transform.Rotate(anotherRotationAxis * rotationSpeed * Time.deltaTime);
    }

    #endregion
}
