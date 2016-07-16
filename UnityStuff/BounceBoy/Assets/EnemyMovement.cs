using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 50, 300), transform.position.y, transform.position.z);
    }

}