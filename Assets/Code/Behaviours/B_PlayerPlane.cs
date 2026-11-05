using UnityEngine;

public class B_PlayerPlane : MonoBehaviour
{

    [Range(0,300)] public float planeSpeed = 2;
    [Range(0,180)] public float angolarSpeed = 90;

    [SerializeField] KeyCode vNegativeTiltKey = KeyCode.W;
    [SerializeField] KeyCode vPositiveTiltKey = KeyCode.S;
    [SerializeField] KeyCode hNegativeTiltKey = KeyCode.A;
    [SerializeField] KeyCode hPositiveTiltKey = KeyCode.D;


    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * planeSpeed;   

        if (Input.GetKey(vNegativeTiltKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angolarSpeed);
        }
        if (Input.GetKey(vPositiveTiltKey))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * angolarSpeed);
        }
        if (Input.GetKey(hNegativeTiltKey))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * angolarSpeed);
        }
        if (Input.GetKey(hPositiveTiltKey))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * angolarSpeed);
        }
    }



}
