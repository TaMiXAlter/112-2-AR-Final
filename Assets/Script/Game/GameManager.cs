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

    private void Awake()
    {
        HatchTime = MaxhatchTime;
    }
}

