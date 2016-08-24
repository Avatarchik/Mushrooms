using UnityEngine;

/*
* This class is responsible handling all player actions (animations, movement, input, jumping, collisions) except of gravity attraction.
* Rigidbody is required as sibling component and will be automatically detected and set in editor via OnValidate and Reset messages.
*
* All fields are private but allowed to be serialized and seen in inspector because of SerializeField attribute.
* [Header()] attribute allows to add labels before displaying field in inspector.
* [RequireComponent()] automatically adds specified component to this gameObject, if there is none of such type
*/

/// <summary>
/// Handles  movement, animations and collisions of Player
/// </summary>
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region Inspector Variables
    [Header("References")]
    [SerializeField] private PlayerInput    _Input;
    [SerializeField] private PlayerAnimator _Animator;
    [SerializeField] private Rigidbody      _Rigidbody;
    [SerializeField] private Camera         _Camera;

    [SerializeField]
    private GameController _GameController;

    [SerializeField]
    private GravityBody _GravityBody;

    [Header("Settings")]
    [SerializeField] private float _WalkForce = 2.0f;
    [SerializeField] private float _RunForce  = 5.0f;
    [SerializeField] private float _JumpForce = 10.0f;
    [SerializeField] private float _TiltUp    = 80.0f;
    [SerializeField] private float _TiltDown  = 80.0f;
    
    [SerializeField]
    private float _AirFriction = 0.4f;

    private bool _Dead = false;




    public bool Dead { get { return _Dead; } }

    #endregion Inspector Variables

    #region Private Variables

    #endregion Private Variables



    private Transform _StartTransform;

    public Transform StartTransform { get { return _StartTransform; } }

    #region Unity Messages
    private void Start()
    {
        _StartTransform = transform;
        LockCursor();
    }
    private void Update()
    {
        UpdateAnimations();
    }
    private void FixedUpdate()
    {
        DoRotate();
        DoMove();
        DoJump();
    }

    /// <summary>
    /// Called on components creation and on Reset in inspector
    /// </summary>
    private void Reset()
    {
        ValidateReferences();
    }

    /// <summary>
    /// Called each time any variable is changed in Inspector on this component
    /// </summary>
    private void OnValidate()
    {
        ValidateReferences();
    }
    #endregion Unity Messages

    public void Die()
    {
        _Dead = true;

        _GameController.GameOver(false);
        _Animator.DeathOver();
    }

    public void ResetPosition()
    {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(2.0f, 24.0f, 0.0f);
    }

    #region Private Methods
    private void UpdateAnimations()
    {
        if (_Dead) return;

        // Update animation parameters
        if(_Input.Walk)
        {
            _Animator.Walk();
        }
        else
        {
            _Animator.Run();
        }

        _Animator.Speed(_Input.Forward);
    }

    private void DoMove()
    {
        if (_Dead) return;

        if (!_Animator.CanMove ())
			return;
		
        Vector3 translation = _Input.Forward * transform.forward;
        translation *= _Input.Walk ? _WalkForce : _RunForce;

        if(!_GravityBody.OnGround) {
            translation *= _AirFriction;
        }

        _Rigidbody.AddForce(translation, ForceMode.VelocityChange);

        if(_GravityBody.MovingGround)
        {
            FlyingPlatformsController rotator = _GravityBody.MovingGround.GetComponentInParent<FlyingPlatformsController>();
            if (rotator && rotator.SwitchedOn)
            {
                //TODO make it better - use sqrt(platform distance) * some constant ??
                Vector3 direction = Vector3.Cross(rotator.transform.rotation * rotator.Axis, _GravityBody.MovingGround.transform.up).normalized;
                float distance = _GravityBody.MovingGround.transform.position.magnitude;
                _Rigidbody.AddForce(direction * rotator.Angle * Mathf.Sqrt(distance) * rotator.ForceFactor, ForceMode.VelocityChange);
            }
        }

        _Animator.SetOnGround(_GravityBody.OnGround);
    }

    private void DoRotate()
    {
        transform.Rotate(Vector3.up * _Input.Horizontal * Time.deltaTime);

        //var rotation = _Camera.transform.localRotation * Quaternion.Euler(Vector3.right * -_Input.Vertical);
        //if (rotation.eulerAngles.x < _TiltDown || rotation.eulerAngles.x > (360.0f - _TiltUp))
        //{
        //    _Camera.transform.localRotation = rotation;
        //}
    }

    private void DoJump()
    {
        if (!_Animator.CanMove ())
			return;
		
        if (_Input.Jump && _GravityBody.OnGround)
        {
            _Rigidbody.AddForce(transform.up * _JumpForce, ForceMode.Impulse);
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion Private Methods

    #region Validation Methods
    private void ValidateReferences()
    {
        FindReferenceInHierarchy(ref _Camera);

        FindReferenceInHierarchy(ref _Rigidbody);
        FindReferenceInHierarchy(ref _Animator);

        FindReferenceInHierarchy(ref _Input);
    }
    #endregion Validation Methods

    #region Helper Methods
    /// <summary>
    /// Given parameter of type T, find component in GameObject or its children
    /// <T> is a declaration of generic method, where T is a type resolved from usage
    /// </summary>
    private void FindReferenceInHierarchy<T>(ref T reference) where T : class
    {
        if(!reference.Equals(null))
        {
            return;
        }

        reference = GetComponent<T>();
        if(!reference.Equals(null))
        {
            return;
        }

        reference = GetComponentInChildren<T>();

        if(reference.Equals(null))
        {
            Debug.LogError("Reference to object: " + typeof(T).Name + " not found");
        }
    }
    #endregion Helper Methods
}