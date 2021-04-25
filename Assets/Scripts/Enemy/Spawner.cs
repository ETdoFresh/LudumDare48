using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Spawner : MonoBehaviour
{
    [FormerlySerializedAs("enemyPrefab")] [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject digPrefab;
    [SerializeField] private int enemyCount = 1;
    [SerializeField] private Vector2 minHoleSize = Vector2.one;
    [SerializeField] private Vector2 maxHoleSize = Vector2.one * 5;
    [SerializeField] private bool digHole;
    [SerializeField] private string parentName = "---- Characters ---------------------------";

    private float Left => transform.position.x - transform.lossyScale.x / 2;
    private float Right => transform.position.x + transform.lossyScale.x / 2;
    private float Bottom => transform.position.y - transform.lossyScale.y / 2;
    private float Top => transform.position.y + transform.lossyScale.y / 2;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var parent = GameObject.Find(parentName);
        for (var i = 0; i < enemyCount; i++)
        {
            var randomX = Random.Range(Left, Right);
            var randomY = Random.Range(Bottom, Top);
            var randomPosition = new Vector3(randomX, randomY, 0);

            randomX = Random.Range(minHoleSize.x, maxHoleSize.x);
            randomY = Random.Range(minHoleSize.y, maxHoleSize.y);
            var randomScale = new Vector3(randomX, randomY, 1);

            var instance = Instantiate(prefab);
            instance.name = prefab.name;
            instance.transform.position = randomPosition;
            instance.transform.SetParent(parent.transform);

            if (!digHole) continue;
            var dig = Instantiate(digPrefab);
            dig.transform.position = randomPosition;
            dig.transform.localScale = randomScale;

            yield return new WaitForSeconds(0.5f);
            Destroy(dig);
        }
    }
}
