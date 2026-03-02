using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unityAnimator;

    private Vector3 targetPosition;
    private float moveSpeed = 4f;
    private float rotateSpeed = 10f;
    private float stoppingDistance = 0.1f;
    private GridPosition gridPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            var moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveSpeed * Time.deltaTime * moveDirection;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
            unityAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unityAnimator.SetBool("IsWalking", false);
        }
        
        var newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition) 
        {
            // update unit grid postion and noify grid object
            LevelGrid.Instance.UnitMovedGridPosition(this,gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }

    public override string ToString()
    {
        return gameObject.name;
    }
}
