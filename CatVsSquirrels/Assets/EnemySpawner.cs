using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Tilemap grid;
    [SerializeField] private int StartEnemyCount = 10;
    [SerializeField] private int MaxEnemyCount = 100;


    private List<GameObject> Enemies = new List<GameObject>();
    
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
            for(var y= bounds.min.y+2; y< bounds.max.y-2;y++){
                var cellPos = new Vector3Int(x, y, 0);
                var tile = grid.GetTile(cellPos);
                var tileBelow = grid.GetTile(cellPos + new Vector3Int(0, -1, 0));
                var tileBelowBelow = grid.GetTile(cellPos + new Vector3Int(0, -2, 0));
                if (tile == null && tileBelow == null && tileBelowBelow != null)
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
        if (Enemies.Count >= MaxEnemyCount)
        {
            return;
        }
        var chosen = Mathf.FloorToInt(Random.value * (spawnPositions.Count-1));
        var enemy = GameObject.Instantiate(enemyPrefab);
        enemy.transform.position = spawnPositions[chosen];
        Enemies.Add(enemy);
        enemy.GetComponent<HealthComponent>().onDead += () => RemoveEnemy(enemy);
    }

    private void RemoveEnemy(GameObject enemy)
    {
        this.Enemies.Remove(enemy);
    }
}
