using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _20251124_JankenThreeWinsGame_2
{
    public class IndexModel : PageModel
    {
        public JsonResult OnGetPlay(string hand)
        {
            //手の対応
            Dictionary<string, int> map = new()
            {
                {"rock", 0 }, //グー
                {"scissors", 1 }, //チョキ
                {"paper", 2 } //パー
            };

            int user = map[hand];
            int cpu = new Random().Next(0, 3);

            string[] names = { "グー", "チョキ", "パー" };

            string resultMessage;

            //勝敗判定（0 = あいこ, 1 = 勝ち, 2 = 負け）
            int judge = (3 + user - cpu) % 3;

            //セッションから連勝数取得（なければ0）
            int winStreak = HttpContext.Session.GetInt32("WinStreak") ?? 0;

            if(judge == 1)
            {
                winStreak++;
                resultMessage = $"あなた：{names[user]} CPU: {names[cpu]} → 勝ち！";
            }
            else
            {
                //負け・あいこでリセット
                winStreak = 0;
                resultMessage = $"あなた：{names[user]} CPU: {names[cpu]} → {(judge == 0 ? "あいこ" : "負け")}";
            }

            //3連勝達成
            if(winStreak >= 3)
            {
                resultMessage += "★ 3連勝達成！あなたの勝ち！ ★";
                winStreak = 0; //リセット
            }

            //セッション保存
            HttpContext.Session.SetInt32("WinStreak", winStreak);

            return new JsonResult(new
            {
                message = resultMessage,
                winStreak = winStreak
            });
        }
    }
}