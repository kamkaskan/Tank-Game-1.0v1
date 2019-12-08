using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float lifeDuration;
    [SerializeField] private int dmg;
    private Coroutine isTraveling;
    public void Init(Vector3 dir)
    {
        rb.velocity = Vector3.zero;

        this.gameObject.SetActive(true);
        Shoot(dir);

        if (isTraveling != null) StopCoroutine(isTraveling);
        isTraveling = StartCoroutine(Traveling(Time.time + lifeDuration));
        
    }
    void Shoot(Vector3 travelDir)
    {
        rb.AddForce(travelDir * speed, ForceMode.VelocityChange);
    }
    IEnumerator Traveling(float lifeEnd)
    {
        while (Time.time < lifeEnd)
        {
            yield return null;
        }
        Explode(this.transform.position);
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.CompareTag("Tank")) Hit(coll.transform.GetComponent<TankCollider>());
        Explode(coll.GetContact(0).point);
    }
    void Hit(TankCollider tank)
    {
        tank.ReceiveDmg(dmg);
    }

    void Explode(Vector3 explosionPos)
    {
        GameObject explosion = PoolSystem.instance.SmallExp.GetPooledObject();
        explosion.transform.position = explosionPos;
        explosion.SetActive(true);

        if (isTraveling != null) 
        {
            StopCoroutine(isTraveling);
            isTraveling = null;
        }
        this.gameObject.SetActive(false);
    }
}
