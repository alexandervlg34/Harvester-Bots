using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] private Transform _carryPoint;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private float _distanceToSelect = 1f;

    [SerializeField] private Base _base;

    [SerializeField] private ResourcesGenerator _resourcesGenerator;
    [SerializeField] private ResourceScanner _scanner;

    private UnitStateMachine _stateMachine;
    private StateMachineData _stateMachineData;

    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public Transform CarryPoint => _carryPoint;
    public float DistanceToSelect => _distanceToSelect;

    public GoToTargetState GoToTargetState;
    public SelectResourceState SelectResourceState;
    public ReturnToBaseState ReturnToBaseState;
    public PutResourceState PutResourceState;


    private void Awake()
    {
        _stateMachine = new UnitStateMachine();
        _stateMachineData = new StateMachineData();

        GoToTargetState = new GoToTargetState(this, _stateMachineData, _stateMachine, _scanner);
        SelectResourceState = new SelectResourceState(this, _stateMachineData, _stateMachine);
        ReturnToBaseState = new ReturnToBaseState(this, _stateMachineData, _stateMachine, _base);
        PutResourceState = new PutResourceState(this, _stateMachineData, _stateMachine, _resourcesGenerator);

        _stateMachine.Initialize(GoToTargetState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();

    }
}
