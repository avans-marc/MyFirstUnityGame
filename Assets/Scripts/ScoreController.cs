using DG.Tweening;
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

        // Scale punch
        this.ScoreTextBox.transform.DOPunchScale(Vector3.one * 0.3f, 0.5f, 10, 1);

        // Color flash
        this.ScoreTextBox
            .DOColor(Color.yellow, 0.2f)
            .OnComplete(() => this.ScoreTextBox.DOColor(Color.red, 0.2f));
    }
}
