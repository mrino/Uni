using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Marker : MonoBehaviour {
    // 목표 : 선택하면 특정장소로 이동
    // - 이동할 장소(street)
    public Street targetStreet;
    public void MoveTarget(){
        // 1. player를 알것
        GameObject player = GameObject.Find("Player");
        // 2. 이동시킬 위치를 알것
        Vector3 movePos = targetStreet.transform.position;
        // 3. player 이동 
        player.transform.position = movePos;
    }
    
}