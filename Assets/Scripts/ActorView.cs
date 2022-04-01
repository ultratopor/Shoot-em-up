using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ActorView : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayDeathAnimation()
    {
        _animator.SetTrigger("DeathTriggerAnim");
    }
}
