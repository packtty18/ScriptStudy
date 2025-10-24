using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigNumber : MonoBehaviour
{
    [SerializeField]
    [Tooltip("단위별 돈의 양, 각 항목마다 999가 최대이며 1000을 초과할경우 다음 단위에 추가")]
    public List<int> MoneyList;
    [Tooltip("현재 초당 증가하는 돈의 량")]
    public double CurrentIncreasePerSecond;

    public int UnitCount => MoneyList.Count;

    public double TestNumber;

    private void Start()
    {
        MoneyList = new List<int>() { 0 }; //기본
        Debug.Log(MoneyList[0]);
        CurrentIncreasePerSecond = 1.0;
    }


    private void Update()
    {
        

    }

    [ContextMenu("convert")]
    public void ConverterTest()
    {
        List<int> result = UnitConverter(TestNumber);
        int count = 0;
        foreach (int item in result)
        {
            Debug.Log($"1e^({3* count}) : {item}\n");
            count++;
        }

    }

    /// <summary>
    /// 리스트에 해당 돈 추가
    /// </summary>
    public void AddMoney(double value)
    {
        List<int> result = UnitConverter(TestNumber);

    }

    /// <summary>
    /// 해당 값을 변환하여 단위와 증가량으로 변환
    /// </summary>
    public List<int> UnitConverter(double value)
    {
        List<int> result = new List<int>();
        double index = value;
        while(index > 1000)
        {
            result.Add((int)(index % 1000.0));
            index /= 1000;
        }
        result.Add((int)index);

        return result;
    }

}
