using UnityEngine;

public class Chapter5 : MonoBehaviour
{
    //연산자
    private void Start()
    {
        int a = 27;
        int b = 5;

        //산술연산자
        int sum = a + b;
        int sub = a - b;
        int mul = a * b;
        int div = a / b;

        Debug.Log(div);

        float d = 27 / 4;
        Debug.Log(d);

        //대입연산자
        a = b;
        d = a;

        //증감 연산자
        a++;
        b--;
    }
}
