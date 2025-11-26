using UnityEngine;
using UnityEngine.AI;

public class AINavigationMEsh : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetLocation(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
