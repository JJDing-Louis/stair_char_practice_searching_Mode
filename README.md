# stair_char_practice_searching_Mode
Use another method to search code

## 平移起始點座標讀取

```cs    
for (int y = 0; y < content.Count; y++)
{
    //X方向的平移
    for (int x = 0; x < content[y].Count; x++)
    {
        //取54個字元
        List<char> ans = new List<char>();
        for (int i = 0; i < 54; i++)
        {   //搜尋方式增加if判斷式，判定第一個項目是否為!，節省運算步驟
            if (((x + i) >= content[y].Count) && ((y + i) >= content.Count))
            {
                ans.Add(content[y + i - content.Count][2 * content[y].Count - (x + i) - 2]);
            }
            else if (((x + i) >= content[y].Count) && ((y + i) < content.Count))
            {
                ans.Add(content[y + i][2 * content[y].Count - (x + i) - 2]);
            }
            else if (((x + i) < content[y].Count) && ((y + i) >= content.Count))
            {
                ans.Add(content[y + i - content.Count][x + i]);
            }
            else
            {
                ans.Add(content[y + i][x + i]);
            }
        }

        streamWriter.Write(judge_function(ans));
    }
}
```
## 判斷條件函式
```cs    
public StringBuilder judge_function(List<char> ans)
        {
            StringBuilder sentence = new StringBuilder();
            //判定第1個條件，第1個字以及第10字為 !
            if (ans[0].Equals('!') && ans[9].Equals('!'))
            {
                //判定第2個條件，符號不會出現在答案裡面(%,^,+,@,#,*,=)
                //if(ans.All(item => item.Equals(rule.Select(item=> item))))
                if (!(ans.Contains('%') || ans.Contains('^') || ans.Contains('+') || ans.Contains('@') || ans.Contains('#') || ans.Contains('*') || ans.Contains('=')))
                {
                    foreach (char item in ans)
                    {
                        sentence.Append(item);
                    }
                    return sentence.Append(Environment.NewLine);
                }
            }
            return null;
```
