using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyAI : MonoBehaviour,IDamageable
{
    private GameObject Target;
    [SerializeField]
    private float speed = 5.0f;


    private void Awake()
    {
        Target = GameObject.Find("Eggs").gameObject;

        if (Target == null)
        {
            Debug.LogWarning("No target found");
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        if (transform.position == Target.transform.position)
        {
            GameManager.Instance.DecreasePlayerHP();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
