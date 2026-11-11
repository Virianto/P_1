using Unity.Cinemachine;
using UnityEngine;

public class M_ShootPlane : MonoBehaviour
{

    [SerializeField] Transform shootOrigin;
    LineRenderer shotLine;


    void Awake()
    {
        shotLine = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootLaser();
        }
    }
    void ShootLaser()
    {
        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo))
        {
            shotLine.positionCount = 2;
            shotLine.SetPosition(0, shootOrigin.position);
            shotLine.SetPosition(1, hitInfo.point);
        }

        
    }

}
