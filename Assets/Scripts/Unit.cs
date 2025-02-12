using UnityEngine;
using UnityEngine.AI;

public enum NewUnitState
{
    Idle,
    GoToTarget,
    SelectResource,
    ReturnToBase,
    PutResource
}

public class Unit : MonoBehaviour
{
    [SerializeField] private Transform _carryPoint;
    [SerializeField] private float _scanRadius = 100f;
    [SerializeField] private LayerMask _resourceLayer;

    [SerializeField] private NewUnitState _currentUnitState;

    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private float _distanceToSelect = 1f;

    [SerializeField] private Resource _targetResource;
    [SerializeField] private Base _base;

    [SerializeField] private ResourcesGenerator _resourcesGenerator;

    private void Start()
    {
        SetState(NewUnitState.GoToTarget);
    }

    private void Update()
    {
        if (_currentUnitState == NewUnitState.Idle)
        {
            FindClosestResource();
        }

        else if (_currentUnitState == NewUnitState.GoToTarget)
        {
            FindClosestResource();

            if (_targetResource)
            {
                _navMeshAgent.SetDestination(_targetResource.transform.position);

                float distance = Vector3.Distance(transform.position, _targetResource.transform.position);

                if (distance < _distanceToSelect)
                {
                    SetState(NewUnitState.SelectResource);
                }
            }
        }

        else if (_currentUnitState == NewUnitState.SelectResource)
        {
            TakeResource(_targetResource);
            SetState(NewUnitState.ReturnToBase);
        }

        else if (_currentUnitState == NewUnitState.ReturnToBase)
        {
            _navMeshAgent.SetDestination(_base.transform.position);

            float distance = Vector3.Distance(transform.position, _base.transform.position);

            if (distance < 5)
            {
                SetState(NewUnitState.PutResource);
            }
        }

        else if (_currentUnitState == NewUnitState.PutResource)
        {
            DropResource(_targetResource);

            _resourcesGenerator.Destroy(_targetResource);

            SetState(NewUnitState.GoToTarget);
        }
    }

    public void FindClosestResource()
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
        SetState(NewUnitState.GoToTarget);
    }

    public void SetState(NewUnitState unitState)
    {
        _currentUnitState = unitState;
    }

    private void TakeResource(Resource resource)
    {
        resource.transform.SetParent(_carryPoint);
        resource.transform.localPosition = Vector3.zero;
    }

    private void DropResource(Resource resource)
    {
        resource.transform.SetParent(null);
    }
}
