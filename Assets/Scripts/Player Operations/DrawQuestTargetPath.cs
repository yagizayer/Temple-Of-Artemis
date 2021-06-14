using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer), typeof(NavMeshAgent))]
public class DrawQuestTargetPath : MonoBehaviour
{
    [SerializeField] private Material LineMaterial;
    public Transform Target
    {
        get => _target;
        set
        {
            DrawingLine = true;
            _target = value;
        }
    }
    public bool DrawingLine { get => _drawingLine; set => _drawingLine = value; }

    private Transform _target;
    private LineRenderer _line;
    private NavMeshAgent _navMeshAgent;
    private bool _drawingLine = false;

    private void Start()
    {
        if (_navMeshAgent == null) _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_line == null) _line = GetComponent<LineRenderer>();

        _line.startWidth = .2f;
        _line.endWidth = .2f;
        _line.positionCount = 0;
        _line.material = LineMaterial;
    }

    private void DrawPathToTarget(Vector3 target)
    {
        NavMeshPath path = new NavMeshPath();
        Vector3 targetPos = target.Modify(Vector3Values.Y, transform.position.y);
        // if ((targetPos - transform.position).sqrMagnitude < 100) DrawingLine = false;

        
        _navMeshAgent.CalculatePath(targetPos, path);
        _line.positionCount = path.corners.Length;


        int cornerNo = 0;
        foreach (Vector3 corner in path.corners)
        {
            _line.SetPosition(cornerNo++, corner);
        }
    }
    private void FixedUpdate()
    {
        if (DrawingLine)
        {
            _line.enabled = true;
            DrawPathToTarget(Target.position);
        }else{
            _line.enabled = false;
        }
    }
}