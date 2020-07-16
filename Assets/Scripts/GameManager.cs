using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float score;
    private int digCount = 0;

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
    }

    public void AddToScore(float scoreToAdd)
    {
        score += scoreToAdd;
        digCount++;
        OnScoreUpdate?.Invoke(this, EventArgs.Empty);
    }

    public float GetScore() => score;

    private void RunForward_OnDeath(object sender, EventArgs e)
    {
        StartCoroutine(OnDeath());
    }

    private IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(2f);
        ActivateDeathMenu();
    }

    private void ActivateDeathMenu()
    {
        Debug.Log("DEATH MENU");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
