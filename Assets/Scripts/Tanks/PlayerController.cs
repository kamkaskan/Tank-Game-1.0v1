using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance  {get; private set;}
    [SerializeField] private TankController tank;
    public void Init(TankSO tankSO, DifficultySO diffSO)
    {
        tank.Init(tankSO, diffSO.PlayerHpMod, 1);
    }
    void Awake()
    {
        instance = this;
    }
    public Transform GetTankTransform()
    {
        return tank.transform;
    }

    public TankController GetTankController()
    {
        return tank;
    }
}
