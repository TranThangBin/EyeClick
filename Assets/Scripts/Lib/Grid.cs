using System;
using UnityEngine;

public class Grid<TGridObject>
{
    private float _cellWidth;
    private float _cellHeight;
    private TGridObject[,] _gridArray;
    private TextMesh[,] _debugTextArray;
    private Vector2 _originPosition;

    public Grid(int width, int heigth, float cellWidth, float cellHeight, Vector2 originPosition, Func<int, int, TGridObject> createGridObject, bool debug)
    {
        _cellWidth = cellWidth;
        _cellHeight = cellHeight;
        _originPosition = originPosition;
        _debugTextArray = new TextMesh[width, heigth];
        _gridArray = new TGridObject[width, heigth];

        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                _gridArray[x, y] = createGridObject(x, y);
            }
        }

        if (debug)
        {
            for (int x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < _gridArray.GetLength(1); y++)
                {
                    GameObject gameObject = new GameObject("gridCell", typeof(TextMesh));
                    gameObject.transform.SetParent(null, false);
                    gameObject.transform.position = getCellPosition(x, y) + new Vector2(cellWidth, cellHeight) / 2;
                    TextMesh textMesh = gameObject.GetComponent<TextMesh>();
                    textMesh.text = _gridArray[x, y].ToString();
                    textMesh.anchor = TextAnchor.MiddleCenter;
                    _debugTextArray[x, y] = textMesh;
                    Debug.DrawLine(getCellPosition(x, y), getCellPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(getCellPosition(x, y), getCellPosition(x + 1, y), Color.white, 100f);
                }
                Debug.DrawLine(getCellPosition(0, heigth), getCellPosition(width, heigth), Color.white, 100f);
                Debug.DrawLine(getCellPosition(width, 0), getCellPosition(width, heigth), Color.white, 100f);
            }
        }
    }

    private Vector2 getCellPosition(int x, int y)
    {
        return new Vector2(x * _cellWidth, y * _cellHeight) + _originPosition;
    }

    private void getCoordinate(Vector2 position, out int x, out int y)
    {
        x = Mathf.FloorToInt((position - _originPosition).x / _cellWidth);
        y = Mathf.FloorToInt((position - _originPosition).y / _cellHeight);
    }

    public void SetCellValue(int x, int y, TGridObject value)
    {
        if (x < 0 || y < 0 || x >= _gridArray.GetLength(0) || y >= _gridArray.GetLength(1))
        {
            return;
        }
        _gridArray[x, y] = value;
        _debugTextArray[x, y].text = value.ToString();
    }

    public void SetCellValue(Vector2 position, TGridObject value)
    {
        getCoordinate(position, out int x, out int y);
        SetCellValue(x, y, value);
    }

    public TGridObject GetCellValue(int x, int y)
    {
        if (x < 0 || y < 0 || x >= _gridArray.GetLength(0) || y >= _gridArray.GetLength(1))
        {
            return default;
        }
        return _gridArray[x, y];
    }

    public TGridObject GetCellValue(Vector2 position)
    {
        getCoordinate(position, out int x, out int y);
        return GetCellValue(x, y);
    }
}