using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool pause = false;
    public int levelNumber;

    private float timer;
    private const float DefaultTimer = 15;
    public TextMeshProUGUI txtTimer;
    public GameObject PauseMenu;
    public GameObject WinMenu;
    public GameObject LoseMenu;
    public GameObject WinScoreMenu;
    public GameObject LoseScoreMenu;

    public AudioSource music;

    void Start()
    {
        if(levelNumber>0)
        {
            saveGame();
		}

        timer = DefaultTimer;
        GameObject[] joints = GameObject.FindGameObjectsWithTag("joint");
        foreach (GameObject joint in joints)
        {
            int[] degrees = {0, 90, 180, 270};
            int degree = degrees[Random.Range(0,3)];
            joint.transform.Rotate(0, degree, 0);
		}

        InvokeRepeating("SolveCheck", 0.2f, 0.2f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
		}

        if(!pause)
        {
            if(timer<=0)
            {
                //Times up
                pause = true;
                txtTimer.text = "Time: TIMES UP!";

                CancelInvoke();
                music.clip = Resources.Load<AudioClip>("LoseMusic");
                music.Play();
                LoseMenu.SetActive(true);
		    }
            else
            {
                timer -= Time.deltaTime;
                txtTimer.text = "Time: " + timer.ToString("000");
            }
        }
	}

    private void SolveCheck()
    {
        bool isSolved = true;

        GameObject[] touches = GameObject.FindGameObjectsWithTag("touch");
        foreach (GameObject touch in touches)
        {
           if(!touch.GetComponent<ConnectionCheck>().isConnected)
           {
                isSolved = false;  
		   }
		}

        if(isSolved)
        {
            CancelInvoke();

            //Debug.Log("SOLVED - WIN");
             
            music.clip = Resources.Load<AudioClip>("WinMusic");
            music.Play();

            pause = true;
            WinMenu.SetActive(true);

            GameObject[] joints = GameObject.FindGameObjectsWithTag("joint");
            foreach (GameObject joint in joints)
            {
                joint.GetComponentInChildren<Renderer>().materials[0].color = Color.green;
                joint.GetComponentInChildren<Renderer>().materials[1].color = Color.green;
		    }
		}
        else
        {
            //Debug.Log("NOT SOLVED YET");
            pause = false;
		}
	}

    //Buttons
    public void uiResume()
    {
        pause = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
	}

    public void uiMainMenu()
    {
         SceneManager.LoadScene("MainMenu");
         pause = false;
         Time.timeScale = 1f;
         PauseMenu.SetActive(false);

         music.clip = Resources.Load<AudioClip>("MenuMusic");
         music.Play();
	}

    public void uiNextLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void uiExit()
    {
        Application.Quit();
	}

    public void uiWinContinue()
    {
        WinMenu.SetActive(false);
        WinScoreMenu.SetActive(true);
	}

    public void uiLoseContinue()
    {
        LoseMenu.SetActive(false);
        LoseScoreMenu.SetActive(true);
	}

    public void uiReplayLevel1()
    {
        SceneManager.LoadScene("Level01");
	}

    public void uiReplayLevel2()
    {
        SceneManager.LoadScene("Level02");
	}

    public void uiReplayLevel3()
    {
        SceneManager.LoadScene("Level03");
	}

    public void saveGame()
    {
        PlayerPrefs.SetInt("levelNumber",levelNumber);
	}

    public void loadGame()
    {
        levelNumber = PlayerPrefs.GetInt("levelNumber");
        SceneManager.LoadScene(levelNumber);
	}
}
