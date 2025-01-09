using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSimulation : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManager;
    public PanelOptions panelOptions;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            gameManager.StarGame();

        if (Input.GetKeyDown(KeyCode.A))
            panelOptions.LeftButton();

        if (Input.GetKeyDown(KeyCode.D))
            panelOptions.RightButton();

        if (Input.anyKey)
            gameManager.StarGame();
    }
}
