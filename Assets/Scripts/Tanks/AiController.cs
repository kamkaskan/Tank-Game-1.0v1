using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class AiController : MonoBehaviour
{
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private Vector3Event moveEvent;
    [SerializeField] private Vector3Event aimEvent;
    [SerializeField] private UnityEvent shootEvent;
    private Transform player;
    [SerializeField] private TankController tank;
    [SerializeField] private float minDistance;
    private float aimAccuracy = 1;

    public void Init(TankSO tankSO, DifficultySO diffSO)
    {
        aimAccuracy = diffSO.AiAccuracy;
        tank.Init(tankSO, diffSO.AiHpMod, diffSO.AiSpeedMod);
        player = PlayerController.instance.GetTankTransform();
    }
    public TankController GetTankController()
    {
        return tank;
    }
    void FixedUpdate()
    {
        if (player != null) Tick();
    }

    void Tick()
    {
        Vector3 playerPos = player.position;
        Vector3 tankPos = tank.transform.position;

        //Always try to aim at the player (simulate mouse pointer hovering above him)
        aimEvent.Invoke(playerPos + GetLocationWithOffset(aimAccuracy));

        //Check if tank is close enought and is visible
        //If so shoot, else move to better position
        if (CompareDistance(playerPos, tankPos) && CheckVisibility(playerPos, tankPos)) shootEvent.Invoke();
        else moveEvent.Invoke(GetMoveDirection(playerPos, tankPos));
    }

    bool CompareDistance(Vector3 target, Vector3 start)
    {
        return (Vector3.SqrMagnitude(target - start) < minDistance * minDistance);
    }
    bool CheckVisibility(Vector3 target, Vector3 start)
    {
        RaycastHit hit;
        if (Physics.Raycast(start, target - start, out hit, minDistance * 2, raycastMask))
        {
            return (hit.transform == player.transform); 
        }
        return false;
    }
// MOVE REGION
    Vector3 GetMoveDirection(Vector3 target, Vector3 start)
    {
        return (GetNextWaypoint(target, start) - start).normalized;
    }

    Vector3 GetNextWaypoint(Vector3 target, Vector3 start)
    {
        NavMeshPath path = GetNavMeshPath(target, start);
        return (path != null && path.corners.Length > 1) ? path.corners[1] : start;
    }

    NavMeshPath GetNavMeshPath(Vector3 target, Vector3 start)
    {
        NavMeshPath path = new NavMeshPath();
        return NavMesh.CalculatePath(start, target, NavMesh.AllAreas, path) ? path : null;
    }

// AIM REGION
    Vector3 GetLocationWithOffset(float offsetSize)
    {
        Vector2 rand = Random.insideUnitCircle * offsetSize;
        return new Vector3(rand.x, 0, rand.y);
    }
}
