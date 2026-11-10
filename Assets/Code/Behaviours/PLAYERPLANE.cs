using UnityEngine;

// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class PLAYERPLANE : MonoBehaviour
{
    #region ATTRIBUTES
    [Range(0, 400)]
    public float speed = 3;
    [Range(0, 300)]
    public float angularSpeed = 3;
    [SerializeField]
    KeyCode vNegativeTilKey = KeyCode.W;
    [SerializeField]
    KeyCode vPositiveTilKey = KeyCode.S;
    [SerializeField]
    KeyCode hPositiveTilKey = KeyCode.D;
    [SerializeField]
    KeyCode hNegativeTilKey = KeyCode.A;
    #region METHODS

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        if (Input.GetKey(vPositiveTilKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        }

        if (Input.GetKey(vNegativeTilKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(hNegativeTilKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(hPositiveTilKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(hNegativeTilKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        }
   
    }
    #endregion
}


    #endregion



