using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

    private static Color DefaultColor = new Color(0.8f, 0.8f, 0.0f);

    private static Color CompletedColor = new Color(0.1f, 0.5f, 0.1f);

    [SerializeField]
    private QuestController _QuestController;

    [SerializeField]
    private GameObject _QuestMark;
    
    private Material _Material;

    public Quest.QuestType QuestType;





    void Awake()
    {
        Renderer renderer = _QuestMark.GetComponent<Renderer>();
        _Material = renderer.material;
    }

	// Use this for initialization
	void Start () {
        SetMarkActive(true);
        SetMarkCompleted(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter()
    {
        _QuestController.SetCurrentQuest(QuestType);
        SetMarkActive(false);
    }

    void OnTriggerExit()
    {
        _QuestController.SetCurrentQuest(Quest.QuestType.None);
        if (_QuestController.IsQuestMarkActive(QuestType))
        {
            SetMarkActive(true);
        }
    }

    public void SetMarkActive(bool active)
    {
        _QuestMark.gameObject.SetActive(active);
    }

    public void SetMarkCompleted(bool completed)
    {
        _Material.SetColor("_CristalColor", completed ? CompletedColor : DefaultColor);
    }
}
