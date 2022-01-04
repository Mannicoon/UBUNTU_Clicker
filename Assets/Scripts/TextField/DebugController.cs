using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugController : MonoBehaviour
{
    bool showConsole;

    string input;
    public TMP_InputField inputField;

    public static DebugCommand U_Coin;
    public static DebugCommand MinU_Coin;


    public List<object> commandList;

    public UBUNTU_Script gameScript;

    public void OnToggleDebug()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            showConsole = !showConsole;
            Debug.Log("Tab pressed");
        }
    }

    public void OnReturn()
    {
        if (showConsole)
        {
            HandleInput();
            inputField.text = "";
        }
    }

    public void Awake()
    {
        U_Coin = new DebugCommand("U_Coin", "Adds you 500 U Coin's.", "U_Coin", () =>
        {
            gameScript.U_Coin += 500f;
            Debug.Log("Added");
        });

        MinU_Coin = new DebugCommand("MinU_Coin", "ATakes away 500 U Coin's from you.", "MinU_Coin", () =>
        {
            if(gameScript.U_Coin >= 500)
                gameScript.U_Coin -= 500f;
        });

        commandList = new List<object>
        {
            U_Coin,
            MinU_Coin
        };
    }

    private void OnGUI()
    {
        if (!showConsole) { return; }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 50), "");
        GUI.backgroundColor = new Color(0, 0, 0, 100);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    private void HandleInput()
    {
        for (int i=0; i<commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (inputField.text.Contains(commandBase.commandId))
            {
                if(commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
}
