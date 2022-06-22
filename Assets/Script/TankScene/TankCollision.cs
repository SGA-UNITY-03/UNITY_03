using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollision : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "Ball")
        //    Debug.Log("OnCollision 충돌!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TankBall")
            Debug.Log("OnTrigger 충돌!!");
    }
}
