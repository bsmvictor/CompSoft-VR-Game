using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    [Header("Game System Variables")]
    [SerializeField] private float timeToNextObject;
    [SerializeField] private int points;
    [SerializeField] private Objects[] objects;
    [HideInInspector] public int answers;
    [HideInInspector] private float totalTime;
    [HideInInspector] private bool gameStarded;

    [Header("Components and GameObjects")]
    [SerializeField] private GameObject objectPlaceHolder;
    [SerializeField] private Animator objectAnimator;

    [Header("Scripts")]
    [SerializeField] protected IncomingObjects incomingObjects;
    [SerializeField] protected PanelOptions panelOptions;


    // Start is called before the first frame update
    void Start()
    {
        incomingObjects = GetComponent<IncomingObjects>();
        panelOptions = GetComponent<PanelOptions>();

        gameStarded = false; //Component starts false
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarded) //Only happens when press StartGame() button
        {
            //If left or right button pressed = go to Anim_Object_Fade animation

            if (panelOptions.leftPressed)
                objectAnimator.SetInteger("transition", 2);

            else if (panelOptions.rightPressed)
                objectAnimator.SetInteger("transition", 2);

            //objectAnimator.SetInteger("transition", 1);

            //Setting everythin to false for next object

            panelOptions.leftPressed = false;
            panelOptions.rightPressed = false;
        }
    }

    public void StarGame()
    {
        if (!gameStarded)
        {
            //Starting game with reseted parameters
            answers = 0;
            points = 0;

            panelOptions.leftPressed = false;
            panelOptions.rightPressed = false;
            gameStarded = true;

            objectAnimator.SetInteger("transition", 1); //Start Anim_Object_Comming animation
        }
    }
}

[System.Serializable]
class Objects
{
    public string Name;
    public GameObject Object;
}
