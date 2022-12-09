using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : CustomBehaviour
{
    public Vector3 firstPoses;
    Tween scaleTween;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        firstPoses = transform.localPosition;
        // transform.position = new Vector3(GameManager.level.safeArea.position.x, transform.position.y, GameManager.level.safeArea.position.z);
        transform.DOMove(new Vector3(GameManager.level.safeArea.position.x, transform.position.y, GameManager.level.safeArea.position.z), 1f).SetDelay(1f);
    }
    public void IfNotTrue()
    {
        scaleTween = transform.DOScale(Vector3.one * 1.2f, 0.2f).SetLoops(-1, LoopType.Yoyo);
    }
    public void OnSelected()
    {
        scaleTween.Kill();
        transform.DOScale(Vector3.one, 0.2f);
    }
}
