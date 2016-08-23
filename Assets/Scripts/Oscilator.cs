using UnityEngine;
using System.Collections;

public class Oscilator : MonoBehaviour {

    public Vector3 Direction = Vector3.up;

    public float Amplitude = 0.1f;

    public float Speed = 4f;

    private Vector3 _BasePosition;

    [SerializeField]
    private Vector3 _Acceleration;

    public Vector3 Acceleration { get { return _Acceleration; } }
    
    void Awake()
    {
        _BasePosition = transform.position;
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        _Acceleration = transform.position;
        transform.position = _BasePosition + transform.rotation * Direction.normalized * Amplitude * Mathf.Cos(Time.time * Speed);
        _Acceleration = transform.position - _Acceleration;
    }
}
