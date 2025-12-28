using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CrowdSystem : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private float radius;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRuners();
    }

    private void PlaceRuners()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 childlocalPosition = GetRunnerLocalPosition(i);
            transform.GetChild(i).localPosition = childlocalPosition;
        }
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }
}
