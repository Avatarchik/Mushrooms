using UnityEngine;

/// <summary>
/// Allows component with rigidbody to be attracted by GravitySource
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField]
    private GravitySource _Source;

    [SerializeField]
    private float _Mass = 1;

    [Header("Preview")]
    [SerializeField]
    private bool _OnGround = false;

    [SerializeField]
    private GameObject _Ground;

    [SerializeField]
    private GameObject _MovingGround;

    [SerializeField]
    private LayerMask _PlatformsMask;

    [SerializeField]
    private LayerMask _MovingPlatformsMask;

    #endregion Inspector Variables


    #region Public Variables
    public Rigidbody Rigidbody;
    #endregion Public Variables

    #region Public Variables
    public float Mass { get { return _Mass; } }

    public bool OnGround { get { return _OnGround; } }

    public GameObject Ground { get { return _Ground; } }

    public GameObject MovingGround { get { return _MovingGround; } }

    #endregion Public Variables

    #region Unity Messages

    void Awake() {
		_Source = FindObjectOfType<GravitySource> ();
	}

    void FixedUpdate()
    {
        GroundCheck();
        _Source.Affect(this);
    }

    private void GroundCheck()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out hit, 0.5f, _PlatformsMask))
        {
            _Ground = hit.transform.gameObject;
        }
        else
        {
            _Ground = null;
        }

        if (Physics.Raycast(ray, out hit, 0.5f, _MovingPlatformsMask))
        {
            _MovingGround = hit.transform.gameObject;
        }
        else
        {
            _MovingGround = null;
        }

        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            _OnGround = true;
        }
        else
        {
            _OnGround = false;
        }
    }

    #endregion Unity Messages

    public void Jump()
    {
        _OnGround = false;
    }

    #region Validation
//    private void ValidateReferences()
//    {
//        if (Rigidbody == null)
//        {
//            Rigidbody = GetComponent<Rigidbody>();
//        }
//
//        if(_Source == null)
//        {
//            var sources = Resources.FindObjectsOfTypeAll<GravitySource>();
//            if(sources == null || sources.Length == 0)
//            {
//                Debug.LogError("No gravity sources found");
//            }else
//            {
//                _Source = sources[0];
//            }
//        }
//    }
    #endregion Validation
}