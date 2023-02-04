using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is a cool script to call,  when you need some action to be done only once after a timer
public class FunctionTimer
{
    private static List<FunctionTimer> activeTimersList;
    private static GameObject initGameObject;

    private static void InitIfNeeded()
    {
        if (initGameObject == null)
        {
            initGameObject = new GameObject("FunctionTimer_initObject");
            activeTimersList = new List<FunctionTimer>();

        }

    }

    public static FunctionTimer Create(Action action, float timer)
    {
        return Create(action, timer, "", false, false);
    }

    public static FunctionTimer Create(Action action, float timer, string functionName)
    {
        return Create(action, timer, functionName, false, false);
    }

    public static FunctionTimer Create(Action action, float timer, string functionName, bool useUnscaledDeltaTime)
    {
        return Create(action, timer, functionName, useUnscaledDeltaTime, false);
    }

    //a way to call and create a timer through the project
    public static FunctionTimer Create(Action action, float timer, string functionName, bool useUnscaledDeltaTime, bool stopAllWithSameName)
    {
        InitIfNeeded();

        if (stopAllWithSameName)
        {
            StopAllTimersWithName(functionName);
        }

        GameObject gO = new GameObject("FunctionTimer", typeof(MonobehaviourHookUpdate));
        FunctionTimer functionTimer = new FunctionTimer(gO, action, timer, functionName, useUnscaledDeltaTime);

        gO.GetComponent<MonobehaviourHookUpdate>().OnUpdateAction += functionTimer.OnUpdate;

        activeTimersList.Add(functionTimer);
        return functionTimer;

    }






    public static void RemoveTimer(FunctionTimer functionTimer)
    {
        InitIfNeeded();
        activeTimersList.Remove(functionTimer);
    }




    public static void StopAllTimersWithName(string timerName)
    {
        InitIfNeeded();
        for (int i = 0; i < activeTimersList.Count; i++)
        {
            if (activeTimersList[i].timerName == timerName)
            {
                activeTimersList[i].DestroyThisObject();
                i--;
            }
        }
    }

    public static void StopFirstTimerWithName(string timerName)
    {
        InitIfNeeded();
        for (int i = 0; i < activeTimersList.Count; i++)
        {
            if (activeTimersList[i].timerName == timerName)
            {
                activeTimersList[i].DestroyThisObject();
                return;
            }
        }
    }


    //dummy monobehaviour class so we can call the update on our timer
    private class MonobehaviourHookUpdate : MonoBehaviour
    {
        public Action OnUpdateAction;

        private void Update()
        {
            OnUpdateAction?.Invoke();
        }
    }

    private GameObject gameObject;
    private Action Action;
    private float timer;
    private string timerName;
    private bool useUnescaledTime;

    bool hasBeenDestroyed = false;

    private FunctionTimer(GameObject gO, Action action, float time, string timerName, bool useUnscaledDeltaTime)
    {
        this.gameObject = gO;
        this.Action = action;
        this.timer = time;
        this.timerName = timerName;
    }


    public void OnUpdate()
    {
        if (hasBeenDestroyed)
        {
            return;
        }
        if (useUnescaledTime)
        {
            timer -= Time.unscaledDeltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {

            Action();
            DestroyThisObject();
        }
    }


    //clean up crew, for removing the timer from the timer list and destroying the timer object
    private void DestroyThisObject()
    {

        hasBeenDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
        RemoveTimer(this);
    }
}
