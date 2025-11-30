using NUnit.Framework;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class HomeScreenNavigation : MonoBehaviour
{
    public Transform patrolPointTransform;
    private Vector3[] patrolPoints;
    private int targetTransform;

    [SerializeField]
    private float pointWaitTime;
    private float waitTimeLeft;
    private bool arrivedAtPoint = false;

    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        patrolPoints = new Vector3[patrolPointTransform.childCount];

        for (int i = 0; i < patrolPointTransform.childCount; i++)
        {
            patrolPoints[i] = patrolPointTransform.GetChild(i).transform.position;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        waitTimeLeft = pointWaitTime;

        setNewPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(arrivedAtPoint)
        {
            checkTimeOut();
        }
        else if(navMeshAgent?.remainingDistance <= 0.1)
        {
            arrivedAtPoint = true;
        }
    }

    void checkTimeOut()
    {
        waitTimeLeft -= Time.deltaTime;
        if (waitTimeLeft <= 0)
        {
            setNewPoint();
        }
    }
    void setNewPoint()
    {
        targetTransform = UnityEngine.Random.Range(0, patrolPoints.Length);
        navMeshAgent.destination = patrolPoints[targetTransform];
        arrivedAtPoint = false;
        waitTimeLeft = pointWaitTime;
    }
}
