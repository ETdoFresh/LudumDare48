using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class BreakApartChunk : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private Transform groundParent;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private Transform chunkTransform;
    [SerializeField] private Vector2 sizeThreshold;

    private Vector2 Size => Vector2.Scale(chunkTransform.lossyScale, boxCollider2D.size);
    private Vector2 Center => (Vector2) chunkTransform.position + boxCollider2D.offset;
    private float ChunkTop => Center.y + Size.y / 2;
    private float ChunkBottom => Center.y - Size.y / 2;
    private float ChunkLeft => Center.x - Size.x / 2;
    private float ChunkRight => Center.x + Size.x / 2;

    private void Awake()
    {
        chunkTransform = transform.parent;
        boxCollider2D = GetComponent<BoxCollider2D>();
        groundParent = chunkTransform.parent;
        
        if (Size.x < sizeThreshold.x) Destroy(chunkTransform.gameObject);
        else if (Size.y < sizeThreshold.y) Destroy(chunkTransform.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var digTrigger = other.GetComponent<DigTrigger>();
        if (!digTrigger) return;
        BreakApart(digTrigger);
        digTrigger.Disable();
    }

    // Assumptions: Always from top and will break in 2-3 pieces [left, right, bottom] [ie no top piece]
    private void BreakApart(DigTrigger digTrigger)
    {
        var leftChunk = ComputeLeftChunk(digTrigger);
        var rightChunk = CreateRightChunk(digTrigger);
        var bottomChunk = CreateBottomChunk(digTrigger);
        var topChunk = CreateTopChunk(digTrigger);
        Destroy(chunkTransform.gameObject);
    }

    private GameObject ComputeLeftChunk(DigTrigger dig)
    {
        var deltaX = dig.Left - ChunkLeft;
        if (deltaX <= 0) return null;
        var deltaY = ChunkTop - dig.Bottom;
        var scaleX = deltaX;
        var scaleY = deltaY < 0 ? Size.y : deltaY > Size.y ? Size.y : deltaY;
        var positionX = ChunkLeft + scaleX / 2;
        var positionY = ChunkTop - scaleY / 2;
        var newChunk = Instantiate(chunkPrefab, groundParent);
        newChunk.transform.localScale = new Vector3(scaleX, scaleY, 1);
        newChunk.transform.position = new Vector3(positionX, positionY, 0);
        newChunk.name = "ChunkLeft" + (int.Parse(Regex.Replace(chunkTransform.name, @"[A-Za-z]", "")) + 1);
        return newChunk;
    }

    private GameObject CreateRightChunk(DigTrigger dig)
    {
        var deltaX = ChunkRight - dig.Right;
        if (deltaX <= 0) return null;
        var deltaY = ChunkTop - dig.Bottom;
        var scaleX = deltaX;
        var scaleY = deltaY < 0 ? Size.y : deltaY > Size.y ? Size.y : deltaY;
        var positionX = ChunkRight - scaleX / 2;
        var positionY = ChunkTop - scaleY / 2;
        var newChunk = Instantiate(chunkPrefab, groundParent);
        newChunk.transform.localScale = new Vector3(scaleX, scaleY, 1);
        newChunk.transform.position = new Vector3(positionX, positionY, 0);
        newChunk.name = "ChunkRight" + (int.Parse(Regex.Replace(chunkTransform.name, @"[A-Za-z]", "")) + 1);
        return newChunk;
    }

    private GameObject CreateBottomChunk(DigTrigger dig)
    {
        if (dig.Bottom <= ChunkBottom) return null;
        var scaleX = Size.x;
        var delta = ChunkTop - dig.Bottom;
        var scaleY = Size.y - delta;
        var positionX = Center.x;
        var positionY = Center.y - delta / 2;
        var newChunk = Instantiate(chunkPrefab, groundParent);
        newChunk.transform.localScale = new Vector3(scaleX, scaleY, 1);
        newChunk.transform.position = new Vector3(positionX, positionY, 0);
        newChunk.name = "ChunkBottom" + (int.Parse(Regex.Replace(chunkTransform.name, @"[A-Za-z]", "")) + 1);
        return newChunk;
    }
    
    private GameObject CreateTopChunk(DigTrigger dig)
    {
        if (dig.Top >= ChunkTop) return null;
        var scaleX = Size.x;
        var delta = dig.Top - ChunkBottom;
        var scaleY = Size.y - delta;
        var positionX = Center.x;
        var positionY = Center.y + delta / 2;
        var newChunk = Instantiate(chunkPrefab, groundParent);
        newChunk.transform.localScale = new Vector3(scaleX, scaleY, 1);
        newChunk.transform.position = new Vector3(positionX, positionY, 0);
        newChunk.name = "ChunkBottom" + (int.Parse(Regex.Replace(chunkTransform.name, @"[A-Za-z]", "")) + 1);
        return newChunk;
    }
}