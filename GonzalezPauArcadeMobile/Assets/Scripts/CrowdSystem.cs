using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CrowdSystem : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private float radius;
    [SerializeField] private Transform runnersParent;
    [SerializeField] private GameObject runnerPrefab;
    [SerializeField] private TextMeshPro numRunners;
    public static Action onGoodDoorSound;
    public static Action onBadDoorSound;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRuners();
        NumPlayersMostrar();

        if (runnersParent.childCount == 0)
        {
            GameManager.Instance.setGamestate(GameManager.GameState.Gameover);  
        }
    }

    private void PlaceRuners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childlocalPosition = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childlocalPosition;
        }
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }

    private void NumPlayersMostrar()
    {
        numRunners.text = runnersParent.childCount.ToString();
    }

    public float returnCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnersParent.childCount);
    }

    public void ApplyBonus(int bonusAmount, BonusType bonusType)
    {
        switch(bonusType)
        {
            case BonusType.Addition:
                onGoodDoorSound?.Invoke();
                AddRunners(bonusAmount);
                break;
            case BonusType.Diference:
                onBadDoorSound?.Invoke();
                QuitRunners(bonusAmount);
                break;
            case BonusType.Multiply:
                onGoodDoorSound?.Invoke();
                AddRunners(runnersParent.childCount * bonusAmount - runnersParent.childCount);
                break;
            case BonusType.Divide:
                onBadDoorSound?.Invoke();
                QuitRunners(runnersParent.childCount - runnersParent.childCount / bonusAmount);
                break;
        }
    }
    public void AddRunners(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(runnerPrefab, runnersParent);
        }
    }
    public void QuitRunners(int number)
    {
        if (number >= runnersParent.childCount)
        {
            for (int i = 0; i < number; i++)
            {
                Debug.Log("El numero de corredores es : " + runnersParent.childCount);

                GameManager.Instance.setGamestate(GameManager.GameState.Gameover);
                Destroy(this.gameObject);
            }
        }
        else if (number < runnersParent.childCount)
        {
            for (int i = 0; i < number; i++)
            {
                Transform runnerTodestroy = runnersParent.GetChild(i);
                runnerTodestroy.SetParent(null);
                Destroy(runnerTodestroy.gameObject);
            }
        }
       
    }
}
