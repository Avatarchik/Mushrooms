using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour {

    [SerializeField]
    private GameObject _TeleportSpraks;

    [SerializeField]
    private float _JumpForce = 50.0f;

    private bool _SwitchedOn;

    public bool SwitchedOn
    {
        get { return _SwitchedOn; }
        set
        {
            _SwitchedOn = value;
            _TeleportSpraks.SetActive(_SwitchedOn);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (_SwitchedOn)
        {
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            rigidbody.AddForce(gameObject.transform.up * _JumpForce, ForceMode.Impulse);
        }
    }
}
