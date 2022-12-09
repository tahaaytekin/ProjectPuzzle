using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : CustomBehaviour
{
    private int currentLevel;
    private GameObject level;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
       GameManager.eventManager.OnGameStart += OpenCurrentLevel;
    }
    private void OnDestroy()
    {
        GameManager.eventManager.OnGameStart -= OpenCurrentLevel;
    }
    private void OpenCurrentLevel()
    {
        currentLevel = PlayerPrefs.GetInt("Level", 0);
        //  level_text.text = "Level " + (currentLevel + 1);
        if (currentLevel > 1)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            currentLevel = Random.Range(1, 2);
            level = (GameObject)Instantiate(Resources.Load("Level" + currentLevel));
        }
        else
        {
            level = (GameObject)Instantiate(Resources.Load("Level" + currentLevel));
        }
    }
    public void LevelUp()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
