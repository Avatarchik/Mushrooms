using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    [SerializeField]
    private CanvasGroup _GameOverCanvasGroup;

    [SerializeField]
    private CanvasGroup _PauseCanvasGroup;

    [SerializeField]
    private Text _GameOverTitle;

    [SerializeField]
    private Text _GameOverScore;

    [SerializeField]
    private PlayerController _PlayerController;

    [SerializeField]
    private ScoreController _ScoreController;

    // Use this for initialization
    void Start () {
        _GameOverCanvasGroup.alpha = 0;
        _PauseCanvasGroup.alpha = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (_GameOverCanvasGroup.alpha > 0)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Play();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Exit();
            }
        }

        if(_PauseCanvasGroup.alpha > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPaused(false);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                Play();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetPosition();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Exit();
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPaused(true);
            }
        }
	}

    public void SetPaused(bool paused)
    {
        _PlayerController.enabled = !paused;
        _PauseCanvasGroup.alpha = paused ? 1 : 0;
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void ResetPosition()
    {
        _PlayerController.ResetPosition();
        SetPaused(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GameOver(bool victory)
    {
        _GameOverTitle.text = victory ? "Victory!" : "Game Over";
        _GameOverScore.text = "Score:\n" + _ScoreController.Score;
        _GameOverCanvasGroup.alpha = 1;
    }
}
