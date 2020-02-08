using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Vector3 _offSet;

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.position + _offSet;
    }
}
