using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_Enemies : MonoBehaviour
{
    #region ATTRIBUTES

    M_SpawnEnemies myManager;

    #endregion
    #region METHODS

    public void InitializeRing(M_SpawnEnemies manager, Vector3 newPosition, int vida)
    {
        myManager = manager;
        transform.position = newPosition;
    }

    void OnTriggerEnter(Collider other)
    {

        B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();
        M_Cameras camera = other.GetComponent<M_Cameras>();
        if (player != null)
        {
            Debug.Log("Me e echo daño");
            player.ModifyPlayerLife(-1);
            // Busco al manager de cámaras y le hago un cambio temporal a la cámara de sacudida
            camera.EnterRingDamage(1);
        }
    #endregion
    }
}

