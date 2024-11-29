
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Street : MonoBehaviour
{   
    //탐색범위
    private float detectRange = 0f; 

    
    public GameObject marker;

    //탐색한 street 정보
    public Street forwardStreet, backStreet, rightStreet, leftStreet;
    // Start is called before the first frame update
    void Start()
    {
        InitDetectRangeByScale();
        DetectStreets();
    }

    void InitDetectRangeByScale(){
        //자기 자신의 반지름
        float radius = gameObject.transform.localScale.z * 0.5f;
        //반지름의 일정 배수만큼 조절하여 범위를 설정
        //조절된 범위를 탐색범위로 설정
        detectRange = GameManger.Instance.adjustRange * radius;

    }

    // Update is called once per frame
    void Update()
    {
        DetectStreets();
    }

    //앱 시작 시, 내 주위에 있는 길 탐색
    void DetectStreets(){
        // 앞쪽에 있는지 탐색 후 있다면 forward에 할당
        RayDirection(Direction.forward);
        // 뒤쪽에 있는지 탐색 후 있다면 back에 할당
        RayDirection(Direction.back);
        // 왼쪽에 있는지 탐색 후 있다면 left에 할당
        RayDirection(Direction.left);
        // 오른쪽에 있는지 탐색 후 있다면 right에 할당
        RayDirection(Direction.right);
    }
   
    
    //특정 방향으로 ray발사
    void RayDirection(Direction dir){
        // 0. 임의의 방향에 따른 ray 발사 방향 지정
        Vector3 rayDir = GetRayDirection(dir);
        // 1. Ray를 생성(위치, 방향)
        Ray ray = new Ray(transform.position, rayDir);
        // 2. 부딪힌 것을 담을 그릇
        RaycastHit hitinfo;
        // 3. ray 발사
        bool isHit = Physics.Raycast(ray, out hitinfo, detectRange);
        // 4. 만일 부딪힌 것이 있는지 없는지 확인
        if(isHit){
            SetDectectedStreet(dir,hitinfo);
        }
    }
    void SetDectectedStreet(Direction dir, RaycastHit hitinfo)
    {
        // 5. 만일 부딪힌 것이 있다면?
        // 5-1. 부딪힌 것이 street인 경우에만
        Street street = hitinfo.collider.GetComponent<Street>(); 
        if(street == null) return; 
        switch (dir)
        {
            case Direction.forward:
                forwardStreet = street;
                break;
            case Direction.back:
                backStreet = street;
                break;
            case Direction.left:
                leftStreet = street;
                break;
            case Direction.right:
                rightStreet = street;
                break;
        }   
    }

    // 임의의 방향에 따른 ray의 발사 방향 구하기
    // - 임의의 방향 (enum Dir)
    Vector3 GetRayDirection(Direction dir){
        // 0-1. 발사 방향을 담을 변수
        Vector3 rayDir = Vector3.zero;
        // 0-2. 전달받은 임의 방향에 따라 발사 방향 분기
        switch(dir){
            // 0-3. 분류한 방향을 변수에 담아둔다
            case Direction.forward: rayDir = Vector3.forward; break;
            case Direction.back: rayDir = Vector3.back; break;
            case Direction.left: rayDir = Vector3.left; break;
            case Direction.right: rayDir = Vector3.right; break;
        }
        return rayDir;
    }

    //화살표를 눌러 장소를 이동시키는 버튼에 연결할 함수
    //특정방향 장소
    public void OnClickNavigatorBtn(Direction dir){
        print($"{dir} 버튼 클릭");
        //1. 현재 장소 갱신
        // - 다음 장소 street 정보
        // - gameManger을 찾고, 
        // - gameManger가 가지고있는 gameManger을 찾고 
        // - gameManger 컴포넌트가 가지고 있는 currentSstreet을 가져온다
        Street nextStreet = GetNextStreet(dir);
        // - player 정보 필요
        // - 현재 장소 street에 대한 정보도 필요
        Debug.Log(nextStreet);
        SetCurrentStreet(nextStreet);

        //다음 화면으로 전송
        TranstionManger.Instance.MakeTrasition();
    }


    void SetCurrentStreet(Street street){
        #region ver.1
        // GameObject gameManger = GameObject.Find("GameManger");
        // GameManger gm = gameManger.GetComponent<GameManger>();
        // gm.currentStreet = street; 
        #endregion
        #region ver.2
        // GameManger gm = FindObjectOfType<GameManger>();     
        // gm.currentStreet = street;
        // Debug.Log("currentStreet가 설정되었습니다.");     
        #endregion
        #region var.3
        GameManger.Instance.currentStreet = street;
        #endregion
    }

    //방향에 따른 다음 장소의 street정보 가져오기
    private Street GetNextStreet(Direction dir){
        switch (dir)
        {
            case Direction.forward: 
                return forwardStreet;
            case Direction.back: 
                return backStreet;
            case Direction.right: 
                return rightStreet;
            case Direction.left: 
                return leftStreet;
            default: return null;
        }
    }

    


    //  Debug 자기 기준으로 4 방향으로 ray 발사
    void OnDrawGizmos(){
        //3. 어느위치에서? 자가 자신위치
        Vector3 position = transform.position;
        //2. 4방향(절대/상대)
        //1. 가상의 선을 4방향으로 발사
        
        //내 반지름 크기
        float radius = gameObject.transform.localScale.z * 0.5f;
        float testadjustRange = GameManger.Instance != null ? GameManger.Instance.adjustRange : 1.5f;
        float testRange = radius * testadjustRange;
        
        //-앞 Forward
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(position, position + Vector3.forward * testRange);
        // Gizmos.DrawLine(position, position + transform.forward * testRange);
        //-뒤 Backward
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(position, position + Vector3.back * testRange);
        // Gizmos.DrawLine(position, position + -transform.forward * testRange);
        //-좌 left
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, position + Vector3.left * testRange);
        // Gizmos.DrawLine(position, position + -transform.right * testRange);
        //-우 right
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + Vector3.right * testRange);
        // Gizmos.DrawLine(position, position + transform.right * testRange);
    }
}
