using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI textMesh;

    private float TimeAlive => player ? player.timeAlive ? player.timeAlive.Value : 0 : 0;
    private float MaxDepth => player ? player.maxDepth ? player.maxDepth.Value : 0 : 0;

    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = $"{TimeAlive:0.00000}\n{MaxDepth:0.000000}";
    }
}
