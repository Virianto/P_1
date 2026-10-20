using UnityEngine;

public class C_Spinner : MonoBehaviour
{
    #region ATTRIBUTES

    //Eje de rotación
    [SerializeField]
    Vector3 rotationAxis = Vector3.forward;

    //Velocidad de rotación
    [SerializeField]
    [Range(-180,180)]
    float rotationSpeed = 45;

    #endregion

    #region METHODS

    //Rotar en el eje indicado, aplicando la velocidad seleccionada
    private void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    void OnMouseDown()
    {
        Debug.Log("Me has desactivado o activado");
        GetComponent<C_Spinner>().enabled = !GetComponent<C_Spinner>().enabled;
    }

    #endregion

}
