using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScanner : MonoBehaviour
{
    [SerializeField] private float _scanRadius = 1000f;
    [SerializeField] private LayerMask _resourceLayer;

    [SerializeField] private Unit _unit;

    [SerializeField] private Resource _targetResource;

    [SerializeField] private NewUnitState _currentUnitState;

    public Resource TargetResource => _targetResource;


    private void Update()
    {
        Scan();
    }

    private void Scan()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _scanRadius, _resourceLayer);

        float minDistance = Mathf.Infinity;
        Resource closestResource = null;

        for (int i = 0; i < colliders.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, colliders[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestResource = colliders[i].GetComponent<Resource>();
            }
        }

        _targetResource = closestResource;
        _unit.SetState(NewUnitState.GoToTarget);
    }
}
