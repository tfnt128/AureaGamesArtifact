using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData
{
    public ScriptableUnits scriptableUnit;
    public Vector2 spawnPosition;
    public Tile associatedTile;
}

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }
    public UnitData playerData;
    public List<UnitData> enemiesData;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitializePlayerData();
    }

    private void InitializePlayerData()
    {
        playerData.scriptableUnit.Piece = PieceType.Queen;
    }

    public void SpawnPlayer()
    {
        Vector2 playerPos = playerData.spawnPosition;
        Tile tile = GridManager.Instance.GetTileAtPosition(playerPos);

        if (tile != null)
        {
            InstantiateUnit(playerData.scriptableUnit.charPrefab, tile.transform.position);
            GameManager.Instance.ChangeState(GameState.SpawnEnemies);
        }
        else
        {
            Debug.LogWarning("Player spawn tile not found.");
        }
    }

    public void SpawnEnemies()
    {
        foreach (UnitData enemyData in enemiesData)
        {
            SpawnEnemy(enemyData);
        }
    }

    private void SpawnEnemy(UnitData enemyData)
    {
        Vector2 enemyPos = enemyData.spawnPosition;
        Tile tile = GridManager.Instance.GetTileAtPosition(enemyPos);

        if (tile != null)
        {
            enemyData.associatedTile = tile;
            GameObject enemy = InstantiateUnit(enemyData.scriptableUnit.charPrefab, tile.transform.position);
            tile.SetEnemy(enemy, enemyData.scriptableUnit.Piece);
        }
        else
        {
            Debug.LogWarning("Enemy spawn tile not found.");
        }
    }

    private GameObject InstantiateUnit(GameObject prefab, Vector3 position)
    {
        return Instantiate(prefab, position, Quaternion.identity);
    }
}
