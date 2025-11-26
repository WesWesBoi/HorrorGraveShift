using UnityEngine;
using System.Collections.Generic;
public class PatrolNavigation : MonoBehaviour
{
    public List<GameObject> patrolPoints = new List<GameObject>();
    public int currentPoint = 0;
    public float distanceForNextPoint = 2f;
    AINavigationMEsh aiNav;
    bool isPatroling = true;

    private void Start()
    {
        aiNav = GetComponent<AINavigationMEsh>();
        aiNav.SetLocation(patrolPoints[currentPoint].transform.position);
    }

    public void DisablePatrol()
    {
        isPatroling = false;
        aiNav.SetLocation(transform.position);
    }
    public void EnablePatrol()
    {
        isPatroling = true;
        aiNav.SetLocation(patrolPoints[currentPoint].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToPoint = patrolPoints[currentPoint].transform.position - transform.position;
        if(dirToPoint.magnitude <= distanceForNextPoint)
        {
            currentPoint += 1;
            currentPoint = currentPoint % patrolPoints.Count;
            aiNav.SetLocation(patrolPoints[currentPoint].transform.position);
        }
    }
}
