using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchBarController : MonoBehaviour
{
    private Image fillImage;

    private void Awake()
    {
        fillImage = GameObject.Find("Fill").GetComponent<Image>();
    }

    private void Start()
    {
        fillImage.fillAmount = 1;
        GameManager.Instance.DecreaseHatchEvent += Decrease;
    }

    private void Decrease(int max,int current)
    {
        fillImage.fillAmount = (float)current / max;
    }
}
