using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    #region Singleton
  
    private static GameManager s_Instance = null;
    static public GameManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = GameObject.FindObjectOfType<GameManager>();
                if (s_Instance == null)
                {
                    GameObject GameManger = new GameObject("GameManger");
                    s_Instance = GameManger.AddComponent<GameManager>();
                }
            }
            return s_Instance;
        }
    }
    
    #endregion

    #region Hatch

    [SerializeField,Header("Hatch")]
    private int MaxhatchTime = 100 ;
    private int HatchTime;
    public event Action<int,int> DecreaseHatchEvent;
    public int GetHatchTime(){return HatchTime;}
    public void DecreaseHatchTime()
    {
        HatchTime-=1;
        DecreaseHatchEvent?.Invoke(MaxhatchTime,HatchTime);
    }
    
    #endregion
    
    # region PlayerHP
    
    public int HP = 3;
    public event Action DecreasePlayerHPEvent; 
    public void DecreasePlayerHP()
    {
        HP--;
        DecreasePlayerHPEvent?.Invoke();
    }
    #endregion
    
    [SerializeField,Header("EnemySpawner")]
    private GameObject EnemySpawnerPerfeb;
    [SerializeField]
    private float spawnInterval = 1.0f;

    [SerializeField] private float spawnIntervalDelta = 0.05f;
    [SerializeField] private float SpawnPositionRadius = 5.0f;
    private bool IsSpawning = true;
    private void Awake()
    {
        HatchTime = MaxhatchTime;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemySpawner(spawnInterval));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,SpawnPositionRadius);
    }
    IEnumerator SpawnEnemySpawner(float time)
    {
        yield return new WaitForSeconds(time);
        //get postion
        float randomX = UnityEngine.Random.Range(-SpawnPositionRadius, SpawnPositionRadius);
        float randomY = UnityEngine.Random.Range(-SpawnPositionRadius, SpawnPositionRadius);
        Vector3 SpawnPosion = new Vector3(randomX, randomY, 2.7f);
        
        GameObject newEnemy = Instantiate(EnemySpawnerPerfeb,SpawnPosion,Quaternion.identity);
        
        if (spawnInterval > spawnIntervalDelta)
        {
            spawnInterval -= spawnIntervalDelta;
        }
        if (IsSpawning)
        {
            StartCoroutine(SpawnEnemySpawner(spawnInterval));
        }
    }
}

