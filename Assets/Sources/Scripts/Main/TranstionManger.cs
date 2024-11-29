using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//목적 : 장소 이동시, 화면 전환 효과를 주고싶다.
// - 화면전환시간
// - 화면전환시 딜레이시간
// - 화면전환용 이미지 (Canvas)
//
public class TranstionManger : MonoBehaviour
{
    public static TranstionManger Instance = null;
    // - 화면전환시간
    public float duration;
    // - 화면전환시 딜레이시간
    public float delayTime = 1.5f; 
    // - 화면전환용 이미지 (Canvas)

    public Image image;
    // Start is called before the first frame update
    private void Awake() {
        //만일 instance안의 값이 비어있다면 
        //값을 할당한다.
        if(Instance == null){
            Instance = this;   
        } else{
            gameObject.SetActive(false);
        }
    }

    public void MakeTrasition(){
        StartCoroutine(FadeInOut());

    }

    // 화면 전환 시, 이미지를 투명, 불투명 으로 전환
    private IEnumerator FadeInOut(){
        
        //0. FadeInOut init
        // - timer
        float timerFadein = 0f;
        float timerFadeOut = 0f;
        // - half durtion 
        float halfDrution = duration * 0.5f;
        //1. fade in
        
        while(image.color.a <= 1.0f){
            // coruoution 반환
            yield return null;
            //시간이 경과하도록 한다. (타이머 진행)
            timerFadein += Time.deltaTime;
            //transtion image alpha 조절
            // a. 현재 img가 가진 alpha 값 가져오기
            Color color =  image.color;
            // b. alpha 값을 시간의 흐름에 따라 증가
            color.a = timerFadein/halfDrution;
            Debug.Log(color.a);
            // c. 증가시킨 alpha값 image에 반영
            image.color = color;
        }
        //2. delay
        
        //3. player move   
        GameManger.Instance.MovePlayer();
        GameManger.Instance.MappingStreet();
        
        yield return new WaitForSeconds(delayTime);
        

        //4. Fade Out
        while(image.color.a > 0){
            // coruoution 반환
            yield return null;
            //시간이 경과하도록 한다. (타이머 진행)
            timerFadeOut += Time.deltaTime;
            //transtion image alpha 조절
            // a. 현재 img가 가진 alpha 값 가져오기
            Color color =  image.color;
            // b. alpha 값을 시간의 흐름에 따라 감소
            color.a = 1 - timerFadeOut/halfDrution;
            Debug.Log(color.a);
            // c. 감소시킨 alpha값 image에 반영
            image.color = color;
        } 
    }
    void Log(){

    }
}
