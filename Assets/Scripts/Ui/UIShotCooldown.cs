using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShotCooldown : MonoBehaviour
{
    [SerializeField] private Image shotFill;
    private IEnumerator cdDelay;
    // Update is called once per frame
    public void shotCd(float time)
    {
        if (cdDelay != null) StopCoroutine(cdDelay);
        cdDelay = cooldownDelay(time);
        StartCoroutine(cdDelay);
    }

    IEnumerator cooldownDelay(float time)
    {
        float currentTime = 0;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            shotFill.fillAmount = currentTime/time;
            yield return null;
        }
        shotFill.fillAmount = 1f;
        yield return null;
        shotFill.fillAmount = 0;
        cdDelay = null;
    }

    void OnEnable()
    {
        shotCd(0);
    }
}
