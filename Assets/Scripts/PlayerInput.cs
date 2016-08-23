using System;
using UnityEngine;

/// <summary>
/// Handles player input
/// </summary>
[Serializable]
class PlayerInput : MonoBehaviour
{
    #region Inspector Variables
    [Header("Input")]
    [SerializeField] private KeyCode _WalkKey    = KeyCode.LeftShift;
    [SerializeField] private KeyCode _JumpKey    = KeyCode.Space;
    [SerializeField] private KeyCode _ActionKey = KeyCode.E;// | KeyCode.KeypadEnter;

    [Header("Mouse")]
    [SerializeField] private float _SensivityHorizontal;
    [SerializeField] private float _SensivityVertical;
    #endregion Inspector Variables

    #region Public Variables
    public float Forward
    {
        get { return _VerticalAxis; }
    }
    public float Horizontal
    {
        get { return _MouseHorizontal * _SensivityHorizontal; }
    }
    public float Vertical
    {
        get { return _MouseVertical * _SensivityVertical; }
    }

    public bool Walk  { get { return _Walk;  } }
    public bool Jump  { get { return _Jump;  } }
    public bool Flag  { get { return _Flag;  } }
    public bool Shoot { get { return _Shoot; } }

    public bool Action { get { return _Action; } }
    #endregion Public Variables

    #region Private Variables
    private float _VerticalAxis;

    private float _MouseVertical;
    private float _MouseHorizontal;

    private bool _Jump;
    private bool _Walk;
    private bool _Flag;
    private bool _Shoot;

    private bool _Action;
    #endregion Private Variables

    #region Unity Messages
    private void Update()
    {
        _VerticalAxis = Input.GetAxis("Vertical");

        _MouseHorizontal = Input.GetAxis("Mouse X");
        _MouseVertical   = Input.GetAxis("Mouse Y");

        _Walk  = Input.GetKey(_WalkKey);
        _Jump = Input.GetKeyDown(_JumpKey);

        //_Flag  = Input.GetKey(_PutFlagKey);
        _Shoot = Input.GetMouseButtonDown(0);

        _Action = Input.GetKey(_ActionKey);
    }
    #endregion Unity Messages
}
