using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class is_Billboard : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        //적의 HpBar를 메인카메라의 위치와 일치
        transform.forward = target.forward;
    }
}
