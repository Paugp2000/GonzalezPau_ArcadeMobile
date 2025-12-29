using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunckManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Chunck[] chunckPrefab;

    private void Start()
    {
        Vector3 chunckPosition = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            Chunck chunckToCreate = chunckPrefab[Random.Range(0,chunckPrefab.Length)];

            if (i > 0)
                chunckPosition.z += chunckToCreate.GetLenght() / 2;

            chunckPosition.y = 1.6f;
            
            Chunck chunckInstance = Instantiate(chunckToCreate, chunckPosition, Quaternion.identity, transform);
            chunckPosition.z += chunckInstance.GetLenght() / 2;

        }
    }
}
