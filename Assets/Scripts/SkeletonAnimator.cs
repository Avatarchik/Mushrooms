using UnityEngine;
using System.Collections;

public class SkeletonAnimator : MonoBehaviour {

    #region Inspector Variables

    [SerializeField]
    private Animator _Animator;

    #endregion Inspector Variables

    #region Public Methods

    public void Speed(float speed)
    {
        _Animator.SetFloat("Speed", speed);
    }

    public void Attack()
    {
        _Animator.SetBool("Attack", true);
    }

    public void Die()
    {
        _Animator.SetBool("Dead", true);
    }

    #endregion Public Methods
}
