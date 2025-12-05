using UnityEngine;
using UnityEngine.AI;

public class Pathing : MonoBehaviour
{
    public CharacterData characterData;
    public Transform enemyGoal;

    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = characterData.moveSpeed;

        agent.destination = enemyGoal.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
