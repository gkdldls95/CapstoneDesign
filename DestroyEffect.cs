using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    //일정 시간이 지난 뒤 이펙트를 사라지게 하는 스크립트

    //제거될 시간 변수 (1.5초)

    public float destroyTime = 1.5f;

    //경과 시간 측정용 변수
    float currentTime = 0;
    void Update()
    {
        //만약 경과된 시간이 제거될 시간을 초과하면 자기 자신을 제거한다.(즉 1.6초가 되는 순간 자기 자신을 제거)
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }

        currentTime += Time.deltaTime;
    }
}