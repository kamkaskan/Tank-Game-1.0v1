using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Vector3Event moveEvent;
    [SerializeField] private Vector3Event mouseEvent;
    [SerializeField] private UnityEvent shootEvent;
    private Vector3 lastAim;
    void Update()
    {
        mouseEvent.Invoke(GetMousePos());
        if (Input.GetButtonDown("Fire")) shootEvent.Invoke();
    }
    void FixedUpdate()
    {
        moveEvent.Invoke(GetMovementTargetDir());
    }
    Vector3 GetMovementTargetDir()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x,0,z);
        if (dir.sqrMagnitude > 1) dir = dir.normalized;
        return dir;
    }

    Vector3 GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit)) lastAim = hit.point;
        return lastAim;
    }
}
