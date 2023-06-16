using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    void OnEnable() => GameManager.OnScoreChange += UpdateScore;

    void OnDisable() => GameManager.OnScoreChange -= UpdateScore;

    private void UpdateScore(int value) => text.SetText(value.ToString());
}
