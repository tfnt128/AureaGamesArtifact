using UnityEngine;

public class MovementsManager : MonoBehaviour
{
    public static MovementsManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public bool IsQueenMovement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - currentPos;
        return IsStraightMovement(offset) || IsDiagonalMovement(offset);
    }

    public bool IsRookMovement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - currentPos;
        return IsStraightMovement(offset);
    }

    public bool IsBishopMovement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - currentPos;
        return IsDiagonalMovement(offset);
    }

    public bool IsPawnMovement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - currentPos;
        return Mathf.Approximately(offset.x, 0) && Mathf.Approximately(Mathf.Abs(offset.y), 1.0f);
    }

    public bool IsKnightMovement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - currentPos;
        
        return (Mathf.Abs(offset.x) == 1 && Mathf.Abs(offset.y) == 2) || 
               (Mathf.Abs(offset.x) == 2 && Mathf.Abs(offset.y) == 1);
    }

    private bool IsStraightMovement(Vector3 offset)
    {
        return Mathf.Approximately(offset.y, 0) || Mathf.Approximately(offset.x, 0);
    }

    private bool IsDiagonalMovement(Vector3 offset)
    {
        return Mathf.Abs(offset.x) == Mathf.Abs(offset.y);
    }
}