using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] int resourceAmount = 100;
    Text resourceText;

    void Start()
    {
        resourceText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        resourceText.text = resourceAmount.ToString();
    }

    public bool HaveEnoughtResources(int amount)
    {
        return resourceAmount >= amount;
    }

    public void AddResource(int amount)
    {
        resourceAmount += amount;
        UpdateDisplay();
    }

    public void SpendResource(int amount)
    {
        if (resourceAmount >= amount)
        {
            resourceAmount -= amount;
            UpdateDisplay();
        }
    }
}
