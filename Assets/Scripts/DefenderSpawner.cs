using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var resourceDisplay = FindObjectOfType<ResourceDisplay>();
        int defenderCost = defender.GetResourceCost();
        if (resourceDisplay.HaveEnoughtResources(defenderCost))
        {
            SpawnDefender(gridPos);
            resourceDisplay.SpendResource(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos =  Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
        
    }

    private Vector2 SnapToGrid(Vector2 pos)
    {
        float newX = Mathf.RoundToInt(pos.x);
        float newY = Mathf.RoundToInt(pos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 pos)
    {
        Defender newDefender = Instantiate(defender, pos, Quaternion.identity, defenderParent.transform) as Defender;
    }
}
