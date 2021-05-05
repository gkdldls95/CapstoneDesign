using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class is_GManager : MonoBehaviour
{
    
    public static is_GManager gm;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    
    public enum GameState
    {
        Ready,
        Run,
        GameOver
    }

    
    public GameState gState;

    // 게임 상태 UI 오브젝트 변수
    public GameObject gameLabel;

    // 게임 상태 UI 텍스트 컴포넌트 변수
    Text gameText;

    // PlayerMove 클래스 변수
    PlayerMove player;

    void Start() //크게 보면 1.gState 2.gameLabel 3.gameText
    {
        // 준비상태
        gState = GameState.Ready;

        // 게임 상태 UI 오브젝트에서 Text 컴포넌트를 가져온다.
        gameText = gameLabel.GetComponent<Text>();

        // "준비 텍스트 출력"
        gameText.text = "준비!";

        // 텍스트 색 조절
        gameText.color = new Color32(153, 255, 0, 153); //글자 색 변경 가능

        // 게임 상태 준비에서 Run으로 바꿈
        StartCoroutine(ReadyToStart());

        
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    IEnumerator ReadyToStart()
    {
        // 2초간 준비상태 유지
        yield return new WaitForSeconds(2f);

        // 이후 시작 텍스트 출력
        gameText.text = "시작!";

        
        yield return new WaitForSeconds(0.5f);

        // 상태 텍스트를 비활성화
        gameLabel.SetActive(false);

        // 게임 시작
        gState = GameState.Run;
    }

    void Update()
    {
        //만약 hp가 0보다 작다면
        if (player.hp <= 0)
        {
           
            gameLabel.SetActive(true);

            //게임종료 텍스트를 출력
            gameText.text = "게임 종료";

           
            gameText.color = new Color32(255, 0, 0, 255);

            
            gState = GameState.GameOver;
        }
    }


}
