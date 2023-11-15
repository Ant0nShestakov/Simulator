using UnityEngine;

public abstract class Command : MonoBehaviour
{
    protected PanelText[] panelsText;

    private void Start()
    {
        panelsText = FindObjectsOfType<PanelText>();
    }

    public abstract float Value { get; set; }
    public abstract void Run();

    protected void UpdateOnDisplays()
    {
        foreach (var panelText in panelsText) 
        {
            panelText.UpdateInfo();
        }
    }
}