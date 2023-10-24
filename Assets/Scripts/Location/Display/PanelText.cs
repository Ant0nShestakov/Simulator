using TMPro;
using UnityEngine;

public class PanelText : MonoBehaviour
{
    [SerializeField] private AbstractReservuar _container;
    [SerializeField] private int _index;

    private TextMeshPro _textOnObject;
    private float[] _properties;

    // Start is called before the first frame update
    void Start()
    {
        _textOnObject = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _properties = new[] { _container.LiquidComponent, _container.SecondComponent, _container.FinishedProduct };
        _textOnObject.text = $"{_properties[_index]}";
    }
}
