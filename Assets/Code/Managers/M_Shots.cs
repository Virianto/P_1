using System.Collections;
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

    bool isShooting = false;

    #endregion

    #region METHODS

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Comprobar si tengo algo sólido delante
        if (!isShooting)
        {
            CheckFrontView();
        }        

        // Disparar si se pulsa una tecla
        if (Input.GetKeyDown(shotKey))
        {
            ShootLaser();
        }
    }

    void CheckFrontView()
    {
        // Crear un Ray para indicar cómo buscar: Desde cabina hacia delante
        Ray searchRay = new Ray(shotOrigin.position, shotOrigin.forward);

        // Crear un RaycastHit para guardar información de la búsqueda
        RaycastHit hitInfo;

        // Reaccionar al resultado pintando o despintando el LineRenderer
        if(Physics.Raycast(searchRay, out hitInfo))
        {
            B_EvilBalloon enemyHit = hitInfo.collider.GetComponent<B_EvilBalloon>();

            // Ya sé que he detectado algo: DIBUJO UNA LÍNEA
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            if (enemyHit != null)
            {
                // Si es un enemigo, pinto el láser de X color
                laserLine.startColor = Color.red;
            }
            else
            {
                // Si NO es un enemigo, pinto el láser de Y color
                laserLine.startColor = Color.green;
            }
        }
        else
        {
            // Como NO he detectado nada: BORRO LA LÍNEA
            laserLine.positionCount = 0;
        }
    }

    void ShootLaser()
    {
        isShooting = true;
        StartCoroutine(ShootLaserRoutine());        
    }

    IEnumerator ShootLaserRoutine()
    {
        // Dibujar el láser (posiciones y color)

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
        if (Physics.Raycast(laser, out hitInfo))
        {
            // Dibujar una línea entre el punto de origen y el de impacto
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            B_EvilBalloon enemy = hitInfo.collider.GetComponent<B_EvilBalloon>();

            if (enemy != null)
            {                
                laserLine.startColor = Color.yellow;
                enemy.ModifyBalloonLifePoints(-10);
            }
        }

        // Esperar 1 frame
        yield return new WaitForEndOfFrame();

        // Estrechar el  láser
        laserLine.widthMultiplier *= 0.5f;
        
        yield return new WaitForEndOfFrame();
        
        laserLine.widthMultiplier *= 0.5f;
       
        yield return new WaitForEndOfFrame();
       
        laserLine.widthMultiplier *= 0.5f;
        
        yield return new WaitForEndOfFrame();

        // Dejar el láser como estaba
        laserLine.widthMultiplier = 1;

        // Volver a poner el booleano a FALSE
        isShooting = false;
    }

    #endregion
}
