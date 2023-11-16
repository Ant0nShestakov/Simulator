using TMPro;
using UnityEngine;

public class PanelText : MonoBehaviour
{
    [SerializeField] private AbstractReservuar _container;
    [SerializeField] private int _index;
    [SerializeField] private string _name;

    private TextMeshPro _textOnObject;
    private float[] _properties;
    private Conveyor _conveyor;

    // Start is called before the first frame update
    void Start()
    {
        _textOnObject = GetComponentInChildren<TextMeshPro>();
        UpdateInfo();
    }

    public void UpdateInfo() 
    {
        if (_container == null)
        {
            if(_conveyor == null)
                _conveyor = Singelton<Conveyor>.Instance;
            _textOnObject.text = $"{_name}: {_conveyor.Value}";
        }
        else
        {
            _properties = new[] { _container.LiquidComponent, _container.SecondComponent, _container.FinishedProduct };
            _textOnObject.text = $"{_name}: {_properties[_index]}";
        }
    }

    //void LateUpdate()
    //{
    //    _properties = new[] { _container.LiquidComponent, _container.SecondComponent, _container.FinishedProduct };
    //    _textOnObject.text = $"{_name}: {_properties[_index]}";
    //}
}
