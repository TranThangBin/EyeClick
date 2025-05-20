using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector2 GetMouseWorldPosition()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mouseWorldPosition;
    }
}