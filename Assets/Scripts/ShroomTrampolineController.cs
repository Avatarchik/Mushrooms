using UnityEngine;
using System.Collections;

public class ShroomTrampolineController : MonoBehaviour {

    [SerializeField]
    private float _JumpForce = 20.0f;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        rigidbody.AddForce(gameObject.transform.up * _JumpForce, ForceMode.Impulse);
    }
}
