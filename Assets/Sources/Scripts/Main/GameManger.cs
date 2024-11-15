using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

// 싱글톤 (singletion) 디자인 패턴을 사용해 정의
// scene 내에서 오직 1개만 존재하게 하는 함수

// 역할 : player를 선택한 street로 이동
// -player 
// 선택한 street
// 현재 street
// 역할: canvas를 통해 이동할수있는 street 표시
// ㄴ forward, back, left, right 
// 이동할수있는 여부를 알 수 있는 street 
//street의 방향을 나타내는 enum 방향집합
public enum Direction{
    forward, back, right, left
}


public class GameManger : MonoBehaviour
{
    //싱글톤 디자인 패턴
    public static GameManger Instance = null;
    
    public GameObject player;
    public Street currentStreet;
    public float adjustRange = 1.5f; // 배율 조절 (1.0f 1배)
    public Button[] navigatorBtns = new Button[4];
    // Start is called before the first frame update

    private void Awake() {
        //만일 instance안의 값이 비어있다면 
        //값을 할당한다.
        if(Instance == null){
            Instance = this;   
        } 
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MappingStreet();
    }

    //player가 어디로 이동할수있는지 
    // - canvas의 화살표 (화설, 비활성)
    // - 내가 이동할수있는 street (현재 street)
    public void MappingStreet(){
        // 현재 street를 기준으로 
        // left street으로 이동할수있다면 arrow 활성화
        if(currentStreet.leftStreet != null){
            ActiveArrow(Direction.left);
        }else{
            DectiveArrow(Direction.left);
        }
        // right street으로 이동할수있다면 arrow 활성화
        if(currentStreet.rightStreet != null){
            ActiveArrow(Direction.right);
        }else{
            DectiveArrow(Direction.right);
        }
        // forward street으로 이동할수있다면 arrow 활성화
        if(currentStreet.forwardStreet != null){
            ActiveArrow(Direction.forward);
        }else{
            DectiveArrow(Direction.forward);

        }
        // back street으로 이동할수있다면 arrow 활성화
        if(currentStreet.backStreet != null){
            ActiveArrow(Direction.back);
        }else{
            DectiveArrow(Direction.back);
        }
    }


    void SetArrowActive(GameObject arrow, Street streetDirection)
    {
        arrow.SetActive(streetDirection != null);
    }

    public void ActiveArrow(Direction dir){
        //0. 방향 direction 
        int index = (int)dir;
        // 버튼이 가지고 잇는 리스너 제거
        navigatorBtns[index].onClick.RemoveAllListeners();
        // Debug.Log($"Active {index}");
        //방향에 맞는 화살표를 활성화
        navigatorBtns[index].gameObject.SetActive(true);
        navigatorBtns[index].onClick.AddListener(() => 
            {
                currentStreet.OnClickNavigatorBtn(dir);
            }
        );
    }

    public void DectiveArrow(Direction dir){
        //방향에 맞는 화살표를 바활성화
        int index = (int)dir;
        //Debug.Log($"DectiveArrow {index}");
        //방향에 맞는 화살표를 활성화
        Button btn = navigatorBtns[index];
        btn.gameObject.SetActive(false);
    }

    public void MovePlayer(Vector3 nextPos){
        //이동할 다음 장소 위치
        //plyer를 다음 장소로이동
        player.transform.position = nextPos;
    }    
}
