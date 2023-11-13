using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AITest : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _position;
    public Vector3 Position { get => _position; set => _position = value; }
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        //_position=transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_position);

    }
}
