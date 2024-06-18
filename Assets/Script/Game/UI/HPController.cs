using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HPController : MonoBehaviour
{ 
    [SerializeField]
  private GameObject HeartPerfeb;
  
  private Stack<GameObject> Hearts = new Stack<GameObject>();

  private void Start()
  {
    for (int i = 0; i < GameManager.Instance.HP; i++)
    {
       GameObject heart = Instantiate(HeartPerfeb, transform);
       Hearts.Push(heart);
    }
    GameManager.Instance.DecreasePlayerHPEvent += PlayerDamage;
  }

  void PlayerDamage()
  { 
      GameObject destroyedHeart;
      Hearts.TryPop(out destroyedHeart);
      if (destroyedHeart)
      {
          Destroy(destroyedHeart);
      }
      
  }
}
