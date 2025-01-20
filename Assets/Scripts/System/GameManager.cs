using Dan.Main;
using LeaderboardCreatorDemo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    [Header("Game System Variables")]
    [SerializeField] private float timeToNextObject;
    [SerializeField] private float timeChangingObject;
    [SerializeField] public float roundTime;
    [SerializeField] public int points;
    [SerializeField] public QuizObject[] objects;
    [HideInInspector] public int answers;
    [HideInInspector] private float totalTime;
    [HideInInspector] private bool gameStarded;

    [Header("Components and GameObjects")]
    [SerializeField] private GameObject objectPlaceHolder;
    [SerializeField] private Animator objectAnimator;
    [SerializeField] private VirtualKeyboard virtualKeyboard;

    [Header("Scripts")]
    [SerializeField] protected IncomingObjects incomingObjects;
    [SerializeField] protected PanelOptions panelOptions;

    //Tick Control
    public class OnTickEventArgs: EventArgs
    {
        public int tick;
    }
    public static event EventHandler<OnTickEventArgs> OnTick;
    private const float TICK_TIMER_MAX = 5f;
    private int tick;
    private float tickTimer;

    bool answered = false;

    private void Awake()
    {
        tick = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        incomingObjects = GetComponent<IncomingObjects>();
        panelOptions = GetComponent<PanelOptions>();

        gameStarded = false; //Component starts false
        answered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarded)
        {
            roundTime -= Time.deltaTime;
            if (roundTime <= 0)
            {
                roundTime = 0;
                gameStarded = false;
                virtualKeyboard.OpenKeyboard(); //Open keyboard to insert name
                panelOptions.EndGamePanel();
                objectAnimator.SetInteger("transition", 0);
            }
            tickTimer += Time.deltaTime;
            if(tickTimer >= TICK_TIMER_MAX)
            {
                tickTimer -= TICK_TIMER_MAX;
                tick++;
                if (OnTick != null) OnTick(this, new OnTickEventArgs { tick = tick });
                GameStarted();
            }
            Answer();
        }

    }

    private void FixedUpdate()
    {
        
    }

    public void StarGame()
    {
        Leaderboards.CompSoftLeaderboard.UploadNewEntry(VirtualKeyboard.inputText, points); //Sending data to leaderboard
        if (!gameStarded)
        {
            //Starting game with reseted parameters
            answers = 0;
            points = 0;
            roundTime = 60;

            panelOptions.leftPressed = false;
            panelOptions.rightPressed = false;
            gameStarded = true;

            objectAnimator.SetInteger("transition", 1); //Start Anim_Object_Comming animation

            GameStarted();
        }
    }

    public void GameStarted()
    {
        answered = false;
        objectAnimator.SetInteger("transition", 1);//Comming object animation

        //Deactivating all objects first
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].Object.SetActive(false);
        }

        //First Sorting Panel
        panelOptions.SortingPanel();

        // Waiting for player to choose
    }

    public void Answer()
    {
        //If left or right button pressed = go to Anim_Object_Fade animation
        if (panelOptions.leftPressed)
        {
            if (panelOptions.CorrectOption()) points++;
            objectAnimator.SetInteger("transition", 2);
        }

        else if (panelOptions.rightPressed)
        {
            if (panelOptions.CorrectOption()) points++;
            objectAnimator.SetInteger("transition", 2);
        }


        //Setting everythin to false for next object
        panelOptions.leftPressed = false;
        panelOptions.rightPressed = false;

        answered = true;
    }
    
}

[System.Serializable]
public class QuizObject
{
    public string Name;
    public GameObject Object;
}
