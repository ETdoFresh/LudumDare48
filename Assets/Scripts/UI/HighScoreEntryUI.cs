using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreEntryUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private HighScoreList highScoreList;
    [SerializeField] private Score score;

    public void SetHighScore()
    {
        StartCoroutine(SetHighScoreCoroutine());
    }
    
    private IEnumerator SetHighScoreCoroutine()
    {
        if (string.IsNullOrEmpty(inputField.text)) yield break;
        var record = new AirTable.HighScoreRecords
        {
            records = new List<AirTable.HighScoreRecords.HighScoreRecord>
            {
                new AirTable.HighScoreRecords.HighScoreRecord
                {
                    fields = new AirTable.HighScoreRecords.HighScoreRecord.HighScores
                    {
                        Name = inputField.text,
                        Depth = score.depth,
                        Time = score.time,
                    }
                }
            }
        };
        yield return AirTable.CreateRecord("High%20Scores", record);
        yield return highScoreList.DownloadHighScores();
        gameObject.SetActive(false);
    }
}