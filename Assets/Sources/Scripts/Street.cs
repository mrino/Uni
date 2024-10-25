using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Street : MonoBehaviour
{
    enum Direction{
        forward, 
        back, 
        right, 
        left
    }
    //탐색범위
    public float detectRange = 2f; 

    //탐색한 street 정보
    public Street forward, back, right, left;
    // Start is called before the first frame update
    void Start()
    {
        DetectStreets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //앱 시작 시, 내 주위에 있는 길 탐색
    void DetectStreets(){
        // 왼쪽에 있는지 탐색 후 있다면 left에 할당
        RayDirection(Vector3.left, Direction.forward);
        // 오른쪽에 있는지 탐색 후 있다면 right에 할당
        RayDirection(Vector3.right, Direction.right);
        // 앞쪽에 있는지 탐색 후 있다면 forward에 할당
        RayDirection(Vector3.forward, Direction.left);
        // 뒤쪽에 있는지 탐색 후 있다면 back에 할당
        RayDirection(Vector3.back, Direction.back);


    }
    //특정 방향으로 ray발사
    void RayDirection(Vector3 detect, Direction street){
        // 1. Ray를 생성(위치, 방향)
        Ray ray = new Ray(transform.position, detect);
        // 2. 부딪힌 것을 담을 그릇
        RaycastHit hitinfo;
        // 3. ray 발사
        bool isHit = Physics.Raycast(ray, out hitinfo, detectRange);
        
        // 4. 만일 부딪힌 것이 있는지 없는지 확인
        if(isHit){
            // 5. 만일 부딪힌 것이 있다면?
            Street dectectdStreet = hitinfo.collider.GetComponent<Street>();
            // 5-1. 부딪힌 것이 street인 경우에만
            if(dectectdStreet != null){
                // 6. 부딪힌 녀석을 left에 할당
                if(street == Direction.forward){
                    forward = hitinfo.collider.GetComponent<Street>();
                }
                if(street == Direction.back){
                    back = hitinfo.collider.GetComponent<Street>();
                }
                if(street == Direction.left){
                    left = hitinfo.collider.GetComponent<Street>();
                }
                if(street == Direction.right){
                    right = hitinfo.collider.GetComponent<Street>();
                } 
            }
        }
    }



    //  Debug 자기 기준으로 4 방향으로 ray 발사
    void OnDrawGizmos(){
        //3. 어느위치에서? 자가 자신위치
        
        Vector3 position = transform.position;
        //2. 4방향(절대/상대)
        //1. 가상의 선을 4방향으로 발사s
        //-앞 Forward
        Gizmos.DrawLine(position, position + Vector3.forward * detectRange);
        // Gizmos.DrawLine(position, position + transform.forward * detectRange);
        //-뒤 Backward
        Gizmos.DrawLine(position, position + Vector3.back * detectRange);
        // Gizmos.DrawLine(position, position + -transform.forward * detectRange);
        //-좌 left
        Gizmos.DrawLine(position, position + Vector3.left * detectRange);
        // Gizmos.DrawLine(position, position + -transform.right * detectRange);
        //-우 right
        Gizmos.DrawLine(position, position + Vector3.right * detectRange);
        // Gizmos.DrawLine(position, position + transform.right * detectRange);
    }

    
}
