using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//현재 scene에서 street를 관리
// - scene에 존재하는 street들을 수집
// - 특정 street로 player 이동
// - Marker 클릭하면 이동
// - street를 활성화/ 비활성화


public class StreetManager : MonoBehaviour
{
    // 모든 street 정보
    public Street[] streets;
    public GameObject markers;
    // 최초 1번
    void Start()
    {
        // - scene에 존재하는 street를 수집
        Init();
    }
    void Init(){
        // 1. hierarchy에 존재하는 게임오브젝틀들을 검색
        // 2. 그 중 street 컴포넌트를 가지고 있는 오브젝트 검색
        // 3, 그 오브젝트들을 streets 배열에 할당
        streets = FindObjectsOfType<Street>();
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스를 클릭했을때만 
        if(Input.GetMouseButtonDown(0))
            TouchObject();
    }
    
    public void TouchObject(){
        // 1. ray 생성 (위치와 방향)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // 2. 부딪힌 물체의 정보를 담을 변수
        RaycastHit hitinfo;
        // 3. ray를 발사
        bool isHit = Physics.Raycast(ray, out hitinfo);
        // 4-1. 만일 ray가 부딪힌 물체가 있다면 
        if(isHit){
            // 4-1-1. 만일 부딪힌 물체가 marker였다면
            string hitName = hitinfo.transform.name;
            if(hitName == "Marker"){
                //부딪힌 물체의 이름으로 비교
                // 4-1-2. 그러면 marker가 가르키는 방향으로 이동
                hitinfo.transform.GetComponent<Marker>().MoveTarget();
            }
        }else{
            // 4-2. 부딪히지 않았다면 
            
        }

    }
    
    public void TouchMarker(){
        
    }
}
