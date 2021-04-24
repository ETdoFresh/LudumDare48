using System;
using UnityEngine;

public class DigTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;

    private Vector2 Size => Vector2.Scale(transform.lossyScale, boxCollider2D.size);
    private Vector2 Center => (Vector2)transform.position + boxCollider2D.offset;
    
    public float Top => Center.y + Size.y / 2;
    public float Bottom => Center.y - Size.y / 2;
    public float Left => Center.x - Size.x / 2;
    public float Right => Center.x + Size.x / 2;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public GameObject CreateNewActiveDigInstance(Vector3 spawnPosition, Vector3 scale)
    {
        var digInstance = Instantiate(gameObject, spawnPosition, Quaternion.identity);
        digInstance.transform.localScale = scale;
        digInstance.SetActive(true);
        return digInstance;
    }
    
    public void Disable()
    {
        boxCollider2D.enabled = false;
    }
}