using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("something touched collectible");
        if (coll.transform.CompareTag("Tank")) 
        {
            CollectAction(coll.transform.GetComponent<TankCollider>());
            this.gameObject.SetActive(false);
        }
    }
    abstract protected void CollectAction(TankCollider coll);
}
