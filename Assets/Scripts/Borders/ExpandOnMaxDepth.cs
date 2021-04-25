using UnityEngine;

public class ExpandOnMaxDepth : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private float startingExtent = 15;
    [SerializeField] private float endingExtent = 100;
    [SerializeField] private float currentExtent;
    [SerializeField] private float lowestDepth = 200;

    private float ScoreDepth => score ? score.depth : 0;
    private float Range => endingExtent - startingExtent;
    
    private void Update()
    {
        if (ScoreDepth > lowestDepth)
            currentExtent = Range + startingExtent;
        else
            currentExtent = ScoreDepth / lowestDepth * Range + startingExtent;
        var position = right.transform.position;
        position.x = currentExtent;
        right.transform.position = position;
        position.x = -position.x;
        left.transform.position = position;
    }
}
