using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class M_ShootPlane : MonoBehaviour
{

    [SerializeField] Transform shootOrigin;
    LineRenderer laserLine;
    bool isShooting = false;


    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (!isShooting)
        {
            CheckFrontView();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootLaser();
        }
    }
    void CheckFrontView()
    {
        Ray shearchRay = new Ray(shootOrigin.position, shootOrigin.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(shearchRay, out hitInfo))
        {
            B_EthanEnemies enemyHit = hitInfo.collider.GetComponent<B_EthanEnemies>();
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shootOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            if (enemyHit != null)
            {
                laserLine.startColor = Color.red;
                enemyHit.EnemyLifePoints(-10);
            }
            else
            {
                laserLine.startColor = Color.green;

            }
        }
        else
        {
            laserLine.positionCount=0;
        }

    }

    void ShootLaser()
    {
        isShooting = true;
        StartCoroutine(ShootLaserRoutine());
    }




        IEnumerator ShootLaserRoutine()
        {
            Ray laser = new Ray(shootOrigin.position, shootOrigin.forward);
            RaycastHit hitInfo;

           
            if (Physics.Raycast(laser, out hitInfo))
            {
              
                laserLine.positionCount = 2;
                laserLine.SetPosition(0, shootOrigin.position);
                laserLine.SetPosition(1, hitInfo.point);

                B_EthanEnemies enemy = hitInfo.collider.GetComponent<B_EthanEnemies>();

                if (enemy != null)
                {
                    laserLine.startColor = Color.yellow;
                    enemy.EnemyLifePoints(-10);
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

}
