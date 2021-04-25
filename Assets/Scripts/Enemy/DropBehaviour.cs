using UnityEngine;

public class DropBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject dropPrefab;

    public void Drop()
    {
        if (!dropPrefab) return;
        var items = GameObject.Find("---- Items ---------------------------------");
        var drop = Instantiate(dropPrefab);
        drop.transform.position = transform.position;
        if (items) drop.transform.SetParent(items.transform);
    }
}
