using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 JoyStickSize = new Vector2(300f, 300f);
    [SerializeField]
    private JoyStickController joyStickController;
    
    private Finger MovementFinger;
    [SerializeField,Header("Spector")]
    private Vector2 MovementAmount;
    [SerializeField]
    private float Speed = 0.1f;

    #region  TouchController
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.onFingerDown += OnFingerDown;
        ETouch.onFingerMove += OnFingerMove;
        ETouch.onFingerUp += OnFingerUp;
    }

    private void OnDisable()
    {
        ETouch.onFingerDown -= OnFingerDown;
        ETouch.onFingerMove -= OnFingerMove;
        ETouch.onFingerUp -= OnFingerUp;
        EnhancedTouchSupport.Disable();
    }

    private void OnFingerDown(Finger Finger)
    {
        MovementFinger = Finger;
        MovementAmount = Vector2.zero;
        joyStickController.gameObject.SetActive(true);
        joyStickController.RectTransform.sizeDelta = JoyStickSize;
        joyStickController.RectTransform.anchoredPosition =ClampStartPosition(Finger.screenPosition);
    }
    private void OnFingerMove(Finger Finger)
    {
        if (Finger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoyStickSize.x/2;
            ETouch currentTouch = MovementFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition,
                    joyStickController.RectTransform.anchoredPosition)>maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - 
                                joyStickController.RectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - joyStickController.RectTransform.anchoredPosition;
            }

            joyStickController.Knob.anchoredPosition = knobPosition;
            MovementAmount = knobPosition / maxMovement;
        }
    }
    private void OnFingerUp(Finger LostFinger)
    {
        if (MovementFinger == LostFinger)
        {
            MovementFinger = null;
            joyStickController.Knob.anchoredPosition = Vector2.zero;
            joyStickController.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
        }
    }
    
    private Vector2 ClampStartPosition(Vector2 StartPosition)
    { 
        if(StartPosition.x < JoyStickSize.x/2) StartPosition.x = JoyStickSize.x/2;
        if(StartPosition.y < JoyStickSize.y/2) StartPosition.y = JoyStickSize.y/2;
        else if (StartPosition.y > Screen.height - JoyStickSize.y/2) StartPosition.y = Screen.height - JoyStickSize.y/2;
        return StartPosition;
    }
    #endregion

    private void Start()
    {
        joyStickController.gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector3 moveV3 = Speed*Time.deltaTime* new Vector3(MovementAmount.x, MovementAmount.y, 0f);
        transform.Translate(moveV3);
    }
}
