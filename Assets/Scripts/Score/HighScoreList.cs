using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HighScoreList : ScriptableObject
{
    public List<HighScoreItem> highScores = new List<HighScoreItem>();
    
    public void UpdateScores(MonoBehaviour component)
    {
        component.StartCoroutine(DownloadHighScores());
    }

    public IEnumerator DownloadHighScores()
    {
        highScores.Clear();
        var result = new AirTable.Result<AirTable.HighScoreRecords>();
        yield return AirTable.GetRecords("High%20Scores", "ByDepth", 10, result);
        var request = result.request;
        if (!request.isNetworkError)
        {
            for (var i = 0; i < result.data.records.Count; i++)
            {
                var newHighScoreItem = new HighScoreItem();
                var record = result.data.records[i];
                newHighScoreItem.rank = i + 1;
                newHighScoreItem.name = record.fields.Name;
                newHighScoreItem.depth = record.fields.Depth;
                newHighScoreItem.time = record.fields.Time;
                highScores.Add(newHighScoreItem);
            }
        }
        else
            Debug.Log(request.error);
    }

    [Serializable]
    public class HighScoreItem
    {
        public int rank;
        public string name;
        public float depth;
        public float time;
    }
}
