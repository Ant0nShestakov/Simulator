using UnityEngine;

public enum QuestState
{
    firstTask,
    secondTask, 
    thirdTask,
    complete
}

public class QuestGiveManager : MonoBehaviour
{
    [SerializeField] private AbstractReservuar _reservuar;
    [SerializeField] private PlayerUIManger _playerUIManger;

    private Animator _animator;

    [field: SerializeField] public LvLTask _tasks { get; private set; }
    public QuestState State { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_reservuar.LiquidComponent == _tasks.FirstTaskValue && State == QuestState.firstTask)
        {
            State = QuestState.secondTask;
            SwitchStateTask();
        }
        if (_reservuar.SecondComponent == _tasks.SecondTaskValue && State == QuestState.secondTask)
        {
            State = QuestState.thirdTask;
            SwitchStateTask();
        }
        if (_reservuar.FinishedProduct == _tasks.ThridTaskValue && State == QuestState.thirdTask)
        {
            State = QuestState.complete;
            SwitchStateTask();
        }
    }

    private void SwitchStateTask()
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
            default:
                _playerUIManger._uiTask.text = "Все задачи выполнены";
                break;
        }
    }

    public void SetDanceAnimation() => _animator.SetTrigger("ThisDanceDude");

    public void StartTask()
    {
        if(State == 0)
        {
            State = QuestState.firstTask;
            SwitchStateTask();
        }
    }
}
