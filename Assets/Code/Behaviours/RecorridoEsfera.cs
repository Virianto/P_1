using UnityEngine;

public class RecorridoEsfera : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 3f;
    public bool ida_y_vuelta = true;

    private Transform destino;

    void Start()
    {
        transform.position = puntoA.position;
        destino = puntoB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            destino.position,
            velocidad * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, destino.position) < 0.05f)
        {
            if (ida_y_vuelta)
                destino = (destino == puntoA) ? puntoB : puntoA;
            else
                enabled = false; // se detiene al llegar
        }
    }
}