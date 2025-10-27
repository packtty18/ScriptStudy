using UnityEngine;

public class Example2 : MonoBehaviour
{
    public int Number = 90;
    public int Speed = 90;
    public int Num1 = 10;
    public int Num2 = 20;

    void Start()
    {//1번 Number의 숫자가 홀수면 홀수 짝수면 짝수
        if(Number %2 == 0)
        {
            Debug.Log("1번문제 : 짝수 입니다");
        }
        else
        {
            Debug.Log("1번문제 : 홀수 입니다");
        }

        //2번
        //속도가 40~80이라면 적정 , 최대를 넘어가면 과속, 적으면 속도를 올리세요
        if(Speed < 40)
        {
            Debug.Log("속도를 올리세요");
        }
        else if(Speed > 80)
        {
            Debug.Log("과속입니다");
        }
        else
        {
            Debug.Log("적정 속도입니다");
        }
        //3번
        //Num1과 Num2 바꾸기
        int _index = Num2;
        Num2 = Num1;
        Num1 = _index;

        Debug.Log(Num1);
        Debug.Log(Num2);
    }

}
