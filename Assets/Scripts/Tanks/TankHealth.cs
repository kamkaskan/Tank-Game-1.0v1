using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField] private FloatEvent hpChange;
    private int maxHp;
    private int currentHp;
    private TankController tank;
    public void Init(TankController tank, int maxHp)
    {
        this.tank = tank;
        this.maxHp = maxHp;
        currentHp = maxHp;
    }
    public void TakeDmg(int dmg)
    {
        currentHp -= dmg;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Death();
        }

        UpdatePercentage();
    }

    void UpdatePercentage()
    {
        float hpPerc = (float) currentHp / (float) maxHp;
        hpChange.Invoke(hpPerc);
    }
    void Death()
    {
        SpawnExplosion();
        GameplayController.instance.TankKilled(tank);
    }

    void SpawnExplosion()
    {
        GameObject explosion = PoolSystem.instance.BigExp.GetPooledObject();
        explosion.transform.position = this.transform.position;
        explosion.SetActive(true);
    }
}
