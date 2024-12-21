using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

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

    [Header("Scripts")]
    [SerializeField] private GameManager gameManager;

    [Header("Panel Settings")]
    [HideInInspector] public bool leftPressed;
    [HideInInspector] public bool rightPressed;

    [Header("Generic")]
    QuizObject[] objects;
    string correctAnswer;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();

        objects = gameManager.objects;

        leftPressed = false;
        rightPressed = false;
    }

    //Sorting panel every new object
    public void SortingPanel()
    {
        int panelSide = Random.Range(0, 1);
        int selectedObject = Random.Range(0, objects.Length);
        int randomObject = Random.Range(0, objects.Length);
        if (panelSide == 0) //Left button is correct
        {
            leftText.text = objects[selectedObject].Name;
            correctAnswer = leftText.text;
            objectPlaceHolder = objects[selectedObject].Object;
            rightText.text = objects[randomObject].Name;
        }
        else if (panelSide == 1) //Right button is correct
        {
            leftText.text = objects[randomObject].Name;
            objectPlaceHolder = objects[selectedObject].Object;
            rightText.text = objects[selectedObject].Name;
            correctAnswer = rightText.text;
        }
        else if (selectedObject == randomObject)
            SortingPanel();
    }

    public bool CorrectOption()
    {
        if(leftText.text == correctAnswer && leftPressed) return true;
        else if(leftText.text != correctAnswer && leftPressed) return false;

        else if(rightText.text == correctAnswer && rightPressed) return true;
        else return false;
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
