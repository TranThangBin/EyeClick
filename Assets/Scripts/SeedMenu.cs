using UnityEngine;

public class SeedMenu : MonoBehaviour
{
    public Plant[] Plants;

    [SerializeField] private Lawn _lawn;

    private Grid<Plant> _grid;
    private string _selectedPlant;

    private void Start()
    {
        _grid = new Grid<Plant>(Plants.Length, 1, 20, 10, transform.position, (i, _) => Plants[i], true);
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 mouseWorldPostion = Utils.GetMouseWorldPosition();
        //    string selectedPlant = _grid.GetCellValue(mouseWorldPostion);
        //    if (!string.IsNullOrEmpty(selectedPlant))
        //    {
        //        _selectedPlant = selectedPlant;
        //    }
        //    else if (!string.IsNullOrEmpty(_selectedPlant) && _lawn.SetPlant(mouseWorldPostion, _selectedPlant))
        //    {
        //        _selectedPlant = string.Empty;
        //    }
        //}
    }
}
