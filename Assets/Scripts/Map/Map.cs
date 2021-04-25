using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Map : ScriptableObject
{
    public int cellsPerUnit = 5;
    public List<Vector2Int> digs = new List<Vector2Int>();

    public void ClearDigs()
    {
        digs.Clear();
    }
    
    public bool HasDigSquare(Vector3 position)
    {
        var coordinates = GetCoordinates(position);
        return digs.Contains(coordinates);
    }

    public Vector2Int Dig(Vector3 position)
    {
        var coordinates = GetCoordinates(position);
        if (!digs.Contains(coordinates))
            digs.Add(coordinates);
        return coordinates;
    }

    private Vector2Int GetCoordinates(Vector3 position)
    {
        // position.x -= 1f / cellsPerUnit / 2f;
        // position.y -= 1f / cellsPerUnit / 2f;
        position *= cellsPerUnit;
        var coordinate = Vector2Int.zero;
        coordinate.x = Mathf.RoundToInt(position.x);
        coordinate.y = Mathf.RoundToInt(position.y);
        return coordinate;
    }
}