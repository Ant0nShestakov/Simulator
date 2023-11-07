using UnityEngine;

public enum QuestState
{
    firstTask,
    secondTask, 
    thirdTask,
    foutrhTask,
    fiveTask,
    sixTask,
    complete
}

public class QuestGiveManager : MonoBehaviour
{
    [SerializeField] private Reservuar _reservuar;
    [SerializeField] private Reactor _reactor;
    [SerializeField] private PlayerUIManger _playerUIManger;

    private Animator _animator;

    [field: SerializeField] public LvLTask _tasks { get; private set; }
    public QuestState State { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void SwitchStateTask()
    {
        if (_reservuar.LiquidComponent >= _tasks.FirstTaskValue && State == QuestState.firstTask)
        {
            State = QuestState.secondTask;
            return;
        }
        if (_reservuar.SecondComponent >= _tasks.SecondTaskValue && State == QuestState.secondTask)
        {
            State = QuestState.thirdTask;
            return;
        }
        if (_reactor.SecondComponent >= _tasks.ThridTaskValue && State == QuestState.thirdTask)
        {
            State = QuestState.foutrhTask;
            return;
        }
        if (_reactor.SecondComponent >= _tasks.FourthTaskValue && State == QuestState.foutrhTask) 
        {
            State = QuestState.fiveTask;
            return;
        }
        if (_reactor.LiquidComponent >= _tasks.FiveTaskValue && State == QuestState.fiveTask)
        {
            State = QuestState.sixTask;
            return;
        }

        if (_reactor.FinishedProduct >= _tasks.SixTaskValue && State == QuestState.sixTask)
        {
            State = QuestState.complete;
            return;
        }

    }

    private void SwitchTask()
    {
        switch (State)
        {
            case QuestState.firstTask:
                _playerUIManger._uiTask.text = _tasks.FirstTask;
                break;
            case QuestState.secondTask:
                _playerUIManger._uiTask.text = _tasks.SecondTask;
                break;
            case QuestState.thirdTask:
                _playerUIManger._uiTask.text = _tasks.ThridTask;
                break;
            case QuestState.foutrhTask:
                _playerUIManger._uiTask.text = _tasks.FourthTask;
                break;
            case QuestState.fiveTask:
                _playerUIManger._uiTask.text = _tasks.FiveTask;
                break;
            case QuestState.sixTask:
                _playerUIManger._uiTask.text = _tasks.SixTask;
                break;
            default:
                _playerUIManger._uiTask.text = "Все задачи выполнены";
                break;
        }
    }

    public void SetDanceAnimation() => _animator.SetTrigger("ThisDanceDude");

    public void StartTask()
    {
        SwitchStateTask();
        SwitchTask();
    }
}
