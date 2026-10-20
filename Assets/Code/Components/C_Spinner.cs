using UnityEngine;

public class C_Spinner : MonoBehaviour
{
    #region ATTRIBUTES

    // Eje de rotación
    [SerializeField]
    Vector3 rotationAxis = Vector3.up;

    // Velocidad de rotación
    [SerializeField]
    [Range(-180, 180)]
    float rotationSpeed = 45;

    #endregion

    #region METHODS

    // Rotar en el eje indicado, aplicando la velocidad seleccionada
    void Update()
    {
        // Acceder al transform del objeto asociado a este script
        // Modificar la rotación de ese transform usando las variables
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    #endregion
}
