using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    #region Singleton
    private static StageManager s_Instance = null;
    static public StageManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = StageManager.FindObjectOfType<StageManager>();
                if (s_Instance == null)
                {
                    GameObject StageManager = new GameObject("StageManager");
                    s_Instance = StageManager.AddComponent<StageManager>();
                }
            }
            return s_Instance;
        }
    }
    #endregion
    
    [SerializeField]
    private List<GameObject> Stages = new List<GameObject>();
    // Start is called before the first frame update
    void OnEnable()
    {
        foreach (var stage in Stages)
        {
            stage.SetActive(false);
        }
        Stages[0].SetActive(true);
    }

    public void StartGame()
    {
        Stages[0].SetActive(false);
        Stages[1].SetActive(true);
    }
    
    public void EndGame(bool isWin)
    {
        Stages[1].SetActive(false);
        if (isWin)
        {
            Stages[2].SetActive(true);
        }
        else
        {
            Stages[3].SetActive(true);
        }
    }
    
}
