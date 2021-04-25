using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject digPrefab;
    [SerializeField] private int enemyCount = 1;
    [SerializeField] private Vector2 minHoleSize = Vector2.one;
    [SerializeField] private Vector2 maxHoleSize = Vector2.one * 5;

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
        var enemyParent = GameObject.Find("---- Characters ---------------------------");
        for (var i = 0; i < enemyCount; i++)
        {
            var randomX = Random.Range(Left, Right);
            var randomY = Random.Range(Bottom, Top);
            var randomPosition = new Vector3(randomX, randomY, 0);

            randomX = Random.Range(minHoleSize.x, maxHoleSize.x);
            randomY = Random.Range(minHoleSize.y, maxHoleSize.y);
            var randomScale = new Vector3(randomX, randomY, 1);

            var dig = Instantiate(digPrefab);
            dig.transform.position = randomPosition;
            dig.transform.localScale = randomScale;

            var enemy = Instantiate(enemyPrefab);
            enemy.name = enemyPrefab.name;
            enemy.transform.position = randomPosition;
            enemy.transform.SetParent(enemyParent.transform);
            
            yield return new WaitForSeconds(0.5f);
            Destroy(dig);
        }
    }
}
