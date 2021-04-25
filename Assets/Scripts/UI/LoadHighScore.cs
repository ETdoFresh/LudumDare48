using UnityEngine;

public class LoadHighScore : MonoBehaviour
{
    [SerializeField] private HighScoreList _highScoreList;

    private void OnEnable()
    {
        _highScoreList.UpdateScores(this);
    }
}
