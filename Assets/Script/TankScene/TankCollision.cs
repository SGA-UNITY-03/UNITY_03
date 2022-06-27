using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollision : MonoBehaviour
{
    // Start is called before the first frame update

    TankBall _ball;

    [SerializeField]
    private float _hp = 100.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0.0f)
            gameObject.SetActive(false);

        Collider[] cols = Physics.OverlapSphere(transform.position, 10.0f);

        foreach (Collider col in cols)
        {
            if (col.tag == "Tank")
            {
                Debug.LogError("찾았다!");
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "Ball")
        //    Debug.Log("OnCollision 충돌!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TankBall")
        {
            other.gameObject.SetActive(false);
            _ball = other.gameObject.GetComponent<TankBall>();
            float attackDamage = _ball.ballinfo._attackDamage;
            _hp -= 10.0f;
        }
    }
}
