using UnityEngine;

public abstract class Command : MonoBehaviour
{
    protected PanelText[] panelsText;

    public abstract float Value { get; set; }

    private void Start()
    {
        panelsText = FindObjectsOfType<PanelText>();
    }

    protected void UpdateOnDisplays()
    {
        foreach (var panelText in panelsText) 
        {
            panelText.UpdateInfo();
        }
    }

    public virtual void Switch() { }

    public abstract void Run();
}