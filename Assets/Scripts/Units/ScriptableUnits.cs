using UnityEngine;

[CreateAssetMenu(fileName = "Create New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnits : ScriptableObject
{
    public PieceType Piece;
    public GameObject charPrefab;
}

public enum PieceType
{
    Queen = 0,
    Pawn = 1,
    Bishop = 2,
    Rook = 3,
    Knight = 4,
    Empty = 5
    
}