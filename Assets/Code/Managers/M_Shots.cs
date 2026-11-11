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
    KeyCode shotkey = KeyCode.F;

    LineRenderer laserLine;

    bool isShooting = false;

    #endregion





    #region METHODS

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // Comprobar si tenemos algo sólido delante
        if (isShooting == false)
        {
            CheckFrontView();
        }

            // Si pulsamos la tecla de disparo...
            if (Input.GetKeyDown(shotkey))
        {
            // Disparar
            ShootLaser();
        }
    }

    void CheckFrontView()
    {
        // Crear un Ray para indicar cómo buscar
        Ray searchRay = new Ray(shotOrigin.position, shotOrigin.forward);

        // Crear un RaycastHit para guardar información de la búsqueda
        RaycastHit hitInfo;

        // Reaccionar al resultado pintando o despintando el LineRenderer
        if (Physics.Raycast(searchRay, out hitInfo))
        {
            B_FlyingEnemy enemyHit = hitInfo.collider.GetComponent<B_FlyingEnemy>();

            // Una vez detectado algo dibujo una línea
            // * Dibujar una línea entre el punto de origen y el punto de impacto
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            if (enemyHit != null)
            {
                // Si es un enemigo pinto el laser de un color
                laserLine.startColor = Color.red;
            }
            else
            {
                // Si no es un enemigo pinto el lase de otro color
                laserLine.startColor = Color.green;
            }
        }
        else
        {
            // Si no detectamos nada...
            // * No pintar nada
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
                // Cambiamos el color
                laserLine.startColor = Color.yellow;
                flyingEnemy.ModifyFlyingEnemyLifePoints(-10);
            }
        }

        // Esperar un frame
        yield return new WaitForSeconds(0.1f);

        // Estrechar el láser
        laserLine.widthMultiplier *= 0.5f;

        // Esperar un frame
        yield return new WaitForSeconds(0.1f);

        // Estrechar el láser
        laserLine.widthMultiplier *= 0.5f;

        // Esperar un frame
        yield return new WaitForSeconds(0.1f);

        // Estrechar el láser
        laserLine.widthMultiplier *= 0.5f;

        // Esperar un frame
        yield return new WaitForSeconds(0.1f);

        // Estrechar el láser
        laserLine.widthMultiplier *= 0.5f;

        // Dejar el láser como estaba
        laserLine.widthMultiplier = 1;

        // Volver a poner el booleano a false
        isShooting = false;
    }

    #endregion
}