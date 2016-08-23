using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoneController : MonoBehaviour {

    [SerializeField]
    private CanvasGroup _ActionCanvasGroup;

    [SerializeField]
    private Text _ActionHint;

    [SerializeField]
    private Rigidbody _Rigidbody;

    [SerializeField]
    private PlayerInput _PlayerInput;

    private PlayerController _PlayerController;

    private bool _Pushed = false;

    void Awake()
    {
        HideCanvas();
    }

    void OnTriggerEnter(Collider collider)
    {
        _PlayerController = collider.GetComponent<PlayerController>();
        if(!_Pushed && _PlayerController && !_PlayerController.Dead)
        {
            ShowCanvas();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        _PlayerController = null;
        HideCanvas();
    }

    private void ShowCanvas()
    {
        _ActionHint.text = "[Hint] Press 'E' to move the stone";
        _ActionCanvasGroup.alpha = 1;
    }

    private void HideCanvas()
    {
        _ActionCanvasGroup.alpha = 0;
    }

    void Update()
    {
        if(!_Pushed && _PlayerController && _PlayerInput.Action)
        {
            Push();
            HideCanvas();
        }
    }

    public void Push()
    {
        _Pushed = true;
        _Rigidbody.constraints = RigidbodyConstraints.None;
    }
}
