using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField]
    private Animator _Animator;

    #endregion Inspector Variables

    #region Public Methods

    public bool CanMove()
    {
        var info = _Animator.GetCurrentAnimatorStateInfo(0);
        return !info.IsName("astronaut_put_flag");
    }

    public void Run()
    {
        _Animator.SetBool("isWalk", false);
    }

    public void Walk()
    {
        _Animator.SetBool("isWalk", true);
    }
    
    public void Speed(float speed)
    {
        _Animator.SetFloat("speed", speed);
    }

    public void SetOnGround(bool onGround)
    {
        _Animator.SetBool("OnGround", onGround);
    }

    public void Attack()
    {
        _Animator.SetBool("Attack", false);
    }

    public void KickOver()
    {
        _Animator.SetBool("LowKick", false);
    }

    public void DeathOver()
    {
        _Animator.SetBool("isDeath", false);
    }

    public void DeathOver2()
    {
        _Animator.SetBool("isDeath2", false);
    }

    public void HitOver()
    {
        _Animator.SetBool("HitStrike", false);
    }

    public void DamageOver()
    {
        _Animator.SetBool("isDamage", false);
    }

    #endregion Public Methods

    #region Animation Callbacks

    #endregion Animation Callbacks

    #region Private Methods

    #endregion Private Methods
}