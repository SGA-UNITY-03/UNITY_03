using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    enum CameraState
    {
        TOPVIEW,
        FPS,
        TPS
    }

    public GameObject _player;
    public Vector3 _pos;

    [SerializeField]
    CameraState _cameraState = CameraState.TOPVIEW;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        transform.position = _player.transform.position + _pos;
        transform.LookAt(_player.transform);

        LayerMask layerMask = LayerMask.GetMask("Wall");
        RaycastHit hit;
        if (Physics.Raycast(_player.transform.position, _pos, out hit, _pos.magnitude, layerMask))
        {
            Vector3 dir = hit.point - _player.transform.position;
            transform.position = _player.transform.position + dir * 0.85f;
            transform.position += new Vector3(0, 0.7f, 0);
        }
    }
}
