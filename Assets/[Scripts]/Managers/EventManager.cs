using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : CustomBehaviour
{
    public Action OnGameStart;
    public Action OnLevelDone;
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
}
