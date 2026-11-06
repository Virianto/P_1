using UnityEngine;

public class B_PlayerPlane : MonoBehaviour
{

    [Range(0,300)] public float planeSpeed = 2;
    [Range(0,180)] public float angolarSpeed = 90;

    [SerializeField] KeyCode vNegativeTiltKey = KeyCode.W;
    [SerializeField] KeyCode vPositiveTiltKey = KeyCode.S;
    [SerializeField] KeyCode hNegativeTiltKey = KeyCode.A;
    [SerializeField] KeyCode hPositiveTiltKey = KeyCode.D;
    [SerializeField] KeyCode RightTiltKey = KeyCode.E;
    [SerializeField] KeyCode LeftTiltKey = KeyCode.Q;


    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * planeSpeed;   

        //Down (W)
        if (Input.GetKey(vNegativeTiltKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angolarSpeed);
        }
        //Up (S)
        if (Input.GetKey(vPositiveTiltKey))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * angolarSpeed);
        }

        //Left (A)
        if (Input.GetKey(hNegativeTiltKey))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * angolarSpeed);
        }
        //Right (D)
        if (Input.GetKey(hPositiveTiltKey))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * angolarSpeed);
        }
        //Right Tilt (E)
        if (Input.GetKey(RightTiltKey))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * angolarSpeed);
        }
        //Left Tilt (Q)
        if (Input.GetKey(LeftTiltKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angolarSpeed);
        }
    }
}
