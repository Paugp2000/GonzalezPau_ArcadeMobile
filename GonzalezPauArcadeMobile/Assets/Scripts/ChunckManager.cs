using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunckManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Chunck[] chunckPrefab;
    [SerializeField] private Chunck[] levelChuncks;
    private GameObject finishLine;
    public static ChunckManager Instance;
    private void Awake()
    {
       if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        CreateOrderedLevel();

        finishLine = GameObject.FindGameObjectWithTag("Finish");
    }
    private void CreateOrderedLevel()
    {
        Vector3 chunckPosition = Vector3.zero;
        for (int i = 0; i < levelChuncks.Length; i++)
        {
            Chunck chunckToCreate = levelChuncks[i];

            if (i > 0)
                chunckPosition.z += chunckToCreate.GetLenght() / 2;

            chunckPosition.y = 1.6f;

            Chunck chunckInstance = Instantiate(chunckToCreate, chunckPosition, Quaternion.identity, transform);
            chunckPosition.z += chunckInstance.GetLenght() / 2;

        }
    }
    private void CreateRandomLevel()
    {
        Vector3 chunckPosition = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            Chunck chunckToCreate = chunckPrefab[Random.Range(0, chunckPrefab.Length)];

            if (i > 0)
                chunckPosition.z += chunckToCreate.GetLenght() / 2;

            chunckPosition.y = 1.6f;

            Chunck chunckInstance = Instantiate(chunckToCreate, chunckPosition, Quaternion.identity, transform);
            chunckPosition.z += chunckInstance.GetLenght() / 2;

        }
    }
    public float getFinishLineZPosition()
    {
        return finishLine.transform.position.z;
    }

    public int getLevel()
    {
        return PlayerPrefs.GetInt("level");
    }
}
