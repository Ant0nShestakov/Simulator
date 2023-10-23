using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


enum QuestState
{
    firstTask,
    secondTask, 
    thirdTask
}

public class QuestGiveManager : Command
{
    
    [SerializeField] private AbstractReservuar _reservuar;
    [SerializeField] private PlayerUIManger _playerUIManger;

    private QuestState _state;
    private Animator _animator;

    [field: SerializeField] public LvLTask _tasks { get; private set; }


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_reservuar.LiquidComponent == _tasks.FirstTaskValue && _state == QuestState.firstTask)
        {
            _state = QuestState.secondTask;
            SwitchStateTask();
        }

        if (_reservuar.SecondComponent == _tasks.SecondTaskValue && _state == QuestState.secondTask)
        {
            _state = QuestState.thirdTask;
            SwitchStateTask();
        }

        if (_reservuar.FinishedProduct == _tasks.ThridTaskValue && _state == QuestState.thirdTask)
        {
            Debug.Log("Finish");
        }

    }

    private void SwitchStateTask()
    {
        switch (_state)
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
        }
    }


    public void SetDanceAnimation()
    {
        _animator.SetTrigger("ThisDanceDude");
    }

    public override void Run()
    {
        if(_state == 0)
        {
            _state = QuestState.firstTask;
            SwitchStateTask();
        }
    }
}
