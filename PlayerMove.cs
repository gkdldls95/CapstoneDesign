using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //이동 속도 변수
    public float moveSpeed = 7f;


    //캐릭터 컨트롤로 변수(이동시에 중력을 적용하기 위해)
    CharacterController cc;

    //중력변수
    float gravity = -20f;

    //수직 속력변수
    public float yVelocity = 0;

    //점프력 변수
    public float jumpPower = 10f;

    //점프 상태 변수(중복 점프를 방지 하기 위해)
    public bool isJumping = false;

   void Start()
    {
        //캐릭터 콘트롤러 컴포넌트 받아오기
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //W A S D 키를 누르면 입력하면 캐릭터를 그 방향으로 이동시키고 싶다.
        //스페이스바 키를 누르면 캐릭터를 수직으로 점프시키고 싶다.

        //사용자의 입력을 받는다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //이동 방향을 설정한다.
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //메인 카메라를 기준으로 방향을 변환한다.(절대좌표를 상대좌표로 바꾸기 위해)
        dir = Camera.main.transform.TransformDirection(dir);

        //만일, 점프 중이었고, 다시 바닥에 착지했다면...
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            //점프 전 상태로 초기화한다. (중복 점프 방지)
            isJumping = false;
            //캐릭터 수직 속도를 0으로 만든다.
            yVelocity = 0;
        }

        //만일, 키보드 spacebar 키를 입력했고, 점프를 하지 않은 상태라면..
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            //캐릭터 수직 속도에 점프력을 적용하고 점프 상태로 변경한다.
            yVelocity = jumpPower;
            isJumping = true;
        }

        //캐릭터 수직 속도에 중력 값을 적용한다.
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;


        //이동 속도에 맞춰 이동한다.
        cc.Move(dir * moveSpeed * Time.deltaTime);
        
    }
}