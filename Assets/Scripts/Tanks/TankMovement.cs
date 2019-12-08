using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private TankController controller;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private Transform tankBody;
    private float speedMod;
    Vector3 currentDir;
    public void Init(TankController controller, Transform body, float speedMod)
    {
        this.controller = controller;
        this.tankBody = body; 
        this.speedMod = speedMod;
    }
    public void MoveListener(Vector3 targetDir)
    {
        Move(targetDir);
    }
    void Move(Vector3 targetDir)
    {
        if (targetDir != Vector3.zero)
        {
            rb.AddForce(GetMovementDir(targetDir) * movementSpeed * speedMod * Time.fixedDeltaTime, ForceMode.Force);
        }
        RotateToMovementDir();
    }
    Vector3 GetMovementDir(Vector3 targetDir)
    {   
        currentDir = Vector3.RotateTowards(currentDir, targetDir, rotationSpeed * Time.deltaTime, 1f);
        currentDir = currentDir.normalized;
        return currentDir;
    }
    void RotateToMovementDir()
    {
        Vector3 dir = rb.velocity;
        if (dir == Vector3.zero) return;
        float movementAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        tankBody.localRotation = Quaternion.AngleAxis(movementAngle + 90, Vector3.up);
        //ToString DO
        //rb.AddTorque(0, movementAngle + 90, 0);
    }
}
