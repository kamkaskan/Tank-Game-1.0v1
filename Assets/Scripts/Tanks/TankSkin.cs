using UnityEngine;

public class TankSkin : MonoBehaviour
{
    [SerializeField] private Transform tankBody;
    [SerializeField] private Transform tankTurret;
    [SerializeField] private Transform barrelEnd;
    [SerializeField] private GameObject shieldEffect;
    public Transform TankBody {get {return tankBody;}}
    public Transform TankTurret {get {return tankTurret;}}
    public Transform BarrelEnd {get {return barrelEnd;}}
    public GameObject ShieldEffect {get {return shieldEffect;}}
}
