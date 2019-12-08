using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private TankSO tankSO;
    private TankStats tank;
    private int baseHp = 100;
    public TankMovement tMovement {get; private set;}
    public TankTurret tTurret {get; private set;}
    public TankShoot tShoot {get; private set;}
    public TankSkin tSkin {get; private set;}
    public TankHealth tHealth {get; private set;}
    public TankCollider tCollider {get; private set;}
    void Awake()
    {
        tMovement = this.GetComponent<TankMovement>();
        tTurret = this.GetComponent<TankTurret>();
        tShoot = this.GetComponent<TankShoot>();
        tHealth = this.GetComponent<TankHealth>();
        tCollider = this.GetComponent<TankCollider>();
    }
    public void Init(TankSO so, float hpMod, float speedMod)
    {
        tankSO = so;
        SpawnTank();

        tMovement.Init(this, tSkin.TankBody, speedMod);
        tTurret.Init(this, tSkin.TankTurret);
        tShoot.Init(this, tSkin.BarrelEnd);
        tHealth.Init(this, (int)(baseHp * hpMod));
        tCollider.Init(tSkin.ShieldEffect);
    }
    public void Reset()
    {
        Destroy(tSkin.gameObject);
        this.transform.localPosition = Vector3.zero;
        this.transform.parent.gameObject.SetActive(false);
    }

    void SpawnTank()
    {
        tank = tankSO.GetTankStats();
        tSkin = Instantiate(tankSO.GetSkin(), this.transform.position, this.transform.rotation, this.transform).GetComponent<TankSkin>();
    }
}
