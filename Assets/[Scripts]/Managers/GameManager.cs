using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CustomBehaviour
{
    public EventManager eventManager;
    public UIManager uIManager;
    public InputManager InputManager;

    private void Awake()
    {
        uIManager.Initialize(this);
        InputManager.Initialize(this);
        eventManager.Initialize(this);


        eventManager.GameStarted();
    }
}
