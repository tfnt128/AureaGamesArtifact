using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _width, _height;
    
    
    [SerializeField] private Tile _tilePrefab;
    

    [SerializeField] private Transform _camRef;

    private Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        Instance = this;
    }
    

    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                var tileSpawned = Instantiate(_tilePrefab, new Vector3(i, j), quaternion.identity);
                tileSpawned.name = $"Tile {i} {j}";

                var isOffSet = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
                tileSpawned.GetColor(isOffSet);

                _tiles[new Vector2(i, j)] = tileSpawned;
            }
        }

        _camRef.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
        
        GameManager.Instance.ChangeState(GameState.SpawnPlayer);
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
