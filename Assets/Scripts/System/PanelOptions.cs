using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelOptions : MonoBehaviour
{
    //Variables
    [Header("Components and GameObjects")]
    [SerializeField] private GameObject objectPlaceHolder;
    [SerializeField] private Animator objectAnimator;
    [SerializeField] private Text leftText;
    [SerializeField] private Text rightText;
    [SerializeField] private UnityEngine.UI.Button leftButton;
    [SerializeField] private UnityEngine.UI.Button rightButton;

    [Header("Panel Settings")]
    [HideInInspector] public bool leftPressed;
    [HideInInspector] public bool rightPressed;

    private void Start()
    {
        leftPressed = false;
        rightPressed = false;
    }

    public void LeftButton()
    {
        leftPressed = true; //If press left panel button
    }

    public void RightButton()
    {
        rightPressed = true; //If press right panel button
    }
}
