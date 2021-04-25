using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private TextMeshProUGUI textMesh;

    private float TimeAlive => score ? score.time : 0;
    private float MaxDepth => score ? score.depth : 0;

    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = $"{TimeAlive:0.00000}\n{MaxDepth:0.000000}";
    }
}