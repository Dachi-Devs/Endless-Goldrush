using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;

    public event EventHandler OnScoreUpdate;

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        FindObjectOfType<RunForward>().OnDeath += RunForward_OnDeath;

        if (!PlayerPrefs.HasKey("TotalScore"))
            PlayerPrefs.SetInt("TotalScore", 0);
        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);
        if (!PlayerPrefs.HasKey("TotalMined"))
            PlayerPrefs.SetInt("TotalMined", 0);
    }

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
        PlayerPrefs.SetInt("TotalMined", PlayerPrefs.GetInt("TotalMined") + 1);
        OnScoreUpdate?.Invoke(this, EventArgs.Empty);
    }

    public int GetScore() => score;

    private void RunForward_OnDeath(object sender, EventArgs e)
    {
        StartCoroutine(OnDeath());
    }

    private IEnumerator OnDeath()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore") + score);
        yield return new WaitForSeconds(2f);
        ActivateDeathMenu();
    }

    private void ActivateDeathMenu()
    {
        Debug.Log("DEATH MENU");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
