using UnityEngine;

/// <summary>
/// mover de manera constante hacia adelante
/// input usuario para girar o rotar el objeto
/// teletransporte
/// </summary>
public class abiom_pleyer : MonoBehaviour
{
    #region ATTRIBUTES

    [Range(0,300)]
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
        //mover de forma constante el objeto hacia delante 
        transform.position += transform.forward * Time.deltaTime * speed;
        if (Input.GetKey(vNegativeTiltKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime*angularSpeed);
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
