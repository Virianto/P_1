using UnityEngine;

public class C_Translator : MonoBehaviour
{
    [SerializeField] Vector3 movement = Vector3.forward;
    [SerializeField] float speed = 5f;

    private void Update()
    {

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
