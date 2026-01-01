using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunckManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LevelSO[] levels; 
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
        GenerateLevel();

        finishLine = GameObject.FindGameObjectWithTag("Finish");
    }
    private void GenerateLevel()
    {
        int currentLevel = getLevel();
        currentLevel = currentLevel % levels.Length;
        LevelSO level = levels[currentLevel];
        CreateLevel(level.chuncks);
    }
    private void CreateLevel(Chunck[] levelChuncks )
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
    /*private void CreateRandomLevel()
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
    }*/
    public float getFinishLineZPosition()
    {
        return finishLine.transform.position.z;
    }

    public int getLevel()
    {
        return PlayerPrefs.GetInt("level");
    }
}
