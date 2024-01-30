using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData
{
    public ScriptableUnits scriptableUnit;
    public Vector2 spawnPosition;
}

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    public UnitData PlayerData { get; private set; }
    [SerializeField] private List<UnitData> obstaclesData;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayerData.scriptableUnit.Piece = PieceType.Queen;
    }

    public void SpawnPlayer()
    {
        Vector2 playerPos = PlayerData.spawnPosition;
        var tile = GridManager.Instance.GetTileAtPosition(playerPos);
        Instantiate(PlayerData.scriptableUnit.charPrefab, tile.transform.position, Quaternion.identity);
        
        GameManager.Instance.ChangeState(GameState.SpawnObstacles);
    }

    public void SpawnObstacles()
    {
        foreach (UnitData obstacleData in obstaclesData)
        {
            Vector2 obstaclePos = obstacleData.spawnPosition;
            var tile = GridManager.Instance.GetTileAtPosition(obstaclePos);
            Instantiate(obstacleData.scriptableUnit.charPrefab, tile.transform.position, Quaternion.identity);
        }
    }
}