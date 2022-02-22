using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public float walkRadius = 1f;
    private int UPDATE_RATE = 300;
    private NavMeshAgent agent;

    private void Start()
    {
        this.agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Random.Range(0, this.UPDATE_RATE) != 0)
            return;
        NavMeshHit hit;
        NavMesh.SamplePosition(Random.insideUnitSphere * this.walkRadius + this.transform.position, out hit, this.walkRadius, 1);
        this.agent.SetDestination(hit.position);
    }
}
