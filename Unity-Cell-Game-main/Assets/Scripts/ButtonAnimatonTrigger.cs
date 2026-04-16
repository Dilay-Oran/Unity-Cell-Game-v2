using UnityEngine;

public class ButtonAnimationTrigger : MonoBehaviour
{
    public Animator animator;
    public string triggerName;

    public void PlayAnimation()
    {
        animator.SetTrigger(triggerName);
    }
}