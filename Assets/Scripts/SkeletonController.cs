using UnityEngine;
using System.Collections;

public class SkeletonController : MonoBehaviour
{
    [SerializeField]
    private Collider _Collider;

    [SerializeField]
    private Rigidbody _Rigidbody;

    [SerializeField]
    private SkeletonAnimator _Animator;

    private Vector3 _Position;

    private Vector3 _Target;

    private PlayerController _Player;

    public float PositionRadius = 0.5f;

    public float AttackRadius = 1.5f;

    public float Speed = 4;

    private bool _Dead = false;

    // Use this for initialization
    void Start()
    {
        _Position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_Dead) return;

        if (_Player)
        {
            _Target = _Player.transform.position;

            if (Vector3.Distance(_Target, transform.position) <= AttackRadius)
            {
                DoAttack();
            }
            else
            {
                DoMove();
            }
        }
        else if (Vector3.Distance(_Position, transform.position) > PositionRadius)
        {
            _Target = _Position;
            DoMove();
        }
    }

    private void DoMove()
    {
        Vector3 direction = (_Target - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);

        _Rigidbody.AddForce(transform.forward * Speed, ForceMode.VelocityChange);
        _Animator.Speed(_Rigidbody.velocity.magnitude);
    }

    private void DoAttack()
    {
        _Animator.Attack();
        _Player.Die();
    }


    void OnTriggerEnter(Collider other)
    {
        _Player = other.GetComponent<PlayerController>();
    }

    void OnTriggerExit(Collider other)
    {
        _Player = null;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            Die();
        }
    }

    public void Die()
    {
        //TODO _Collider.enabled = false;
        _Animator.Die();
        _Dead = true;
    }
}
