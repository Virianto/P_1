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

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(shotKey))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // PASO 1
        // Recoger el punto de origen
        // Definir una dirección de disparo
        // Almacenar todo eso en una variable temporal de tipo Ray
        Ray laser = new Ray(shotOrigin.position, shotOrigin.forward);

        // PASO 2
        // Definir una variable de tipo RayCastHit para almacenar la información del tiro
        RaycastHit hitInfo;

        // PASO 3
        // - Proyectar el rayo
        // - Recoger información y decidir qué hacer si ha impactado en algo
        if(Physics.Raycast(laser, out hitInfo))
        {
            // Dibujar una línea entre el punto de origen y el de impacto
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            B_EvilBalloon enemy = hitInfo.collider.GetComponent<B_EvilBalloon>();

            if (enemy != null)
            {
                enemy.ModifyBalloonLifePoints(-10);
            }
        }
    }

    #endregion
}
