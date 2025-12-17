using UnityEngine;
using UnityEngine.AI;


public class GameManager : MonoBehaviour
{
    public Camera Cam;
    public NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 pos = hitInfo.point;
                pos = new Vector3(pos.x, 0, pos.z);
                agent.transform.position = pos;
            }
        }
    }
}
