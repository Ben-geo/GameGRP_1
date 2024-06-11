using System;
using UnityEngine;
public class AnimationEventHandler : MonoBehaviour
{
    public event Action OnFinish;
    private void AnimationFinishedTrigger()
    {
        OnFinish?.Invoke();
    }

}
