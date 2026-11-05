using UnityEngine;

/// <summary>
/// * Mover de manera constante el objeto asociado hacia delante
/// * Detectar Input de usuario para girar o rotar el objeto asociado
/// * Añadir tecla de teletransporte
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{

    #region ATTRIBUTES

    [Range(0, 300)]
    public float speed = 3;

    [Range(0, 300)]
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
        // Mover de forma constante el objeto hacia arriba
        transform.position += transform.forward * Time.deltaTime * speed;

        // Detectar Input del usuario para rotar el objeto y así maniobrar
        if (Input.GetKey(vNegativeTiltKey))
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