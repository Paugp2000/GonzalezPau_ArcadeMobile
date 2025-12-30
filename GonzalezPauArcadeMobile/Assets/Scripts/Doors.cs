using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BonusType { Addition, Diference, Multiply, Divide }
public class Doors : MonoBehaviour
{
    

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rigthDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rigthDoorText;
    [SerializeField] private TextMeshPro leftDoorText;

    [Header("Settings")]
    [SerializeField] private BonusType rigthDoorBonusType;
    [SerializeField] private int rigthDoorBonus;
    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonus;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;

    private void Start()
    {
        ConfigureDoors();
    }

    private void ConfigureDoors()
    {
        switch (rigthDoorBonusType)
        {
            case BonusType.Addition:
                rigthDoorRenderer.color = bonusColor;
                rigthDoorText.text = "+" + rigthDoorBonus;
                break;
            case BonusType.Diference:
                rigthDoorRenderer.color = penaltyColor;
                rigthDoorText.text = "-" + rigthDoorBonus;
                break;
            case BonusType.Multiply:
                rigthDoorRenderer.color = penaltyColor;
                rigthDoorText.text = "*" + rigthDoorBonus;
                break;
            case BonusType.Divide:
                rigthDoorRenderer.color = penaltyColor;
                rigthDoorText.text = "/" + rigthDoorBonus;
                break;
        }
        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonus;
                break;
            case BonusType.Diference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonus;
                break;
            case BonusType.Multiply:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "*" + leftDoorBonus;
                break;
            case BonusType.Divide:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonus;
                break;
        }
    }
    public int getBonusAmount(float xposition)
    {
        if (xposition > 0)
            return rigthDoorBonus;
        else 
            return leftDoorBonus;

    }
    public BonusType getBonusType(float xposition)
    {
        if (xposition > 0)
            return rigthDoorBonusType;
        else
            return leftDoorBonusType;

    }
}
