using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputManager : CustomBehaviour
{
    private GameObject selectedObject;
    private Item currentItem;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.eventManager.OnLevelDone += DragAndDrop;
    }
    private void OnDestroy()
    {
        GameManager.eventManager.OnLevelDone -= DragAndDrop;
    }

    #region UpdateFunct
    private void Update()
    {
        DragAndDrop();
    }
    #endregion

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
    public void DragAndDrop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("item"))
                    {
                        return;
                    }
                    selectedObject = hit.collider.gameObject;
                    currentItem = selectedObject.GetComponent<Item>();
                    currentItem.OnSelected();
                }
            }
        }


        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, selectedObject.transform.position.y, worldPosition.z);
        }
        if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            #region Process Of Checking Item After Removing Mouse
            if (Vector3.Distance(new Vector3(selectedObject.transform.localPosition.x, 0, selectedObject.transform.localPosition.z), new Vector3(currentItem.firstPoses.x, 0, currentItem.firstPoses.z)) < 0.5f)
            {
                print("Success");

                selectedObject.tag = "Untagged";

                GameManager.eventManager.IncreaseTotalCorrectItems();
                GameManager.eventManager.OpenSuccesFeedBackPanel();

                currentItem.transform.DOLocalMove(currentItem.firstPoses, 0.1f).OnComplete(() =>
                {
                    currentItem.transform.DOScale(currentItem.transform.localScale * 1.5f, 0.2f).SetEase(Ease.Linear).OnComplete(() => currentItem.transform.DOScale(1f, 0.1f).SetEase(Ease.Linear));
                });
            }
            else
            {
                print("Not Success");
                GameManager.eventManager.OpenNotSuccesFeedBackPanel();
                selectedObject.transform.position = new Vector3(worldPosition.x, selectedObject.transform.position.y, worldPosition.z);
                currentItem.IfNotTrue();
            }
            #endregion

            selectedObject = null;
        }
    }
}
