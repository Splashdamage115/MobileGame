using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBake : MonoBehaviour
{
    private NavMeshSurface navMesh;
    void Awake()
    {
        navMesh = GetComponent<NavMeshSurface>();
        navMesh.BuildNavMesh();
    }

}
