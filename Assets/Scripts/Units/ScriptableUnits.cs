using UnityEngine;

[CreateAssetMenu(fileName = "Create New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnits : ScriptableObject
{
    public Character characterType;
    public PieceType initialPiece;
    public GameObject charPrefab;
}

public enum Character
{
    Player = 0,
    Obstacle = 1
}

public enum PieceType
{
    Queen = 0,
    Pawn = 1,
    Bishop = 2,
    Rook = 3
    
}