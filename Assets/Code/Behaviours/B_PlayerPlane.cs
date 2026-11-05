using UnityEngine;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES
    [Range(0, 300)]
    public float speed = 2;

    [Range(0, 300)]
    public float angularSpeed = 90;

    [SerializeField] KeyCode vPositiveTiltKey = KeyCode.W;
    [SerializeField] KeyCode vNegativeTiltKey = KeyCode.S;
    [SerializeField] KeyCode hPositiveTiltKey = KeyCode.D;
    [SerializeField] KeyCode hNegativeTiltKey = KeyCode.A;


    #endregion

    #region METHODS
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(hNegativeTiltKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(hPositiveTiltKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(vNegativeTiltKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(vPositiveTiltKey))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
        }
    }

    #endregion
}
