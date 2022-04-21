using TMPro;
using UnityEngine;


public class ScoreView : MonoBehaviour
{
    [SerializeField] private PlayerMoney _score;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _score.Replenishment += OnReplenishment;
    }

    private void OnDisable()
    {
        _score.Replenishment -= OnReplenishment;
    }

    private void OnReplenishment(int score)
    {
        _scoreText.text = score.ToString();
    }
}
