using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHatchEgg : MonoBehaviour
{
    private RaycastHit hit;
    private LayerMask EggMask;

    private void Awake()
    {
        EggMask =  1 << LayerMask.NameToLayer("Egg");
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit,5f,EggMask))
        {
            GameManager.Instance.DecreaseHatchTime();
            
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            // Debug.Log("Did Hit");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
