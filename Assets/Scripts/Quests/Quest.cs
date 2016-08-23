using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest {

    public enum QuestType
    {
        LostSon = 0,
        LostKey,
        OldMansQuest,
        MissingFire,
        MissingGodrays,
        NoTeleports,
        FlyingPlatforms,
        None
    }

    public enum QuestState
    {
        Idle = 0,
        Active,
        Completed,
        Rewarded
    }



    private QuestType _Type;

    private QuestState _State;

    private string _Title;

    private string _IdleText;

    private string _ActiveText;

    private string _CompletedText;

    private string _Summary;
    
    private int _Reward;



    public QuestState State { get { return _State; } set { _State = value; } }

    public QuestType Type { get { return _Type; } }

    public string Title { get { return _Title; } }

    public string IdleText { get { return _IdleText; } }

    public string ActiveText { get { return _ActiveText; } }

    public string CompletedText { get { return _CompletedText; } }

    public string Summary { get { return _Summary; } }

    public int Reward { get { return _Reward; } }

    public string GetDescription()
    {
        switch(_State)
        {
            case QuestState.Idle:
                return _IdleText;
            case QuestState.Active:
                return _ActiveText;
            case QuestState.Completed:
                return _CompletedText;
            default:
                return "";
        }
    }

    public string GetHint()
    {
        switch (_State)
        {
            case QuestState.Idle:
                return "[Hint] Press 'E' to accept the task";
            case QuestState.Completed:
                return "[Hint] Press 'E' to get reward";
            default:
                return "";
        }
    }


    public static Quest CreateQuest(QuestType questType)
    {
        switch(questType)
        {
            case QuestType.LostSon:
                return new Quest(questType, 50000, "Lost son",
                    "Honey! Out son is gone!",
                    "glad to see you? Have you found our son?",
                    "Oh honey! You did it. You've brought our son back! I love you so much!",
                    "Find your son.");
            case QuestType.LostKey:
                return new Quest(questType, 1000, "Dropped key",
                    "I've dropped my crystal key and cannot open the door to my house. Could you go down and find it for me?",
                    "Have you found my key down there?",
                    "Great. You've found my key. Thanks for help.",
                    "Find lost Key Crystal.");
            case QuestType.OldMansQuest:
                return new Quest(questType, 500, "Old man's quest",
                    "Welcome sir. Could you help an old man in his quest? Yep. I'm pretty blind without my glasses. And I lost them this mornig. Can you find them for me?",
                    "How it's going? Have you found my crystals?",
                    "You have my thanks kind sir. I really appreciate your help. Please, take this little gift.",
                    "Find old man's glasses.");
            case QuestType.MissingFire:
                return new Quest(questType, 5000, "Fire's gone", 
                    "Help! I've lost my red crystals! I'm ruined! I'll never finish my super magic pot without them. Maybe you could bring me new ones?",
                    "How it's going? Have you found my crystals?",
                    "Thanks! You are my hero! Now I can finish my magic pot.",
                    "Collect 10 Red Crystals.");
            case QuestType.MissingGodrays:
                return new Quest(questType, 5000, "Strange magic",
                    "Stranger... Do you sense this strange magic? It curses our land since yesterday...\n" +
                    "I think I could break this evil spell, but I need more mana crystals.\n" + 
                    "Bring me five of them. It should be enough...",
                    "Have my crystals, haven't you?",
                    "Dirty magic! Dirty mahic! Uga #buga! G$h g$h $4s ur!",
                    "Collect 5 Mana Crystals.");
            case QuestType.NoTeleports:
                return new Quest(questType, 1000, "Broken teleport",
                    "Hi, can you help me? I'm trying to fix this teleport to get back home." +
                    "\nHowever I cannot find a teleport crystal that could activate it." +
                    "\nIt's blue, pretty big and usually have other smaller crystals around it.",
                    "Hi again, have you found the teleport crystal?",
                    "Yes! That's it! Let's try this.\nLook!\nThe portal works again!",
                    "Find Teleport Crystal.");
            case QuestType.FlyingPlatforms:
                return new Quest(questType, 1000, "Flying platforms",
                    "I'm sorry, but today you cannot use flying platforms." +
                    "\nThey have stopped last night. Furthermore all magic crystals that can move them have been stolen!" +
                    "\nIf you want to run platforms you have to bring me four purple crystals.",
                    "Hi again, wanna ride?",
                    "Yes, with those crystals we can use moving platforms again!",
                    "Find 4 Purple Crystals.");
            default:
                return null;
        }
    }

    protected Quest(QuestType questType, int reward, string title, string idleText, string activeText, string completedText, string summary)
    {
        _State = QuestState.Idle;

        _Type = questType;
        _Reward = reward;

        _Title = title;
        _IdleText = idleText;
        _ActiveText = activeText;
        _CompletedText = completedText;
        _Summary = summary;
    }
}
