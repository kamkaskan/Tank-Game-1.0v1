using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollider : MonoBehaviour
{
    [SerializeField] private TankHealth health;
    private GameObject shield;
    private IEnumerator shielded;
    private List<float> dmgMods;
    public void ReceiveDmg(int dmg)
    {
        health.TakeDmg(GetDmgValue(dmg));
    }

    int GetDmgValue(int dmg)
    {
        float modifiedDmg = dmg * GetDmgMod();
        return (int) modifiedDmg;
    }
    public void Init(GameObject shield) 
    {
        this.shield = shield;

        dmgMods = new List<float>();
        if (shielded != null) 
        {
            StopCoroutine(shielded);
            shielded = null;
            shield.SetActive(false);
        }

    }
    float GetDmgMod()
    {
        float mod = 1;
        foreach (float f in dmgMods) mod *= f;
        if (dmgMods.Count > 0) Debug.Log(dmgMods[0]);
        return mod;
    }
    void UpdateDmgMod(bool add, float value)
    {
        if (add) dmgMods.Add(value);
        else dmgMods.Remove(value);
        Debug.Log(GetDmgMod());
    }
    public void SetShield(float duration)
    {
        if (shielded != null) StopCoroutine(shielded);
        shielded = Shielded(duration);
        StartCoroutine(shielded);
    }  
    IEnumerator Shielded(float duration)
    {
        float dmgMod = 0f;
        Debug.Log("Got Shielded " + GetDmgMod());
        UpdateDmgMod(true, dmgMod);
        Debug.Log("Got Shielded 2 " + GetDmgMod());
        shield.SetActive(true);
        
        yield return new WaitForSeconds(duration);

        shield.SetActive(false);
        Debug.Log("Got Shielded 3 " + GetDmgMod());
        UpdateDmgMod(false, dmgMod);
        Debug.Log("Got Shielded 4 " + GetDmgMod());
        shielded = null;
    }
}
