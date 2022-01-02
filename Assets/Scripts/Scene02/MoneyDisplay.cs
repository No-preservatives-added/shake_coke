using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;


public class MoneyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text moneyText;
    private string moneyString = "";
    private int moneyStringLength = 0;
    private int moneyOffset = 0;
    private int unitNum = 0;
    private string[] unitList = new string[] { "", "万", "億", "兆", "京", "垓", "𥝱", "穣", "溝", "澗", "正", "載", "極", "恒河沙", "阿僧祇", "那由他", "不可思議","無量大数"};

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneyString = Data.money.ToString("0"); //文字列変換
        moneyStringLength = moneyString.Length; //文字数カウント
        //Debug.Log(moneyString+","+moneyStringLength); //確認

        if (moneyStringLength < 73){ //無量大数までの単位で表せる
            moneyOffset = (moneyStringLength+3)%4+1; //最初の単位までの桁計算1-4
            unitNum = (int)(moneyStringLength+3)/4-1; //単位の数
            moneyText.text = moneyString.Substring(0, moneyOffset)+unitList[unitNum]; //表示文字列=最初の単位までの数字+最初の単位
            for (int i=unitNum;i>0;i--) {
                moneyText.text += moneyString.Substring(moneyOffset+4*(unitNum-i), 4)+unitList[i-1]; //表示文字列に（単位までの数字+単位）を追加
                if ((unitNum-i) == 0) break; //単位を2回出力したらやめる
            }
        }else{ //無量大数より大きい
            moneyText.text = moneyString.Substring(0, 1)+"."+moneyString.Substring(1, 8)+"×10^"+(moneyStringLength-1); //1桁.8桁×10^(文字数-1)
        }
        moneyText.text += "円"; //表示文字列に円を追加


        //moneyText.text = Data.money.ToString("0");

    }
}
