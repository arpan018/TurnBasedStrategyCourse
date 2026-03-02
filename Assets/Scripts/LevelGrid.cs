using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }


    [SerializeField] private Transform gridVisualPrefab;
    private GridSystem gridSystem;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"More than one LevelGrid", transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gridSystem = new(10, 10, 2);
        gridSystem.CreateGridObjects(gridVisualPrefab);

    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        var gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
    {
        var gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        var gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit);

        AddUnitAtGridPosition(toGridPosition, unit);
    }


    public GridPosition GetGridPosition(Vector3 worldPos) => gridSystem.GetGridPosition(worldPos);
}
