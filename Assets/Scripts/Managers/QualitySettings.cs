﻿using UnityEngine;

public class QualitySettings : MonoBehaviour
{
    [SerializeField]
    private int frameRate;

    [SerializeField]
    private Vector2 targetResolution;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frameRate;
        if (targetResolution != Vector2.zero)
            Screen.SetResolution((int)targetResolution.x, (int)targetResolution.y, true);
    }
}
