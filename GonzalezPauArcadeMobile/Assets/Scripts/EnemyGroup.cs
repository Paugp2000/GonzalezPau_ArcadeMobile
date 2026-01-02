using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] public int amount;
    [SerializeField] private float angle;
    [SerializeField] private float radius;
    [SerializeField] private TextMeshPro textBubbleCount;
    [SerializeField] private GameObject Bubble;
    [SerializeField] private Transform enemiesParent;
    private bool EnemiesCreated = false;
    void Start()
    {
        GenerateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesCreated == true)
        {
            ShowTextCount();
        }
    }
    private void GenerateEnemies()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 EnemyLocalPosition = GetRunnerLocalPosition(i);

            Vector3 EnemyWorldPosition = transform.TransformPoint(EnemyLocalPosition);

            Instantiate(EnemyPrefab, EnemyWorldPosition, Quaternion.identity, enemiesParent);
        }
        EnemiesCreated=true;
    }
    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }

    public void ShowTextCount()
    {
        textBubbleCount.text = enemiesParent.childCount.ToString();

        if (enemiesParent.childCount == 0)
        {
            Destroy(Bubble);
        }
    }

    public void AddEnemies(int number)
    {
        Instantiate(EnemyPrefab, enemiesParent);
    }
}
