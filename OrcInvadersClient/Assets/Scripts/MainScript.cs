using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

    int playerScore = 0;

    float buttonSize;

    public GameObject[] playerObjects;
    public Transform playerPosition;

    private GameObject bulletObj;
    private Transform weaponTransform;
    private Transform shootPosition;

    float bullet_speed = 500f;
    float shootDelay = 0.5f;
    float timerDelay = 0;

    private Plane m_ClickPlane;

    public Texture2D pauseTexture;
    public Texture2D playTexture;
    public Texture2D[] numbersTexture;
    public Texture2D restartTexture;
    public Texture2D soundOnTexture;
    public Texture2D soundOffTexture;
    public Texture2D quitTexture;  

	void Start () {
        m_ClickPlane = new Plane(-Vector3.forward, Vector3.zero);
        int character = PlayerPrefs.GetInt("SelectedCharacter", 0);
        //var playerObjectModel = playerObjects[character];
        var playerObject = (GameObject)Instantiate(playerObjects[character], playerPosition.position, Quaternion.identity);
        var playerScript = playerObject.GetComponent<PlayerObject>();
        bulletObj = playerScript.bulletObj;
        weaponTransform = playerScript.weaponTransform;
        shootPosition = playerScript.shootPosition;
	}

    private bool isGamePaused
    {
        get
        {
            return Time.timeScale == 0.0f;
        }
        set
        {
            Time.timeScale = value ? 0f : 1f;
        }
    }

	void Update () {
        if (isGamePaused)
        {
            return;
        }
        var mouseworldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var bullet_dir = mouseworldpos - weaponTransform.transform.position;
        var angle = (Mathf.Atan2(bullet_dir.y, bullet_dir.x) * Mathf.Rad2Deg) - 90;
        weaponTransform.transform.rotation = Quaternion.Euler(0, 0, angle);
        
        timerDelay += Time.deltaTime;
        if (timerDelay <= shootDelay)
        {
            return; 
        }


        if (Input.GetKey(KeyCode.Mouse0))
        {
            timerDelay = 0;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist;
            if (m_ClickPlane.Raycast(ray, out dist))
            {
                Vector3 dir = (ray.GetPoint(dist) - weaponTransform.transform.position).normalized;
                GameObject fireball = (GameObject)Instantiate(bulletObj, shootPosition.position, weaponTransform.transform.rotation);
                fireball.GetComponent<Rigidbody2D>().AddForce(dir * bullet_speed);//, ForceMode.Impulse);
                
            }  
        }
		
	}

    public void AddScore(int p)
    {
        playerScore += p;
    }

    void OnGUI()
    {
        buttonSize = Screen.height * 0.15f;

        if (isGamePaused)
        {
            GUI.Box(new Rect(-20, -20, Screen.width + 40, Screen.height + 40), "");
        }
        
        var buttonPos = new Rect(0, 0, buttonSize, buttonSize);
        GUI.DrawTexture(buttonPos, isGamePaused? playTexture: pauseTexture);

        if (GUI.Button(buttonPos, "", new GUIStyle()))
        {
            isGamePaused = !isGamePaused;           
        }

        /*GUI.Box(new Rect(0, 0, 100, 30), "Score: " + playerScore);
        if (GUI.Button(new Rect(Screen.width - 100, 0, 100, 40), "Quit"))
        {
            Application.LoadLevel(0);
        }*/
    }



    internal void ReduceScore(int p)
    {
        if (playerScore < p)
        {
            playerScore = 0;
        }
        else
        {
            playerScore -= p;
        }
    }
}
