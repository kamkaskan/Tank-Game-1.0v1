using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    public static PoolSystem instance {get; private set;}
    [SerializeField] private Pool obstacles;
    [SerializeField] private Pool ai;
    [SerializeField] private Pool bullets;
    [SerializeField] private Pool bigExp;
    [SerializeField] private Pool smallExp;
    [SerializeField] private Pool shootEffect;
    public Pool Obstacles {get {return obstacles;}}
    public Pool Ai {get {return ai;}}
    public Pool Bullets {get {return bullets;}}
    public Pool BigExp {get {return bigExp;}}
    public Pool SmallExp {get {return smallExp;}}
    public Pool ShootEffect {get {return shootEffect;}}

    void Awake()
    {
        instance = this;
    }
}
