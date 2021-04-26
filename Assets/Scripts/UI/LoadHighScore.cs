using UnityEngine;

public class LoadHighScore : MonoBehaviour
{
    [SerializeField] private HighScoreList _highScoreList;
    [SerializeField] private Score score;

    private void OnEnable()
    {
        score.depth = 0;
        score.time = 0;
        _highScoreList.UpdateScores(this);
    }
}
