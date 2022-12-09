using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManager : CustomBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject feedBackPanel;
    [SerializeField] private TextMeshProUGUI feedBackTxt;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.eventManager.OnLevelDone += OpenWýnPanel;
        GameManager.eventManager.OnSuccessFeedBackPanel += OpenSuccesFeedBackPanel;
        GameManager.eventManager.OnNotSuccessFeedBackPanel += OpenNotSuccesFeedBackPanel;
    }
    private void OnDestroy()
    {
        GameManager.eventManager.OnLevelDone -= OpenWýnPanel;
        GameManager.eventManager.OnSuccessFeedBackPanel -= OpenSuccesFeedBackPanel;
        GameManager.eventManager.OnNotSuccessFeedBackPanel -= OpenNotSuccesFeedBackPanel;
    }
    public void OpenWýnPanel()
    {
        inGamePanel.SetActive(false);
        winPanel.SetActive(true);
        winPanel.transform.DOScale(Vector3.one, 1f);
    }
    public void OpenSuccesFeedBackPanel()
    {
        feedBackPanel.SetActive(true);
        feedBackTxt.text = "Successfull";
        feedBackTxt.color = Color.green;
        feedBackPanel.transform.DOScale(1.5f, 0.2f).OnComplete(() => feedBackPanel.transform.DOScale(1f, 0.2f).OnComplete(() =>
        {
            feedBackPanel.transform.DOScale(Vector3.zero, 0.4f).SetDelay(0.5f);
        }));
    }
    public void OpenNotSuccesFeedBackPanel()
    {
        feedBackPanel.SetActive(true);
        feedBackTxt.text = "Not Successfull!";
        feedBackTxt.color = Color.red;
        feedBackPanel.transform.DOScale(1.5f, 0.2f).OnComplete(() => feedBackPanel.transform.DOScale(1f, 0.2f).OnComplete(() =>
        {
            feedBackPanel.transform.DOScale(Vector3.zero, 0.4f).SetDelay(0.5f);
        }));
    }

}
