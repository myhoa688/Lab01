using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== Chương trình đoán số ===");

        Random random = new Random();
        int targetNumber = random.Next(100, 999);
        string target = targetNumber.ToString();

        int attempt = 1, MAX_GUESS = 7;
        string guess, feedback = "";
        while (feedback != "+++" && attempt <= MAX_GUESS)
        {
            Console.Write("Lần đoán thứ [{0}]: ", attempt);
            guess = Console.ReadLine();
            feedback = GetFeedback(target, guess);
            Console.WriteLine("Phản hồi từ máy tính: [{0}]", feedback);
            attempt++;
        }

        Console.WriteLine("Người chơi đã đoán {0} Lần. Trò chơi kết thúc!", attempt - 1);
        if (attempt > MAX_GUESS)
        {
            Console.WriteLine("Người chơi thua cuộc. Số cần đoán là: {0}", targetNumber);
        }
        else
        {
            Console.WriteLine("Người chơi thắng cuộc!", attempt);
        }
        Console.ReadLine();
    }

    static string GetFeedback(string target, string guess)
    {
        string feedback = "";
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] == guess[i])
            {
                feedback += "+";
            }
            else if (target.Contains(guess[i].ToString()))
            {
                feedback += "?";
            }
        }
        return feedback;
    }
}