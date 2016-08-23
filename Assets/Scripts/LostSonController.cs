using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LostSonController : MonoBehaviour {

    [SerializeField]
    private Quest.QuestType _QuestType;

    [SerializeField]
    private CanvasGroup _ActionCanvasGroup;

    [SerializeField]
    private Text _ActionHint;

    [SerializeField]
    private PlayerInput _PlayerInput;

    [SerializeField]
    private QuestController _QuestController;

    private PlayerController _PlayerController;

    private bool _Rescued = false;

    void Awake()
    {
        HideCanvas();
    }

    void OnTriggerEnter(Collider collider)
    {
        _PlayerController = collider.GetComponent<PlayerController>();
        if (!_Rescued && _PlayerController && !_PlayerController.Dead)
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
        _ActionHint.text = "[Hint] Press 'E' to rescue your son";
        _ActionCanvasGroup.alpha = 1;
    }

    private void HideCanvas()
    {
        _ActionCanvasGroup.alpha = 0;
    }

    void Update()
    {
        if (!_Rescued && _PlayerController && _PlayerInput.Action)
        {
            Rescue();
            HideCanvas();
        }
    }

    public void Rescue()
    {
        _Rescued = true;

        _PlayerController.ResetPosition();
        ResetPosition();

        _QuestController.CompleteQuest(_QuestType);
    }

    public void ResetPosition()
    {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(-2.0f, 24.0f, 0.0f);
    }
}
