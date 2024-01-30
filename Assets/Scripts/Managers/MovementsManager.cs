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

        bool isHorizontal = Mathf.Approximately(offset.y, 0) && !Mathf.Approximately(offset.x, 0);
        bool isVertical = Mathf.Approximately(offset.x, 0) && !Mathf.Approximately(offset.y, 0);
        bool isDiagonal = Mathf.Abs(offset.x) == Mathf.Abs(offset.y);

        return isHorizontal || isVertical || isDiagonal;
    }

    public bool IsRookMovement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - currentPos;

        bool isHorizontal = Mathf.Approximately(offset.y, 0) && !Mathf.Approximately(offset.x, 0);
        bool isVertical = Mathf.Approximately(offset.x, 0) && !Mathf.Approximately(offset.y, 0);

        return isHorizontal || isVertical;
    }

    public bool IsBishopMovement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - currentPos;
        return Mathf.Abs(offset.x) == Mathf.Abs(offset.y);
    }

    public bool IsPawnMovement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - currentPos;
        
        return Mathf.Approximately(offset.x, 0) && Mathf.Approximately(Mathf.Abs(offset.y), 1.0f);
    }

}