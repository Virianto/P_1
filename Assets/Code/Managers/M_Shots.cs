using System.Collections;
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
    bool isShooting = false;

    #endregion


    #region METHODS
    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // Comprobar si tiene algo delante
        if (!isShooting)
        {
            CheckFrontView();
        }

        //Disparar
        if (Input.GetKeyDown(shotKey))
        {
            ShootLaser();
        }
    }

    void CheckFrontView()
    {
        // Crear un ray par indicar como buscar (desde cabina hacia delante)
        Ray searchRay = new Ray(shotOrigin.position, shotOrigin.forward);
        // Crear un raycastHit para guardar info de la búsqueda
        RaycastHit hitInfo;
        // Reaccionar al resultado pintando o despintando el LineRenderer
        if (Physics.Raycast(searchRay, out hitInfo))
        {
            B_Enemy enemyHit = hitInfo.collider.GetComponent<B_Enemy>();

            // Ya se q ha detectado algo: dibujo una línea
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            if (enemyHit != null)
            {
                // Si es un enemigo, pinto laser de X color
                laserLine.startColor = Color.red;
                laserLine.endColor = Color.red;
            }
            else
            {
                // Si NO es un enemigo, pinto laser de Y color
                laserLine.startColor= Color.green;
                laserLine.endColor = Color.green;
            }
        }
        else
        {
            // Como NO he detectado nada, borro la linea
            laserLine.positionCount = 0;
        }
    }

    IEnumerator ShootLaserRoutine()
    {
        // Voy a dibujar el laser (posiciones y color)
        // 1. Recoger el punto de origen
        // Definir una dirección de disparo
        // Almacenar todo eso en una variable temporal ripo Ray
        Ray laser = new Ray(shotOrigin.position, shotOrigin.forward);

        // 2. Definir una variable de tipo RaycastHit para almacenar la información del tiro
        RaycastHit hitInfo;

        // 3. Proyectar el rayo
        // Recoger la info y decidir si ha impactado en algo
        if (Physics.Raycast(laser, out hitInfo))
        {
            // Dibujar una línea entre el punto de origen y de impacto
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            B_Enemy enemy = hitInfo.collider.GetComponent<B_Enemy>();

            if (enemy != null)
            {
                // Cambio color  porque ahora es disparo y a un enemigo
                laserLine.startColor = Color.yellow;
                enemy.ModifyEnemyLifePoints(-10);
            }
        }
        // Esperar 1 frame
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        // Estrechar el laser
        laserLine.widthMultiplier *= 0.8f;
        // Esperar 1 frame
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        // Estrechar el laser
        laserLine.widthMultiplier *= 0.5f;
        // Esperar 1 frame
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        // Estrechar el laser
        laserLine.widthMultiplier *= 0.3f;
        // Esperar 1 frame
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        // Estrechar el laser
        laserLine.widthMultiplier *= 0.1f;

        // Dejarlo como estaba
        laserLine.widthMultiplier = 1;

        // Volver a poner el bool a FALSE
        isShooting = false;
    }
    void ShootLaser()
    {
        isShooting = true;
        StartCoroutine(ShootLaserRoutine());            
    }
    #endregion
}
