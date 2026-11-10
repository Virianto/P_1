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
        if (Input.GetKeyDown(shotKey))
        {
            // Disparar
            ShootLaser();
        }
    }
    void ShootLaser()
    {
        // PASO 1
        // Recoger punto de origen
        // Definir una dirección de disparo
        // Almacenar todo eso en una variable temporal de tipo Ray
        Ray laser = new Ray(shotOrigin.position, shotOrigin.forward);

        // PASO 2
        // Definir una variable detipo RayCastHit para almacenar la información del tiro
        RaycastHit hitInfo;

        // PASO 3
        // - Proyectar el rayo
        // - Recoger información
        // _ Decidir qué hacer si ha impactado en algo
        if (Physics.Raycast(laser, out hitInfo))
        {
            // Dibujar una línea entre el punto de origen y el de impacto
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            B_Enemies enemy = hitInfo.collider.GetComponent<B_Enemies>();
            if (enemy != null)
            {
                enemy.ModifyEnemyLifePoints(-10);

            }
        }

    }

    #endregion
}