using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleRoomElement : MonoBehaviour
{
    [SerializeField] private GameObject elementPrefab;
    [SerializeField] private PatrolRoute patrolRoute;

    private GameObject elementInstance;

    public void Spawn()
    {
        elementInstance = Instantiate(elementPrefab, transform.position, Quaternion.identity);

        // Gambiarra, mas funciona
        if(patrolRoute != null)
        {
            // TODO: Pegar tambem o patrolling state do inimigo rolante (quando tiver)
            elementInstance.GetComponentInChildren<MobileMeleeEnemyPatrollingState>().patrolRoute = patrolRoute;
        }
    }

    public void Despawn()
    {
        Destroy(elementInstance);
    }
}
