using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogsManager : MonoBehaviour
{
    [SerializeField] private LvLTask _tasks;
    [SerializeField] private Text _dialogText;
    [SerializeField] private float _speedText;
    [SerializeField] private QuestGiveManager _giveManager;

    private string _textTask;
    private bool _isWork;

    private IEnumerator Speaking()
    {
        foreach(char c in _textTask)
        {
            _dialogText.text += c;
            yield return new WaitForSeconds(_speedText);
        }
        ExitDialog();
    }

    private void SwitchStateTask()
    {
        switch (_giveManager.State)
        {
            case QuestState.firstTask:
                _textTask = _tasks.FirstTaskDialog;
                break;
            case QuestState.secondTask:
                _textTask = _tasks.SecondTaskDialog;
                break;
            case QuestState.thirdTask:
                _textTask = _tasks.ThridTaskDialog;
                break;
            case QuestState.foutrhTask:
                _textTask = _tasks.FourthTaskDialog;
                break;
            case QuestState.fiveTask:
                _textTask = _tasks.FiveTaskDialog;
                break;
            case QuestState.sixTask:
                _textTask = _tasks.SixTaskDialog;
                break;
            default:
                _textTask = "Все задачи выполнены";
                break;
        }
    }

    public void StartDialog()
    {
        if (!_isWork)
        {
            _isWork = true;
            SwitchStateTask();
            _dialogText.gameObject.SetActive(true);
            StartCoroutine(Speaking());
        }
    }

    public void ExitDialog()
    {
        _dialogText.gameObject.SetActive(false);
        _isWork = false;
        _dialogText.text = string.Empty;
    }
}
