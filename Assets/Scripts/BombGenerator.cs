using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] Transform pos1, pos2;
    [SerializeField] float speed;
    [SerializeField] Transform startPos;
    [SerializeField] private float lookRadius = 10f;
    private int checkTime;

    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] Transform parent;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.GetComponent<Rigidbody>().position, transform.position);

        if (distance < lookRadius)
        {

            if (transform.position == pos1.position)
            {
                nextPos = pos2.position;
            }

            if (transform.position == pos2.position)
            {
                nextPos = pos1.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }

        if (Time.time > checkTime)
        {
            checkTime += 2;

            Instantiate(objectToBeSpawned, transform.position, Quaternion.identity, parent);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
