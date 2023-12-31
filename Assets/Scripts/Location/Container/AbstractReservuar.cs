using System.Collections;
using UnityEngine;

public abstract class AbstractReservuar : Command
{   
    public abstract string Name { get; set; }
    public abstract float LiquidComponent { get; set; }
    public abstract float SecondComponent { get; set; }
    public abstract float FinishedProduct { get; set; }
    public sealed override float Value { get; set; }

    protected abstract void Loading();

    protected virtual void StartAudio() { }

    protected virtual void StopAudio() { }

    protected IEnumerator Cooking(float time)
    {
        while (SecondComponent > 0)
        {
            yield return new WaitForSecondsRealtime(time);
            StartAudio();
            Loading();
            UpdateOnDisplays();
        }
        StopAudio();
    }
}