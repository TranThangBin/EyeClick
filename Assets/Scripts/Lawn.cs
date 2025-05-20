using UnityEngine;

public class Lawn : MonoBehaviour
{
    private Grid<string> _plants;

    private void Start()
    {
        Camera cam = Camera.main;
        float viewHeight = 2 * cam.orthographicSize;
        float viewWidth = viewHeight * cam.aspect;
        _plants = new Grid<string>(8, 5, viewWidth / 8, 5, transform.position, (_, _) => "", true);
    }

    public bool SetPlant(Vector2 position, string plant)
    {
        _plants.SetCellValue(position, plant);
        return _plants.GetCellValue(position) == plant;
    }
}
