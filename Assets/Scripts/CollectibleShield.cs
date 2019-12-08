using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleShield : Collectible
{
    [SerializeField] private float duration;
    override protected void CollectAction(TankCollider coll)
    {
        Debug.Log("SHIELDED");
        coll.SetShield(duration);
    }
}
