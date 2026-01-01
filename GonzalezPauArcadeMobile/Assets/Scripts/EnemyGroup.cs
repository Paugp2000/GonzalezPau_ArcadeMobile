using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int amount;
    [SerializeField] private float angle;
    [SerializeField] private float radius;
    void Start()
    {
        GenerateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateEnemies()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 EnemyLocalPosition = GetRunnerLocalPosition(i);

            Vector3 EnemyWorldPosition = transform.TransformPoint(EnemyLocalPosition);

            Instantiate(EnemyPrefab, EnemyWorldPosition, Quaternion.identity, transform);
        }

    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }
}
