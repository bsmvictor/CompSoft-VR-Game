using Dan.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualKeyboard : MonoBehaviour
{
    [SerializeField] private Leaderboard leaderboard;
    private TouchScreenKeyboard overlayKeyboard;
    public static string inputText = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (overlayKeyboard != null)
        {
            inputText = overlayKeyboard.text;
            leaderboard.UploadEntry();
        }
    }

    public void OpenKeyboard()
    {
        overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
