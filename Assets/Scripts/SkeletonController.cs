using UnityEngine;
using System.Collections;

public class SkeletonController : MonoBehaviour {

    [SerializeField]
    private Rigidbody _Rigidbody;

    private Vector3 _Position;

    private Vector3 _Target;

    private PlayerController _Player;

    public float PositionRadius = 0.5f;

    public float AttackRadius = 1.5f;

    public float Speed = 4;

    // Use this for initialization
    void Start () {
        _Position = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
    }

    private void DoAttack()
    {
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
}
