using UnityEngine;

/// <summary>
/// * Mover de manera constante hacia delante
/// * Detectar input de usuario para girar y rotar el objeto
/// * Añadir tecla de tp
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES
    [Range(0,100)]
    public float speed = 3;

    [Range(0, 100)]
    public float angularSpeed = 90;

    [SerializeField]
    KeyCode vNegativeTiltKey = KeyCode.W;

    [SerializeField]
    KeyCode vPositiveTiltKey = KeyCode.S;

    [SerializeField]
    KeyCode hNegativeTiltKey = KeyCode.A;

    [SerializeField]
    KeyCode hPositiveTiltKey = KeyCode.D;
    #endregion


    #region METHODS
    private void Update()
    {
        // Mover de manera constante hacia delante
        transform.position += transform.forward * Time.deltaTime * speed;

        // Detectar input de usuario para girar y rotar el objeto
        if(Input.GetKey(vNegativeTiltKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(vPositiveTiltKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(hNegativeTiltKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(hPositiveTiltKey))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
        }
    }

    #endregion
}
