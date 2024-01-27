using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Tilemap grid;
    [SerializeField] private int StartEnemyCount = 10;
    
    private List<Vector2> spawnPositions = new List<Vector2>();

    [SerializeField] [Range(0,0.99f)] private float SpawnDelayDecay = 0.01f;
    [SerializeField] private float SpawnDelay = 10f;
    private float SpawnCooldown = 0f;
    private const float minSpawnDelay = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        var bounds = grid.cellBounds;
        for(var x = bounds.min.x; x< bounds.max.x;x++){
            for(var y= bounds.min.y; y< bounds.max.y;y++){
                var cellPos = new Vector3Int(x, y, 0);
                var tile = grid.GetTile(cellPos);
                var empty = tile == null;
                if (empty)
                {
                    spawnPositions.Add(grid.CellToWorld(cellPos));
                }
            }
        }

        for (var i = 0; i< StartEnemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    void FixedUpdate()
    {
        SpawnCooldown -= Time.fixedDeltaTime;
        if (SpawnCooldown <= 0)
        {
            SpawnDelay *= (1f-SpawnDelayDecay);
            SpawnDelay = Mathf.Max(minSpawnDelay, SpawnDelay);
            SpawnCooldown = SpawnDelay;
            SpawnEnemy();
        }
    }


    public void SpawnEnemy()
    {
        var chosen = Mathf.FloorToInt(Random.value * (spawnPositions.Count-1));
        var enemy = GameObject.Instantiate(enemyPrefab);
        enemy.transform.position = spawnPositions[chosen];
    }
}
