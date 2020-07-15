using System;
using System.Collections;
using UnityEngine;

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

    public void AddToScore(float scoreToAdd)
    {
        Debug.Log(scoreToAdd);
        score += scoreToAdd;
        digCount++;
        OnScoreUpdate?.Invoke(this, EventArgs.Empty);
    }

    public float GetScore() => score;

    public void OnDeath()
    {

    }
}
