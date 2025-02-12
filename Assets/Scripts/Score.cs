using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;

    private int _goldAmount = 0;
    private int _silverAmount = 0;

    public void UpdateGoldScore()
    {
        _goldAmount++;
        _scoreView.UpdateGoldAmountView(_goldAmount);
    }

    public void UpdateSilverScore()
    {
        _silverAmount++;
        _scoreView?.UpdateSilverAmountView(_silverAmount);
    }
}
