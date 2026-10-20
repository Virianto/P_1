using UnityEngine;

public class C_Translator : MonoBehaviour
{
    //EJERCICIO: escribir el codigo necesario para mover un objeto en una direccion (editable)
    // aplicandole una velocidad (editable)

    [SerializeField]
    Vector3 movimiento = Vector3.zero;
    [SerializeField]
    float velocidad = 1;

    private void Update()
    {
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }
}
