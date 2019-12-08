using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New TankSO", menuName = "TankSO", order = 51)]
public class TankSO : ScriptableObject
{
    [SerializeField] private string tankName = "new";
    [SerializeField] private GameObject tankSkin;
    [SerializeField] private int maxHp = 100;
    [SerializeField] private float shotCooldown = 1;
    [SerializeField] private float speed = 4000;
    [SerializeField] private float rotationSpeed = 4;
    [SerializeField] private float turretRotationSpeed = 4;
    
    public GameObject GetSkin()
    {
        return tankSkin;
    }
    public TankStats GetTankStats()
    {
        return new TankStats(tankName, maxHp, shotCooldown, speed, rotationSpeed, turretRotationSpeed);
    }
}
