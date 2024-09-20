using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//씬 전환신 중간 역할
// a. 로딩 process 진행율 -> 로딩바 or 알려주지않음
// b. 어디로 이동할지 (씬 이름)
public class LoadingManager : MonoBehaviour
{
    // 이동할 sceane의 이름
    // 최소 로딩 시간
    void Start()
    {
        
    }
    // static 함수 다른 Scene에서 loadingManager을 통해 targetScene으로 이동
    // targetScene으로 이동시켜줄 함수
    // targetScene이 어디야? targetscean의 이름
    static public void LoadScene(string targetScean){
        //target씬으로 이동하기전에 loadingScene으로 이동

    }

    //실질적으로, target씬으로 이동하기 위한 씬 로딩
    private void LoadSceneProcess(){
        // 1. 다음 화면의 불러올 데이터 정보를 가져온다.
        // 2. Target 씬으로 전환 명령 대기
        // 3. 1번의 데이터를 기반으로 target씬 데이터 load
        // 4. 로딩이 완료되면, target씬으로 전환(이동) -> 2번) 명령대기 해제
        // 5. 만일 로딩 시간이 최소로딩시간보다 짧다면 최소시간만큼 대기
        
    }
}
