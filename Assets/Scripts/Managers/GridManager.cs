using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform camRef;

    private Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        InitializeGrid();
        SpawnTiles();
        PositionCamera();
        GameManager.Instance.ChangeState(GameState.SpawnPlayer);
    }

    private void InitializeGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
    }

    private void SpawnTiles()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                SpawnTile(i, j);
            }
        }
    }

    private void SpawnTile(int i, int j)
    {
        var tileSpawned = Instantiate(tilePrefab, new Vector3(i, j), Quaternion.identity);
        tileSpawned.name = $"Tile {i} {j}";

        var isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
        tileSpawned.GetColor(isOffset);

        _tiles[new Vector2(i, j)] = tileSpawned;
    }

    private void PositionCamera()
    {
        camRef.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
}