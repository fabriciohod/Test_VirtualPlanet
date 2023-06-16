using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void SetText(int time)
    {
        int minutes = time / 60;
        int remainingSeconds = time % 60;

        string formattedTime = $"{minutes}:{remainingSeconds:D2}";

        text.SetText(formattedTime);
    }
}
