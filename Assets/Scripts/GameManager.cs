using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    Credits,
    Lobby,
    Level1,
    Lobby1,
    Lobby2,
    Level2,
    Level3,
    GameOver,
    Win
}

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public Animator anim;
    public float TransitionTime;
    public soundManager soundManager;

    // Declaración del estado del juego
    public GameState currentGameState = GameState.MainMenu;

    public void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
    }
    public void MainMenu()
    {
        soundManager.Instance.backToStart();
        soundManager.Instance.Play(5);
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.MainMenu);
    }
    public void Credits()
    {
        soundManager.Instance.backToStart();
        soundManager.Instance.Play(5);
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.Credits);
    }
    public void Lobby()
    {
        soundManager.Instance.Play(2);
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.Lobby);
    }
    public void Level1()
    {
        soundManager.Instance.Play(6);
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.Level1);
    }
    public void Lobby1()
    {
        soundManager.Instance.Play(6);
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.Lobby1);
   
    }
    public void Lobby2()
    {
        soundManager.Instance.Play(6);
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.Lobby2);
    }
    public void Level2()
    {
        soundManager.Instance.Play(6);
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.Level2);
    }
    public void Level3()
    {
        soundManager.Instance.Play(6);
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.Level3);
    }
    public void GameOver()
    {
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.GameOver);
    }
    public void YouWin()
    {
        Invoke("LoadTrigger", TransitionTime);
        Time.timeScale = 1f;
        SetGameState(GameState.Win);
    }
    public void SetGameState(GameState newGameState)
    {
        this.currentGameState = newGameState;

        if (newGameState == GameState.MainMenu)
        {
            SceneManager.LoadScene("MainMenu");
        }else if (newGameState == GameState.Credits)
        {
            SceneManager.LoadScene("Credits");
        }
        else if (newGameState == GameState.Lobby)
        {
            SceneManager.LoadScene("Lobby");
        }
        else if (newGameState == GameState.Lobby1)
        {
            SceneManager.LoadScene("Lobby1");
        }
        else if (newGameState == GameState.Lobby2)
        {
            SceneManager.LoadScene("Lobby2");
        }
        else if (newGameState == GameState.Level1)
        {
            SceneManager.LoadScene("Level1");
        }
        else if (newGameState == GameState.Level2)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (newGameState == GameState.Level3)
        {
            SceneManager.LoadScene("Level3");
        }
        else if (newGameState == GameState.GameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (newGameState == GameState.Win)
        {
            SceneManager.LoadScene("Win");
        }
    }
    void LoadTrigger()
    {
        anim = GameObject.Find("Crossfade").GetComponent<Animator>();
        anim.SetTrigger("Start");
    }
}
