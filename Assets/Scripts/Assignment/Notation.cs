using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum NotationType
{
    None,
    Scientific,
    Traditional,
    Alphabet
}

public class Notation : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;
    public TMP_InputField NumberInputField;
    public Button AddButton;
    public Button MultiplyButton;
    public TMP_Dropdown TypeDropdown;
    

    [SerializeField]
    private double _money = 1;
    [SerializeField]    
    private NotationType _mode = NotationType.None;

    void Start()
    {
        AddButton.onClick.AddListener(AddMoney);
        MultiplyButton.onClick.AddListener(MultiplyMoney);
        TypeDropdown.onValueChanged.AddListener(TypeChangeListener);
        MoneyText.text = _money.ToString();
        TypeDropdown.value = 0;
    }

   
    private void TypeChangeListener(int _typeValue)
    {
        switch (_typeValue)
        {
            case 0: _mode = NotationType.None;   break;
            case 1: _mode = NotationType.Scientific;  break;
            case 2: _mode = NotationType.Traditional; break;
            case 3: _mode = NotationType.Alphabet; break;
        }

        ChangeMoneyText();
    }

    public void AddMoney()
    {
        double _index;

        bool flowControl = GetInput(out _index);
        if (!flowControl)
        {
            return;
        }

        _money += _index;
        ChangeMoneyText();
    }

    private void MultiplyMoney()
    {
        double _index;
        bool flowControl = GetInput(out _index);
        if (!flowControl)
        {
            return;
        }
        _money *= _index;
        ChangeMoneyText();
    }

    private bool GetInput(out double _index)
    {
        bool success = double.TryParse(NumberInputField.text, out _index);
        if (!success)
        {
            Debug.LogWarning($"인풋에 숫자가 아닌 요소가 있습니다. {NumberInputField.text}");
        }

        return success;
    }

    private void ChangeMoneyText()
    {
        switch (_mode)
        {
            case NotationType.None: MoneyText.text = _money.ToString(); break;
            case NotationType.Scientific: MoneyText.text = ScientificConverter(_money); break;
            case NotationType.Traditional: MoneyText.text = TraditionalConverter(_money); break;
            case NotationType.Alphabet: MoneyText.text = AlphabetConverter(_money); break;
        }
    }
    private string ScientificConverter(double _money)
    {
        //숫자가 맞나?
        if (double.IsNaN(_money)) 
            return "NaN";
        //무한대인가?
        if (double.IsInfinity(_money)) 
            return (_money > 0) ? "Infinity" : "-Infinity";
        //0이라면
        if (_money == 0.0) 
            return "0";

        //부호 지우기
        string sign = _money < 0 ? "-" : "";
        _money = Math.Abs(_money);

        //10이 몇개 존재하는가
        int exponent = (int)Math.Floor(Math.Log10(_money));
        //지수부 : 가장 앞자리 X.XX 까지
        double mantissa = _money / Math.Pow(10, exponent);

        if (mantissa >= 10.0)
        {
            mantissa /= 10.0;
            exponent += 1;
        }

        //소수점 2자리수까지 반올림
        string mantissaStr = mantissa.ToString("F" + 2);

        string exponentSign = exponent >= 0 ? "+" : ""; 
        return $"{sign}{mantissaStr}e{exponentSign}{exponent}";
    }

    private readonly string[] traditionalSuffixes =
   {
        "", "K", "M", "B", "T", "Q", "Qi", "Sx", "Sp", "Oc", "No", "Dc"
    };
    public string TraditionalConverter(double money)
    {
        if (money < 1000d)
            return money.ToString("F0");

        int exponent = (int)(Math.Floor(Math.Log10(money) / 3)); // every 3 digits
        exponent = Mathf.Min(exponent, traditionalSuffixes.Length - 1);

        double shortValue = money / Math.Pow(1000, exponent);
        string suffix = traditionalSuffixes[exponent];

        return $"{shortValue:F2}{suffix}";
    }

    private readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string AlphabetConverter(double money)
    {
        //돈이 1000 미만이라면 그냥 출력
        if (money < 1000d)
            return money.ToString("F0");

        //자릿수
        int exponent = (int)(Math.Floor(Math.Log10(money) / 3));
        exponent -= 1;

        //단위
        string suffix = ConvertToAlphabetSuffix(exponent);

        double shortValue = money / Math.Pow(1000, exponent + 1);
        return $"{shortValue:F2}{suffix}";
    }

    private string ConvertToAlphabetSuffix(int index)
    {
        string result = "";
        int baseCount = alphabet.Length;

        //z를 넘어가면 aa가 되게끔 반복
        while (index >= 0)
        {
            result = alphabet[index % baseCount] + result;
            index = (index / baseCount) - 1;
        }

        return result;
    }


}


