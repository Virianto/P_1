using UnityEngine;

public class C_Spinner : MonoBehaviour
{
    #region ATTRIBUTES
    // Eje de rotacion
    [SerializeField] Vector3 rotationAxis = Vector3.forward;            //FORMA 1. tambien puedes hacer "rotationAxis = Vector3.zero;" para que los 3 números sean 0 ya que usas [SerializeField] para editar
    //[SerializeField] Vector3 arotationAxis = new Vector3 (0, 0, 0);   //FORMA 2

    // Velocidad de rotacion
    [SerializeField] [Range(-1000, 1000)] float rotationSpeed; // Range es un slider -----o-- para el unity editor
    #endregion

    #region METHODS
    // Rotando en el eje indicado, aplicando la velocidad selleccionada
    private void Update()
    {
        // Acceder al transform del objeto
        // Modificar la rotacion 
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    #endregion
}
