using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class M_Shots : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    Transform shotOrigin;

    [SerializeField]
    KeyCode shotKey = KeyCode.F;

    LineRenderer laserLine;
    #endregion


    #region METHODS
    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(shotKey))
        {
            //Disparar
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // 1. Recoger el punto de origen
        // Definir una dirección de disparo
        // Almacenar todo eso en una variable temporal ripo Ray
        Ray laser = new Ray(shotOrigin.position, shotOrigin.forward);

        // 2. Definir una variable de tipo RaycastHit para almacenar la información del tiro
        RaycastHit hitInfo;

        // 3. Proyectar el rayo
        // Recoger la info y decidir si ha impactado en algo
        if(Physics.Raycast(laser, out hitInfo))
        {
            // Dibujar una línea entre el punto de origen y de impacto
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            B_Enemy enemy = hitInfo.collider.GetComponent<B_Enemy>();

            if (enemy != null)
            {
                enemy.ModifyEnemyLifePoints(-10);
            }
        }
            
    }
    #endregion
}
