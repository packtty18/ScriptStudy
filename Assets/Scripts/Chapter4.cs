using UnityEngine;

public class Chapter4 : MonoBehaviour
{
    //데이터의 형변환에 관한 내용
    private void Start()
    {
        //자동 형변환
        int myMoney = 160000000;
        long money = (int)myMoney;  //자동형변환이기에 (int)가 없어도 되기에 어두운색으로 바뀜
        //만약 long을 int로 형변환하는데 이미 long에 int의 데이터범위를 넘어서는 값이 있다면
        //->오버 플로우 발생!!

        //강제형변환
        int myMoney2 = (int)money;
        


        //문자 -> 숫자
        string age = "17";
        int myAge = int.Parse(age);
        //int myAge = (int)age;  //에러발생
        //string age = "17살"    //문자가 포함되는 경우 parse는 사용불가함
        Debug.Log(myAge);


        //숫자 -> 문자
        int height = 190;
        string height2=  height.ToString();
        Debug.Log(height2);
    }
}
