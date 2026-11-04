using UnityEngine;

[RequireComponent(typeof(B_Vida1))]
public class B_BarraVida : MonoBehaviour
{
    public float altura = 2.5f;
    public float ancho = 1f;

    B_Vida1 vida;
    Transform raiz, pivote;
    Camera cam;

    void Awake()
    {
        vida = GetComponent<B_Vida1>();
        Crear();
    }

    GameObject Cubo(string nombre, Transform padre, Color color)
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = nombre;
        Destroy(go.GetComponent<Collider>());
        go.transform.SetParent(padre, false);
        go.GetComponent<Renderer>().material.color = color;
        return go;
    }

    void Crear()
    {
        raiz = new GameObject("BarraVida").transform;
        raiz.SetParent(transform, false);
        raiz.localPosition = new Vector3(0f, altura, 0f);

        var fondo = Cubo("Fondo", raiz, new Color(0.25f, 0f, 0f));
        fondo.transform.localScale = new Vector3(ancho + 0.04f, 0.14f, 0.02f);

        pivote = new GameObject("Pivote").transform;
        pivote.SetParent(raiz, false);
        pivote.localPosition = new Vector3(-ancho / 2f, 0f, -0.02f);

        var relleno = Cubo("Relleno", pivote, Color.green);
        relleno.transform.localPosition = new Vector3(ancho / 2f, 0f, 0f);
        relleno.transform.localScale = new Vector3(ancho, 0.1f, 0.02f);

        Debug.Log("Barra de vida creada en: " + name);
    }

    void LateUpdate()
    {
        if (vida == null || pivote == null || vida.vidaMaxima <= 0f) return;

        float f = Mathf.Clamp01(vida.vida / vida.vidaMaxima);
        pivote.localScale = new Vector3(Mathf.Max(f, 0.0001f), 1f, 1f);

        if (cam == null) cam = Camera.main;
        if (cam != null) raiz.rotation = cam.transform.rotation;
    }
}