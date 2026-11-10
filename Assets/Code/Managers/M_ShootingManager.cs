using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_ShootingManager : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    Transform originOfShoot;

    [SerializeField]
    KeyCode shootingKey = KeyCode.L;


    LineRenderer laserLine;
    #endregion


    #region METHODS

    void Awake()
    {
      laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {

        if (Input.GetKeyDown(shootingKey))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        //PASO 1
        //Recoger el punto de origen
        //Definir una dirección de disparo
        //Almacenar eso en una variable temporal de tipo RAY
        
        Ray ray = new Ray(originOfShoot.position, originOfShoot.forward);
        
        //PASO 2
        //Definir una variable de tipo RayCastHit para almacenar la información del tiro

        RaycastHit hitInfo;

        //PASO 3
        //Proyectar el rayo
        //Recoger información y decidir qué hacer si ha impactado en algo

        if (Physics.Raycast(ray, out hitInfo)) 
        {
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, originOfShoot.position);
            laserLine.SetPosition(1, hitInfo.point);


            B_Enemy enemy = hitInfo.collider.GetComponent<B_Enemy>();
            if(enemy != null)
            {
                enemy.ModifyEnemyLifePoints(-10);
            }
        }
    }
    #endregion
}
