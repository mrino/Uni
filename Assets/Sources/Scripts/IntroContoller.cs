using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/*
application 화면의 전환
버튼을 눌렀을때 기능 실행 
start 버튼과 quit 버튼
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
        print("Dd");
    }

    public void OnclickQuit(){
        //앱 종료        
        Application.Quit();
    }
}
