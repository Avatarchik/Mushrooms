using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestController : MonoBehaviour {

    [SerializeField]
    private PlayerInput _Input;





    private Dictionary<Quest.QuestType, Quest> _Quests;

    private Dictionary<Quest.QuestType, NPCController> _NPCControllers;

    private Quest.QuestType _CurrentQuest = Quest.QuestType.None;



    [SerializeField]
    private ScoreController _ScoreController;



    [SerializeField]
    private Fader _MessageFader;

    [SerializeField]
    private Text _MessageTitle;



    [SerializeField]
    private CanvasGroup _QuestCanvasGroup;

    [SerializeField]
    private Image _QuestImage;

    [SerializeField]
    private Text _QuestTitle;

    [SerializeField]
    private Text _QuestDescription;

    [SerializeField]
    private Text _QuestSummary;

    [SerializeField]
    private Text _QuestHint;



    //TODO Make dictionaries:
    //<QuestType, List<CollectibleController>>
    //<QuestType, List<UnlockableController>
    //
    // or even move lists to Quest object (?)

    private int _FireCrystalsCount = 0;
    private int _FireCrystalsLimit = 0;

    private List<RedCrystalController> _FireCrystals;

    private List<FireLampController> _FireLamps;

    public int FireCrystalsCount { get { return _FireCrystalsCount; } }

    public int FireCrystalsLimit { get { return _FireCrystalsLimit; } }





    private int _TeleportCrystalsCount = 0;
    private int _TeleportCrystalsLimit = 0;

    private List<TeleportCrystalController> _TeleportCrystals;

    private List<TeleportController> _Teleports;

    public int TeleportCrystalsCount { get { return _FireCrystalsCount; } }

    public int TeleportCrystalsLimit { get { return _FireCrystalsLimit; } }




    private int _LostKeyCrystalsCount = 0;
    private int _LostKeyCrystalsLimit = 0;

    private List<LostKeyCrystalController> _LostKeyCrystals;

    public int LostKeyCrystalsCount { get { return _LostKeyCrystalsCount; } }

    public int LostKeyCrystalsLimit { get { return _LostKeyCrystalsLimit; } }





    private int _FlyingPlatformsCrystalsCount = 0;
    private int _FlyingPlatformsCrystalsLimit = 0;

    private List<FlyingPlatformsCrystalController> _FlyingPlatformsCrystals;

    private List<FlyingPlatformsController> _FlyingPlatforms;

    public int FlyingPlatformsCrystalsCount { get { return _FlyingPlatformsCrystalsCount; } }

    public int FlyingPlatformsCrystalsLimit { get { return _FlyingPlatformsCrystalsLimit; } }





    private int _GodraysCrystalsCount = 0;
    private int _GodraysCrystalsLimit = 0;

    private List<GodraysCrystalController> _GodraysCrystals;

    private List<GodraysController> _Godrays;

    public int GodraysCrystalsCount { get { return _GodraysCrystalsCount; } }

    public int GodraysCrystalsLimit { get { return _GodraysCrystalsLimit; } }




    void Awake()
    {
        InitUI();
        InitQuests();
        InitNPCControllers();

        InitFireCrystals();
        InitTeleportCrystals();
        InitLostKeyCrystals();
        InitFlyingPlatformsCrystals();
        InitGodraysCrystals();

        InitFireLamps();
        InitTeleports();
        InitFlyingPlatforms();
        InitGodrays();
    }

    private void InitUI()
    {
        _MessageFader.Stop();
        _QuestCanvasGroup.alpha = 0;
    }

    private void InitQuests()
    {
        _Quests = new Dictionary<Quest.QuestType, Quest>();

        for(int i = 0; i < (int)Quest.QuestType.None; i++)
            _Quests.Add((Quest.QuestType)i, Quest.CreateQuest((Quest.QuestType)i));
    }

    private void InitNPCControllers()
    {
        _NPCControllers = new Dictionary<Quest.QuestType, NPCController>();

        foreach (NPCController npcController in FindObjectsOfType<NPCController>())
        {
            _NPCControllers.Add(npcController.QuestType, npcController);
        }
    }




    private void InitFireCrystals()
    {
        _FireCrystals = new List<RedCrystalController>();

        foreach (RedCrystalController crystal in FindObjectsOfType<RedCrystalController>())
        {
            crystal.gameObject.SetActive(false);
            _FireCrystals.Add(crystal);
        }
        _FireCrystalsLimit = _FireCrystals.Count;
    }

    private void InitTeleportCrystals()
    {
        _TeleportCrystals = new List<TeleportCrystalController>();

        foreach (TeleportCrystalController crystal in FindObjectsOfType<TeleportCrystalController>())
        {
            crystal.gameObject.SetActive(false);
            _TeleportCrystals.Add(crystal);
        }
        _TeleportCrystalsLimit = _TeleportCrystals.Count;
    }

    private void InitLostKeyCrystals()
    {
        _LostKeyCrystals = new List<LostKeyCrystalController>();

        foreach (LostKeyCrystalController crystal in FindObjectsOfType<LostKeyCrystalController>())
        {
            crystal.gameObject.SetActive(false);
            _LostKeyCrystals.Add(crystal);
        }
        _LostKeyCrystalsLimit = _LostKeyCrystals.Count;
    }

    private void InitFlyingPlatformsCrystals()
    {
        _FlyingPlatformsCrystals = new List<FlyingPlatformsCrystalController>();

        foreach (FlyingPlatformsCrystalController crystal in FindObjectsOfType<FlyingPlatformsCrystalController>())
        {
            crystal.gameObject.SetActive(false);
            _FlyingPlatformsCrystals.Add(crystal);
        }
        _FlyingPlatformsCrystalsLimit = _FlyingPlatformsCrystals.Count;
    }

    private void InitGodraysCrystals()
    {
        _GodraysCrystals = new List<GodraysCrystalController>();

        foreach (GodraysCrystalController crystal in FindObjectsOfType<GodraysCrystalController>())
        {
            crystal.gameObject.SetActive(false);
            _GodraysCrystals.Add(crystal);
        }
        _GodraysCrystalsLimit = _GodraysCrystals.Count;
    }




    private void InitFireLamps()
    {
        _FireLamps = new List<FireLampController>();

        foreach (FireLampController item in FindObjectsOfType<FireLampController>())
        {
            item.SetFiredUp(false);
            _FireLamps.Add(item);
        }
    }

    private void InitTeleports()
    {
        _Teleports = new List<TeleportController>();

        foreach (TeleportController item in FindObjectsOfType<TeleportController>())
        {
            item.SwitchedOn = false;
            _Teleports.Add(item);
        }
    }

    private void InitFlyingPlatforms()
    {
        _FlyingPlatforms = new List<FlyingPlatformsController>();

        foreach (FlyingPlatformsController item in FindObjectsOfType<FlyingPlatformsController>())
        {
            item.SwitchedOn = false;
            _FlyingPlatforms.Add(item);
        }
    }

    private void InitGodrays()
    {
        _Godrays = new List<GodraysController>();

        foreach (GodraysController item in FindObjectsOfType<GodraysController>())
        {
            item.gameObject.SetActive(false);
            _Godrays.Add(item);
        }
    }





    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        DoAction();
    }

    protected void DoAction()
    {
        if (_Input.Action)
        {
            if (_CurrentQuest != Quest.QuestType.None)
            {
                switch(_Quests[_CurrentQuest].State)
                {
                    case Quest.QuestState.Idle:
                        ActivateQuest();
                        break;
                    case Quest.QuestState.Completed:
                        RewardQuest();
                        break;
                    default:
                        break;
                }
            }
        }
    }



    //TODO move to NPCController, replace by: GetCurrentQuestState
    public bool IsQuestMarkActive(Quest.QuestType questType)
    {
        Quest.QuestState state = _Quests[questType].State;
        return state == Quest.QuestState.Idle || state == Quest.QuestState.Completed;
    }

    public void SetCurrentQuest(Quest.QuestType questType)
    {
        _CurrentQuest = questType;

        if (_CurrentQuest != Quest.QuestType.None && _Quests[_CurrentQuest].State != Quest.QuestState.Rewarded)
        {
            _QuestCanvasGroup.alpha = 1;

            _QuestTitle.text = _Quests[_CurrentQuest].Title;
            _QuestDescription.text = _Quests[_CurrentQuest].GetDescription();
            _QuestSummary.text = _Quests[_CurrentQuest].Summary;
            _QuestHint.text = _Quests[_CurrentQuest].GetHint();
        } else
        {
            _QuestCanvasGroup.alpha = 0;
        }
    }

    public void ActivateQuest()
    {
        _Quests[_CurrentQuest].State = Quest.QuestState.Active;
        _NPCControllers[_CurrentQuest].SetMarkActive(false);

        _QuestCanvasGroup.alpha = 0;

        switch (_CurrentQuest)
        {
            case Quest.QuestType.LostKey:
                ActivateLostKeyQuest();
                break;
            case Quest.QuestType.MissingFire:
                ActivateMissingFireQuest();
                break;
            case Quest.QuestType.MissingGodrays:
                ActivateMissingGodraysQuest();
                break;
            case Quest.QuestType.NoTeleports:
                ActivateNoTeleportsQuest();
                break;
            case Quest.QuestType.FlyingPlatforms:
                ActivateFlyingPlatformsQuest();
                break;
            default:
                break;
        }
    }

    private void ActivateLostKeyQuest()
    {
        foreach (LostKeyCrystalController crystal in _LostKeyCrystals)
        {
            crystal.gameObject.SetActive(true);
        }
        _LostKeyCrystals.Clear();
    }

    private void ActivateMissingFireQuest()
    {
        foreach (RedCrystalController crystal in _FireCrystals)
        {
            crystal.gameObject.SetActive(true);
        }
        _FireCrystals.Clear();
    }

    private void ActivateMissingGodraysQuest()
    {
        foreach (GodraysCrystalController crystal in _GodraysCrystals)
        {
            crystal.gameObject.SetActive(true);
        }
        _GodraysCrystals.Clear();
    }

    private void ActivateNoTeleportsQuest()
    {
        foreach (TeleportCrystalController crystal in _TeleportCrystals)
        {
            crystal.gameObject.SetActive(true);
        }
        _TeleportCrystals.Clear();
    }

    private void ActivateFlyingPlatformsQuest()
    {
        foreach (FlyingPlatformsCrystalController crystal in _FlyingPlatformsCrystals)
        {
            crystal.gameObject.SetActive(true);
        }
        _FlyingPlatformsCrystals.Clear();
    }




    public void CompleteQuest(Quest.QuestType questType)
    {
        _Quests[questType].State = Quest.QuestState.Completed;
        _NPCControllers[questType].SetMarkCompleted(true);
        _NPCControllers[questType].SetMarkActive(true);

        _MessageTitle.text = _Quests[questType].Title;
        _MessageFader.Run();
    }




    public void RewardQuest()
    {
        _Quests[_CurrentQuest].State = Quest.QuestState.Rewarded;
        _NPCControllers[_CurrentQuest].SetMarkActive(false);

        _QuestCanvasGroup.alpha = 0;

        _ScoreController.IncreaseScore(_Quests[_CurrentQuest].Reward);

        switch (_CurrentQuest)
        {
            case Quest.QuestType.MissingFire:
                RewardMissingFireQuest();
                break;
            case Quest.QuestType.MissingGodrays:
                RewardMissingGodraysQuest();
                break;
            case Quest.QuestType.NoTeleports:
                RewardNoTeleportsQuest();
                break;
            case Quest.QuestType.FlyingPlatforms:
                RewardFlyingPlatformsQuest();
                break;
            default:
                break;
        }
    }

    private void RewardMissingFireQuest()
    {
        foreach(FireLampController controller in _FireLamps)
        {
            controller.SetFiredUp(true);
        }
    }

    private void RewardMissingGodraysQuest()
    {
        foreach (GodraysController controller in _Godrays)
        {
            controller.gameObject.SetActive(true);
        }
    }

    private void RewardNoTeleportsQuest()
    {
        foreach (TeleportController controller in _Teleports)
        {
            controller.SwitchedOn = true;
        }
    }

    private void RewardFlyingPlatformsQuest()
    {
        foreach (FlyingPlatformsController controller in _FlyingPlatforms)
        {
            controller.SwitchedOn = true;
        }
    }





    public void CollectLostKeyCrystal()
    {
        _LostKeyCrystalsCount++;

        if (_LostKeyCrystalsCount >= _LostKeyCrystalsLimit)
        {
            CompleteQuest(Quest.QuestType.LostKey);
        }
    }

    public void CollectRedCrystal()
    {
        _FireCrystalsCount++;

        if(_FireCrystalsCount >= _FireCrystalsLimit)
        {
            CompleteQuest(Quest.QuestType.MissingFire);
        }
    }

    public void CollectGodraysCrystal()
    {
        _GodraysCrystalsCount++;

        if (_GodraysCrystalsCount >= _GodraysCrystalsLimit)
        {
            CompleteQuest(Quest.QuestType.MissingGodrays);
        }
    }

    public void CollectTeleportCrystal()
    {
        _TeleportCrystalsCount++;

        if (_TeleportCrystalsCount >= _TeleportCrystalsLimit)
        {
            CompleteQuest(Quest.QuestType.NoTeleports);
        }
    }

    public void CollectFlyingPlatformsCrystal()
    {
        _FlyingPlatformsCrystalsCount++;

        if (_FlyingPlatformsCrystalsCount >= _FlyingPlatformsCrystalsLimit)
        {
            CompleteQuest(Quest.QuestType.FlyingPlatforms);
        }
    }
}
