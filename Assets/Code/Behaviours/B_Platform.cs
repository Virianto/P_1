using UnityEngine;

public class B_Platform : MonoBehaviour
{
    #region ATTRIBUTES

    // GameObject con mayúscula no es más que el nombre genérico de la clase
    // igual que si escribo Vetor3 o Transform (con mayúscula)
    GameObject myLastCollisionObject;

    [SerializeField]
    Material newSphereMaterial;

    #endregion

    #region METHODS

    void OnCollisionEnter(Collision col)
    {
        // Recojo referencia al objeto y me la guardo de forma persistente
        myLastCollisionObject = col.gameObject;
    }

    void OnCollisionExit(Collision col)
    {
        // Voy a utilizar mi referencia persistente (aunque podría usar col también)
        // y le voy a modificar el material usando otra variable global
        myLastCollisionObject.GetComponent<MeshRenderer>().material = newSphereMaterial;
    }

    #endregion
}
