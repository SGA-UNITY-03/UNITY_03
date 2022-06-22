using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBall : MonoBehaviour
{
    Vector3 _direction = Vector3.forward;
    float _speed = 30.0f;
    float _lifeTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _lifeTime = 0.0f;
    }

    private void OnEnable()
    {
        _lifeTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _lifeTime += Time.deltaTime;

        if (_lifeTime >= 3.0f)
        {
            gameObject.SetActive(false);
        }

        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        _direction = dir;
        transform.localRotation = Quaternion.LookRotation(dir);
    }
}
