using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurret : MonoBehaviour
{
    private TankController controller;
    private Vector3 currentRotation;
    [SerializeField] private float rotationSpeed;
    private Transform tankTurret;
    public void Init(TankController controller, Transform turret)
    {
        this.tankTurret = turret;
        this.controller = controller;
    }
    public Vector3 GetCurrentRotation()
    {
        return currentRotation;
    }
    public void AimPosListener(Vector3 aimPos)
    {
        aimPos -= this.transform.position;
        aimPos = aimPos.normalized;
        aimPos = new Vector3(aimPos.x, 0, aimPos.z);
        RotateTowardsMouse(aimPos);
    }
    void RotateTowardsMouse(Vector3 aimPos)
    {
        Vector3 dir = GetRotationDir(aimPos);
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        tankTurret.localRotation = Quaternion.AngleAxis(angle + 90, Vector3.up);
    }

    Vector3 GetRotationDir(Vector3 aimPos)
    {
        currentRotation = Vector3.RotateTowards(currentRotation, aimPos, rotationSpeed * Time.deltaTime, 10f);
        currentRotation = currentRotation.normalized;
        return currentRotation;
    }


}
