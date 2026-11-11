using UnityEngine;

public class EthanPlaneController : MonoBehaviour
{
    [Range(5, 100)] public float planeSpeed; //Normalmete 5
    [Range(0, 180)] public float angularSpeed = 100;

    [Header("KEY BINDS")]
    [SerializeField] KeyCode down = KeyCode.W;
    [SerializeField] KeyCode up = KeyCode.S;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode RightTiltKey = KeyCode.E;
    [SerializeField] KeyCode LeftTiltKey = KeyCode.Q;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * planeSpeed;
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    planeSpeed = 50;
        //    M_FlightSim.Instance.ChangeCam(2);
        //}
        //else
        //{
        //    planeSpeed = 5;
        //    M_FlightSim.Instance.ChangeCam(0);
        //}

        //Down (W)
        if (Input.GetKey(down))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        }
        //Up (S)
        if (Input.GetKey(up))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * angularSpeed);
        }

        //Left (A)
        if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * angularSpeed);
        }
        //Right (D)
        if (Input.GetKey(right))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * angularSpeed);
        }
        //Right Tilt (E)
        if (Input.GetKey(RightTiltKey))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * angularSpeed);
        }
        //Left Tilt (Q)
        if (Input.GetKey(LeftTiltKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
        }

        
    }
}
