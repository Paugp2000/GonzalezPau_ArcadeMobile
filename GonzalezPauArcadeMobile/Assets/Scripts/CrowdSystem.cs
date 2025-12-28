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
    [SerializeField] private TextMeshPro numRunners;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRuners();
        NumPlayersMostrar();
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
}
