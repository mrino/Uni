using UnityEngine;
using UnityEngine.SceneManagement ;
/*
application 화면의 전환
버튼을 눌렀을때 기능 실행 
1.start 버튼
 a.unity에서 씬 이동을 위한 기능을 연결

2.quit 버튼

*/
public class IntroContoller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    // button
    public void OnClickStart(){
        //씬전환
        SceneManager.LoadScene("Main");
        
    }

    public void OnclickQuit(){
        //앱 종료
        //2. 만약 유니티 에디터라면 빌드 종료
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        //1.pc 종료
        Application.Quit();
        #endif
    }
}
