using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//씬 전환신 중간 역할
// a. 로딩 process 진행율 -> 로딩바 or 알려주지않음
// a. CanvasGroup을 활요한 투명도 조절
// b. 어디로 이동할지 (씬 이름)
public class LoadingManager : MonoBehaviour
{
    // 이동할 sceane의 이름
    public static string targetScene;
    // 최소 로딩 시간
    public static float minLoadingTime = 3f;

    public CanvasGroup canvasGroup; 

    // 씬이 실행되는 순간 한번만 실행
    void Start()
    {
        //canvasGroup = GameObject.Find("LoadingUiGroup").GetComponent<CanvasGroup>();
        //3. 다음씬으로 이동될수있게 로딩
        StartCoroutine(LoadSceneProcess());
    }
    // static 함수 다른 Scene에서 loadingManager을 통해 targetScene으로 이동
    // targetScene으로 이동시켜줄 함수
    // targetScene이 어디야? targetscean의 이름
    public static void LoadScene(string _targetScene){
        //1. target씬으로 이동하기전에 loadingScene으로 이동
        targetScene = _targetScene;
        //2. 로딩씬으로 이동
        SceneManager.LoadScene("Loading");
    }

    //실질적으로, target씬으로 이동하기 위한 씬 로딩
    private IEnumerator LoadSceneProcess(){
        // 4-1. 다음 화면의 불러올 데이터 정보를 가져온다.
        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        // 4-2. Target 씬으로 전환 명령 대기
        op.allowSceneActivation = false;

        // 최소 로딩 시간을 위한 timer 생성
        float timer = 0.0f;

        // 4-3. 1번의 데이터를 기반으로 target씬 데이터 load
        while(!op.isDone){
            // coruoution 용 awiat 대기 함수
            yield return null;
            // 4-4-1로딩이 완료되지 않은 경우
            if(op.progress < 0.9f){
                //로딩이 완료되지 않았을때 실행할 코드
            }
            // 4-4-2. 로딩이 완료되면, target씬으로 전환(이동) -> 2번) 명령대기 해제
            else{
                // 4-5. 만일 로딩 시간이 최소로딩시간보다 짧다면 최소시간만큼 대기
                // - 로딩 진행률에 따라 canvasGroup 사용해서 투명도 조절
                // -> 타이머 start 
                timer += Time.unscaledDeltaTime;
                // -> 최소 로딩시간에 걸쳐서 ui를 투명화 시킨다.
                canvasGroup.alpha = 1f - (float)(timer/minLoadingTime);
                if(timer > minLoadingTime){
                    // 4-6. 다음 씬 로딩
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
