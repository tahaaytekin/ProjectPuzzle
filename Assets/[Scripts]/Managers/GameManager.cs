using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CustomBehaviour
{
    public EventManager eventManager;
    public UIManager uIManager;
    public InputManager InputManager;
    public LevelManager levelManager;
    public Level level;
    private void Awake()
    {
        uIManager.Initialize(this);
        InputManager.Initialize(this);
        eventManager.Initialize(this);
        levelManager.Initialize(this);

        eventManager.GameStarted();

        level = GameObject.FindGameObjectWithTag("Level").GetComponent<Level>();
        level.Initialize(this);
    }
}
