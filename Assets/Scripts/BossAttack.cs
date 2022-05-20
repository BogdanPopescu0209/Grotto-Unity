using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float lookRadius = 10f;
    [SerializeField] Transform pos1, pos2;
    [SerializeField] float speed;
    [SerializeField] Transform startPos;
    [SerializeField] private Camera getCamera;
    private int bossLife = 100;
    [SerializeField] private YouWin youWin;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
        transform.Rotate(0.0f, 180.0f, 0.0f);
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
                transform.Rotate(0.0f, -180.0f, 0.0f);
            }

            if (transform.position == pos2.position)
            {
                nextPos = pos1.position;
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }

        if (distance > lookRadius)
        {
            transform.position = pos1.position;
        }

        if(bossLife == 0)
        {
            youWin.Setup();
            getCamera.depth = 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            SoundManager.PlaySound("Explode");
            int newLife = bossLife - 20;
            Destroy(collision.gameObject);
            bossLife = newLife;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}