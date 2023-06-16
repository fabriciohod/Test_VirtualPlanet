using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Timer
{
    [SerializeField] float durationInSecs;
    [SerializeField] bool countDown;
    public UnityEvent<int> OnTimerTick;
    public UnityEvent<float> OnTimerTick01;
    public UnityEvent OnTimerEnded;

    public void StartTimer(Action callBackOnEnd = default)
    {
        if (countDown)
        {
            TimerCountDown(callBackOnEnd);
            return;
        }

        TimerCountUp(callBackOnEnd);
    }

    async void TimerCountUp(Action callbackOnEnd)
    {
        float passedTime = 0f;

        while (passedTime < durationInSecs)
        {
            passedTime += Time.deltaTime;

            OnTimerTick?.Invoke((int)passedTime);
            OnTimerTick01?.Invoke(passedTime / durationInSecs);

            await Task.Yield();
        }

        callbackOnEnd?.Invoke();
        OnTimerEnded?.Invoke();
    }
    async void TimerCountDown(Action callbackOnEnd)
    {
        float passedTime = durationInSecs;
        while (passedTime > 0)
        {
            passedTime -= Time.deltaTime;

            OnTimerTick?.Invoke((int)passedTime);
            OnTimerTick01?.Invoke(passedTime / durationInSecs);

            await Task.Yield();
        }

        callbackOnEnd?.Invoke();
        OnTimerEnded?.Invoke();
    }
}
