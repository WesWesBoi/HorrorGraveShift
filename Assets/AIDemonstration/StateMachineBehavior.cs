using UnityEngine;

public enum EnemyState
{
    Patrol,
    Chase,
    Attack
}

public class StateMachineBehavior : MonoBehaviour
{
    EnemyState currentState = EnemyState.Patrol;
    public GameObject player;
    LineOfSight los;
    AINavigationMEsh ai;
    PatrolNavigation patrolNav;
    public float attackRange = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        los = GetComponent<LineOfSight>();
        ai = GetComponent<AINavigationMEsh>();
        patrolNav = GetComponent<PatrolNavigation>();
    }

    public void SetIntensity(float value)
    {
        los.SetInsensity(value);
        ai.SetSpeed(value * 10 + 5);

    }

    // Update is called once per frame
    void Update()
    {
        bool seenPlayer = los.CheckRay().Contains(player);
        Vector3 dirToPlayer = player.transform.position - transform.position;

        switch(currentState)
        {
            case EnemyState.Patrol:
                // run
                if(seenPlayer)
                {
                    currentState = EnemyState.Chase;
                    patrolNav.DisablePatrol();
                }
                break;
            case EnemyState.Chase:
                // run
                ai.SetLocation(player.transform.position);

                if (!seenPlayer)
                {
                    currentState = EnemyState.Patrol;
                    patrolNav.EnablePatrol();
                }

                if(dirToPlayer.magnitude <= attackRange)
                {
                    currentState = EnemyState.Attack;
                }

                break;
            case EnemyState.Attack:
                Debug.Log("attackign");
                if (dirToPlayer.magnitude >= attackRange)
                {
                    currentState = EnemyState.Chase;
                }
                // run
                break;
        }
    }
}
