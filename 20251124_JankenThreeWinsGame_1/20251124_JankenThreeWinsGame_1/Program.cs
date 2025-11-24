using System;

class Program
{
    static void Main()
    {
        int winStreak = 0; //連勝数
        Random random = new Random();

        Console.WriteLine("=== じゃんけんゲーム（3連勝で勝利！） ===");

        while(winStreak < 3)
        {
            Console.WriteLine("あなたの手を入力してください：");
            Console.WriteLine("0：グー, 1：チョキ, 2：パー");

            //入力受付
            if(!int.TryParse(Console.ReadLine(), out int playerHand)|| playerHand < 0 ||playerHand > 2)
            {
                Console.WriteLine("入力が不正です。0～2を入力してください。");
                continue;
            }

            int cpuHand = random.Next(0, 3); //CPUの手

            String[] handName = { "グー", "チョキ", "パー" };
            Console.WriteLine($"あなた：{handName[playerHand]} vs CPU: {handName[cpuHand]}");

            //勝敗判定
            int result = (playerHand - cpuHand + 3) % 3;

            if(result == 1)
            {
                Console.WriteLine("あなたの勝ち！");
                winStreak++;
                Console.WriteLine($"★ 現在の連勝数：{winStreak}");
            }
            else if (result == 2)
            {
                Console.WriteLine("あなたの負け…");
                winStreak = 0;
            }
            else
            {
                Console.WriteLine("あいこ！");
                winStreak = 0;
            }

        }

        Console.WriteLine("🎉 おめでとう！3連勝達成！ 🎉");
    }

}