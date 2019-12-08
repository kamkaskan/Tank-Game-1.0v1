using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    [SerializeField] private FloatEvent shotEvent;
    private TankController controller;
    [SerializeField] private float shotCooldown;
    private float nextShot = 0;
    private Transform barrelEnd;
    public void Init(TankController controller, Transform barrelEnd)
    {
        this.barrelEnd = barrelEnd;
        this.controller = controller;
        nextShot = 0;
    }
    public void ShootListener()
    {
        TryShoot();
    }
    void TryShoot()
    {
        if (nextShot < Time.time)
        {
            nextShot = Time.time + shotCooldown;
            Shoot();
            shotEvent.Invoke(shotCooldown);
        }
    }
    void Shoot()
    {
        GameObject bullet = PoolSystem.instance.Bullets.GetPooledObject();
        bullet.transform.position = barrelEnd.position;

        Vector3 rotation = controller.tTurret.GetCurrentRotation();
        bullet.GetComponent<Bullet>().Init(rotation);

        GameObject shotEffect = PoolSystem.instance.ShootEffect.GetPooledObject();
        shotEffect.transform.position = barrelEnd.position;
        shotEffect.transform.rotation = Quaternion.LookRotation(rotation);
        shotEffect.SetActive(true);
    }
}
