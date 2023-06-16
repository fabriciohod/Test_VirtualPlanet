using System.Collections;
using TMPro;
using UnityEngine;

public class ShowStats : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text total;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(.3f);
        Time.timeScale = 0;
    }

    void OnEnable()
    {
        score.SetText(GameManager.Instance.Score.ToString());
        total.SetText(GameManager.Instance.Total.ToString());
    }
}
