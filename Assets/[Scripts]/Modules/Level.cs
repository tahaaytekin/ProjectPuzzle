using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : CustomBehaviour
{
    [SerializeField] private int totalItemCount, totalCorrectItem;
    public Transform safeArea;
    public List<Item> items;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        foreach (var item in items)
        {
            item.Initialize(gameManager);
        }
        totalItemCount = items.Count;
        GameManager.eventManager.OnIncreaseTotalCorrectItems += TotalCorrectItemIncrease;
        GameManager.eventManager.OnLevelDone += AllItemsBeen;
    }
    private void OnDestroy()
    {
        GameManager.eventManager.OnIncreaseTotalCorrectItems -= TotalCorrectItemIncrease;
        GameManager.eventManager.OnLevelDone -= AllItemsBeen;
    }
    public void TotalCorrectItemIncrease()
    {
        totalCorrectItem++;
        AllItemsBeen();
    }
    public void AllItemsBeen()
    {
        if (totalCorrectItem == totalItemCount)
        {
            print("Win");
            GameManager.eventManager.ItsLevelDone();
        }
    }
}
