using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public GameObject BunnyManagerGameObject;
    public TextMeshProUGUI ScoreTextBox;

    private BunnyManager BunnyManagerComponent;

    private int CurrentScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.BunnyManagerComponent = BunnyManagerGameObject.GetComponent<BunnyManager>();
        this.BunnyManagerComponent.OnBunnyExit += UpdateScore;
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        this.CurrentScore++;
        this.ScoreTextBox.text = $"Score: {this.CurrentScore}";
    }
}
