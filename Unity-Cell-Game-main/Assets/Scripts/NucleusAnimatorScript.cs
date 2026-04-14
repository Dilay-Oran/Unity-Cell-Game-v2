using System.Collections.Generic;
using UnityEngine;

public class NucleusAnimatorScript : MonoBehaviour
{
    [Header("Animation")]
    public Animator nucleusAnimator;
    public string animationTriggerName = "PlayAnimNucleus";

    [Header("Animasyon Bitince Kapanacaklar")]
    public List<GameObject> objectsToHide;

    [Header("Animasyon Bitince Açýlacaklar")]
    public List<GameObject> objectsToShow;

    public void PlayAnimation()
    {
        nucleusAnimator.SetTrigger(animationTriggerName);
        StartCoroutine(OnAnimationEnd());
    }

    System.Collections.IEnumerator OnAnimationEnd()
    {
        yield return new WaitUntil(() =>
            nucleusAnimator.GetCurrentAnimatorStateInfo(0).IsName("Nucleus Animation"));

        yield return null;

        float length = nucleusAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(length);

        foreach (GameObject obj in objectsToHide)
            if (obj != null) obj.SetActive(false);

        foreach (GameObject obj in objectsToShow)
            if (obj != null) obj.SetActive(true);
    }
}
