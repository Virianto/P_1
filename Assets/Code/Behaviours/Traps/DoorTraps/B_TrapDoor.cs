using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Trampa para atrapar al NPC. Cuando este toca la puerta, se desactiva.
/// </summary>
public class B_TrapDoor : MonoBehaviour
{
    #region ATTRIBUTES
    public bool isUp = false;
    [SerializeField] List<Transform> routePointList = new();
    [SerializeField] [Range(1, 10)] float speed = 2;
    [SerializeField] GameObject childCollider;
    Transform targetPosition =null;
    Vector3  currentPosition;
    #endregion

    #region METHODS
    void Update()
    {
        if (targetPosition == null)
        {
            return;
        }
        Vector3 middlePoint = Vector3.MoveTowards
                (transform.position, targetPosition.position, Time.deltaTime * speed);

        transform.position = middlePoint;

        if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f)
        {
            transform.position = targetPosition.position;
            targetPosition = null;

            if(isUp)
            {
                childCollider.SetActive(true);
            }
            else
            {
                childCollider.SetActive(false);
            }
        }
    }

    public void MoveTrapDoor()
    {
        currentPosition = transform.position;
        if (isUp)
        {
            //subir la trampa
            Debug.Log("subiendo la trampa");
            targetPosition=routePointList[0];
            //childCollider.SetActive(true);
        }
        if (!isUp)
        {
            //bajar la trampa
            Debug.Log("bajando la trampa");
            targetPosition = routePointList[1];
            //childCollider.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trap door area.");
            // Aquí puedes agregar la lógica para atrapar al jugador
            // Por ejemplo, desactivar el jugador o aplicar daño
        }
    }

    #endregion
}
