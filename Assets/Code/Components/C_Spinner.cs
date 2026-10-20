using UnityEngine;

public class C_Spinner : MonoBehaviour
{
    #region ATTRIBUTES
    // Eje de rotación
    // Vector3 rotationAxis = new Vector3(0, 0, 0); // Forma 1
    [SerializeField] Vector3 rotationAxis = Vector3.up;
    // Vector3 anotherRotationAxis = Vector3.forward; // Forma 2

    // Velocidad de rotación

    [SerializeField] // Permite editar desde Unity
    [Range(-180, 180)] // 
    float rotationSpeed = 45;
    #endregion



    #region METHODS
    // Rotar en el eje indicado aplicando la velocidad seleccionada
    private void Update()
    {
        // Acceder al transform del objeto asociado al script
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        // Modificar la rotación de el transform usando las variables
    }

    #endregion


}
