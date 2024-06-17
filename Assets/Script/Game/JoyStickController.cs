using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public class JoyStickController : MonoBehaviour
{
    [HideInInspector] 
    public RectTransform RectTransform;
    [HideInInspector] 
    public RectTransform Knob;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        Knob = GameObject.Find("JoyStick").GetComponent<RectTransform>();
    }

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
