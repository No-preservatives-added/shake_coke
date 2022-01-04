using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class UnitDisplay
{
    
    public static string Display(BigInteger x){
        string changedText;
        string xString = "";
        int xStringLength = 0;
        int unitOffset = 0;
        int unitNum = 0;
        string[] unitList = new string[] { "", "万", "億", "兆", "京", "垓", "𥝱", "穣", "溝", "澗", "正", "載", "極", "恒河沙", "阿僧祇", "那由他", "不可思議","無量大数"};

        xString = x.ToString("0"); //文字列変換
        xStringLength = xString.Length; //文字数カウント
        //Debug.Log(moneyString+","+moneyStringLength); //確認

        if (xStringLength < 73){ //無量大数までの単位で表せる
            unitOffset = (xStringLength+3)%4+1; //最初の単位までの桁計算1-4
            unitNum = (int)(xStringLength+3)/4-1; //単位の数
            changedText = xString.Substring(0, unitOffset)+unitList[unitNum]; //表示文字列=最初の単位までの数字+最初の単位
            for (int i=unitNum;i>0;i--) {
                changedText += xString.Substring(unitOffset+4*(unitNum-i), 4)+unitList[i-1]; //表示文字列に（単位までの数字+単位）を追加
                if ((unitNum-i) == 0) break; //単位を2回出力したらやめる
            }
        }else{ //無量大数より大きい
            changedText = xString.Substring(0, 1)+"."+ xString.Substring(1, 8)+"×10^"+(xStringLength-1); //1桁.8桁×10^(文字数-1)
        }
        return changedText;
    }
    
}
