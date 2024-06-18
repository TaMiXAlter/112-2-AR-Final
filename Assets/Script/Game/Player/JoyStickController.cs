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
}
