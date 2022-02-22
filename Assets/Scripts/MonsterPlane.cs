using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Vuforia;

public class MonsterPlane : MonoBehaviour
{
    public List<GameObject> monsters;
    public AnchorInputListenerBehaviour inputListener;
    private bool monsterSpawned;

    public void SpawnMonster()
    {
        Vector3 max1 = this.gameObject.GetComponent<Renderer>().bounds.max;
        GameObject gameObject = Object.Instantiate<GameObject>(this.monsters[Random.Range(0, this.monsters.Count)]);
        Vector3 max2 = gameObject.GetComponentInChildren<Renderer>().bounds.max;
        gameObject.transform.position = new Vector3(Random.Range(-max1.x + max2.x, max1.x - max2.x), 0.0f, Random.Range(-max1.z + max2.z, max1.z - max2.z));
        gameObject.transform.SetParent(this.transform);
    }

    public void UpdatePlane()
    {
        this.GetComponent<NavMeshSurface>().RemoveData();
        this.GetComponent<NavMeshSurface>().BuildNavMesh();
        if (this.monsterSpawned)
            return;
        this.SpawnMonster();
        this.monsterSpawned = true;
        Object.Destroy((Object)this.inputListener);
    }
}
