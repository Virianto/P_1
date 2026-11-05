using UnityEngine;

/// <summary>
/// * Mover de manera constante el objeto asocidao hacia delante
/// * Detectar input del usuario para girar/rotar el objeto asociado
/// * Añadir tecla de teletransporte
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{

    #region ATTRIBUTES

    [Range(0, 300)]
    public float speed = 3;

    [Range(0, 180)]
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

     void Update()
    {
        //Mover el objeto de forma constante hacia delante
        transform.position += transform.forward * Time.deltaTime * speed;

        //Detectar input del usuario para rotar el objeto y maniobrar
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
