using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Marker : MonoBehaviour {
    // 목표 : 선택하면 특정장소로 이동
    // - 이동할 장소(street)
    // s역할
    // A. 자기 자신을 기준으로 4방향 (앞, 뒤, 좌, 우)에 이동 가능한 장소가 있는지 확인
    //      - Ray 활용
    //      - 시각적으로 볼 수 있게 수정     
    // B. a역할을 기준으로 내가 이동할수 있는 공간정보 획득
    public Street targetStreet;

    public void MoveTarget(){
        // 1. player를 알것
        GameObject player = GameObject.Find("Player");
        // 2. 이동시킬 위치를 알것
        Vector3 movePos = targetStreet.transform.position;
        // 3. player 이동 
        player.transform.position = movePos;
    }

    private void Update() {
    }
}