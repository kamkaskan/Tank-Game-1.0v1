public struct TankStats
{
    public string tankName {get;}
    public int maxHp {get;}
    public float shotCooldown {get;}
    public float movementSpeed {get;}
    public float rotationSpeed {get;}
    public float turretRotationSpeed {get;}
    public TankStats(string tankName, int maxHp, float shotCooldown, float movementSpeed, float rotationSpeed, float turretRotationSpeed)
    {
        this.tankName = tankName;
        this.maxHp = maxHp;
        this.shotCooldown = shotCooldown;
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.turretRotationSpeed = rotationSpeed;
    }
}
