using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

    GUIStyle myStyle;
    float buttonSize;
    bool isOptionsOpen = false;

    public Texture2D[] characterButtons;

    public Texture2D playTexture;
    public Texture2D optionsTexture;
    public Texture2D backTexture;
    public Texture2D scoreboardTexture;
    public Texture2D quitTexture;

    public Texture2D greenTexture;
    public Texture2D whiteTexture;

    void Start () {
        
	}
		
	void Update () {
	
	}

    void OnGUI()
    {
        buttonSize = Screen.height * 0.15f;
        if (myStyle == null)
        {
            myStyle = GetMyStyle();
        }

        if (!isOptionsOpen)
        {
            DrawStartButton();
            //DrawScoreboardButton();
            DrawOptionsButton();
        }
        else
        {
            DrawCharacterSelectionButtons();
            DrawCloseOptionsButton(); 
        }


        //GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100), "Orc Invaders", myStyle);
        /*if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 40), "Play as Mage"))
        {
            PlayerPrefs.SetInt("SelectedCharacter", 0);
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2+50, 100, 40), "Play as Ninja"))
        {
            PlayerPrefs.SetInt("SelectedCharacter", 1);
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2+100, 100, 40), "Play as Robot"))
        {
            PlayerPrefs.SetInt("SelectedCharacter", 2);
            Application.LoadLevel(1);
        }*/

    }



    private void DrawCharacterSelectionButtons()
    {
        var buttonPos = new Rect(Screen.width / 2 - buttonSize, Screen.height / 2 -  buttonSize * .5f, buttonSize, buttonSize);
        var bgTexture = whiteTexture;
        if (PlayerPrefs.GetInt("SelectedCharacter", 0) == 0)
        {
            bgTexture = greenTexture;
        }
        GUI.DrawTexture(buttonPos, bgTexture);
        GUI.DrawTexture(buttonPos, characterButtons[0]);

        if (GUI.Button(buttonPos, "", new GUIStyle()))
        {
            PlayerPrefs.SetInt("SelectedCharacter", 0);
        }

        buttonPos = new Rect(Screen.width / 2, Screen.height / 2 - buttonSize * .5f, buttonSize, buttonSize);
        bgTexture = whiteTexture;
        if (PlayerPrefs.GetInt("SelectedCharacter", 0) == 1)
        {
            bgTexture = greenTexture;
        }
        GUI.DrawTexture(buttonPos, bgTexture);
        GUI.DrawTexture(buttonPos, characterButtons[1]);

        if (GUI.Button(buttonPos, "", new GUIStyle()))
        {
            PlayerPrefs.SetInt("SelectedCharacter", 1);
        }
    }

    private void DrawOptionsButton()
    {
        var buttonPos = new Rect(Screen.width / 2 - buttonSize / 2, Screen.height / 2 + buttonSize * .5f, buttonSize, buttonSize);
        GUI.DrawTexture(buttonPos, optionsTexture);

        if (GUI.Button(buttonPos, "", new GUIStyle()))
        {
            isOptionsOpen = true;
        }
    }

    private void DrawCloseOptionsButton()
    {
        var buttonPos = new Rect(Screen.width / 2 - buttonSize / 2, Screen.height / 2 + buttonSize * .5f, buttonSize, buttonSize);
        GUI.DrawTexture(buttonPos, backTexture);

        if (GUI.Button(buttonPos, "", new GUIStyle()))
        {
            isOptionsOpen = false;
        }
    }

    private void DrawStartButton()
    {
        var buttonPos = new Rect(Screen.width / 2 - buttonSize / 2, Screen.height / 2 - buttonSize * .5f, buttonSize, buttonSize);
        GUI.DrawTexture(buttonPos, playTexture);

        if (GUI.Button(buttonPos, "", new GUIStyle()))
        {
            StartGame();

        }
    }

    private void DrawScoreboardButton()
    {
        var buttonPos = new Rect(Screen.width / 2 - buttonSize / 2, Screen.height / 2 - buttonSize * 1f, buttonSize, buttonSize);
        GUI.DrawTexture(buttonPos, scoreboardTexture);

        if (GUI.Button(buttonPos, "", new GUIStyle()))
        {
            /*PlayerPrefs.SetString("RefererScreen", "StartScreen");
            Application.LoadLevel(2);*/
        }
    }


    private void StartGame()
    {
        Application.LoadLevel(1);
    }

    private GUIStyle GetMyStyle()
    {
        var myStyle = new GUIStyle(GUI.skin.label);
        myStyle.fontSize = 30;
        myStyle.normal.textColor = Color.black;
        //myStyle.font = Arial;
        myStyle.alignment = TextAnchor.MiddleCenter;
        return myStyle;
    }

}
