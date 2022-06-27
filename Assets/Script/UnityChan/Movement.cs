using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    private float _springArm = 8.0f;
    Vector3 rayHitPostion = Vector3.zero;

    Vector3 mineToCamera = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        mineToCamera = Camera.main.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        Move2();
        CameraMove();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            this.GetComponent<Transform>().rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
    }

    private void CameraMove()
    {

        mineToCamera.Normalize();

        Camera.main.transform.position = transform.position + mineToCamera * _springArm;
    }

    private void Move2()
    {
        // ī�޶���� Plaen�� ������ ���� ó�� �΋H���� ��ġ ã��
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red);

            RaycastHit hit;

            LayerMask layerMask = LayerMask.GetMask("Plane");

            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                rayHitPostion = hit.point;
                Debug.Log(hit.transform.name);
            }
        }

        // ĳ���ͷ� ���� ������ ����Ʈ ��ġ�� ���� => ���������� ���������� ��ġ������ ����
        rayHitPostion.y = transform.position.y; // y�� ���� ĳ������ y���� ��ġ
        Vector3 directionToHit = rayHitPostion - transform.position; // ����
        Vector3 dir = directionToHit.normalized; // ���������� ���� ����

        if (directionToHit.magnitude < 0.01f)
            return;

        transform.position += dir * _speed * Time.deltaTime;

        transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5.0f * Time.deltaTime);
    }
}
