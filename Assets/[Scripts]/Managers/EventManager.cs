using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : CustomBehaviour
{
    public Action OnGameStart;
    public Action OnLevelDone;
    public Action OnIncreaseTotalCorrectItems;
    public Action OnSuccessFeedBackPanel;
    public Action OnNotSuccessFeedBackPanel;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
    }
    public void GameStarted()
    {
        OnGameStart?.Invoke();
    }
    public void ItsLevelDone()
    {
        OnLevelDone?.Invoke();
    }
    public void IncreaseTotalCorrectItems()
    {
        OnIncreaseTotalCorrectItems?.Invoke();
    }
    public void OpenSuccesFeedBackPanel()
    {
        OnSuccessFeedBackPanel?.Invoke();
    }
    public void OpenNotSuccesFeedBackPanel()
    {
        OnNotSuccessFeedBackPanel?.Invoke();
    }
}
