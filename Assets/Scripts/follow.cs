using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.LookAt(target);
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > 5)
        {
            transform.position += direction * Time.deltaTime * 0.5f;
        }
        //nav.SetDestination(target.position);
    }
}
