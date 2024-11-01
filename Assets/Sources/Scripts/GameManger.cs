using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 역할 : player를 선택한 street로 이동
// -player 
// 선택한 street
// 현재 street
// 역할: canvas를 통해 이동할수있는 street 표시
// ㄴ forward, back, left, right 
// 이동할수있는 여부를 알 수 있는 street 
public class GameManger : MonoBehaviour
{
    public GameObject player;
    public Street slectedStreet;
    public Street currentStreet;
    public GameObject arrowForward, arrowBack ,arrowLeft,arrowRight;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DisplayNavigator();
    }

    //player가 어디로 이동할수있는지 
    // - canvas의 화살표 (화설, 비활성)
    // - 내가 이동할수있는 street (현재 street)
    public void DisplayNavigator(){
        // 현재 street를 기준으로 
        // left street으로 이동할수있다면 arrow 활성화
        if(currentStreet.leftStreet != null){
            arrowLeft.SetActive(true);
        }else{
            arrowLeft.SetActive(false);
        }
        // right street으로 이동할수있다면 arrow 활성화
        if(currentStreet.rightStreet != null){
            arrowRight.SetActive(true);
        }else{
            arrowRight.SetActive(false);
        }
        // forward street으로 이동할수있다면 arrow 활성화
        if(currentStreet.forwardStreet != null){
            arrowForward.SetActive(true);
        }else{
            arrowForward.SetActive(false);
        }
        // back street으로 이동할수있다면 arrow 활성화
        if(currentStreet.backStreet != null){
            arrowBack.SetActive(true);
        }else{
            arrowBack.SetActive(false);
        }
    }

    void SetArrowActive(GameObject arrow, Street streetDirection)
    {
        arrow.SetActive(streetDirection != null);
    }

    
}
