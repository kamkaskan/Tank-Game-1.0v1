using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{
    [SerializeField] private float lifeTime;  
    void OnEnable()
    {
        StartCoroutine(beingAlive());
    }

    // Update is called once per frame
    IEnumerator beingAlive()
    {
        yield return new WaitForSeconds(lifeTime);
        this.gameObject.SetActive(false);
    }
}
