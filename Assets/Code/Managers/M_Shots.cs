using UnityEngine;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_Shots : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Transform shotOrigin;

    [SerializeField]
    KeyCode shotkey = KeyCode.F;

    LineRenderer laserLine;

    #endregion





    #region METHODS

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shotkey))
        {
            // Disparar
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // * Recoger el punto de origen
        // * Definir una dirección de disparo
        // * Almacenar todo en una variable temporal de tipo Ray
        Ray laser = new Ray(shotOrigin.position, shotOrigin.forward);

        // Definir una variable de tipo RayCastHit para almacenar la información
        RaycastHit hitInfo;

        // * Proyectar el rayo
        // * Recoger la información y decidir qué hacer si ha impactado en algo
        if (Physics.Raycast(laser, out hitInfo))
        {
            // Dibujar una línea entre el punto de origen y el punto de impacto
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            B_FlyingEnemy flyingEnemy = hitInfo.collider.GetComponent<B_FlyingEnemy>();

            if (flyingEnemy != null)
            {
                flyingEnemy.ModifyFlyingEnemyLifePoints(-10);
            }
        }
    }

    #endregion
}