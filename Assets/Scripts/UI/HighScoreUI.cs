using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private HighScoreList highScoreList;
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> depths;
    [SerializeField] private List<TextMeshProUGUI> times;

    private void Update()
    {
        if (highScoreList.highScores.Count <= 0) return;
        for (var i = 0; i < names.Count; i++)
            names[i].text = highScoreList.highScores[i].name;
        
        for (var i = 0; i < depths.Count; i++)
            depths[i].text = highScoreList.highScores[i].depth.ToString("0.000");
        
        for (var i = 0; i < times.Count; i++)
            times[i].text = highScoreList.highScores[i].time.ToString("0.000");
    }
}
