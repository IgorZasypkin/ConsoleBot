using System.Reflection;

class Program
{
    static void Main()
    {
        const string HelpDescription = "Справочная информация:\n/start - Запуск бота;\n/help - Cправочная информация;" +
            "\n/info - Версия программы и дата создания;" +
            "\n/echo - Вывод введенного сообщения;\n/exit - Остановка бота;";
        const string Start = "/start";
        const string Echo = "/echo";
        const string Info = "/info";
        const string Help = "/help";
        const string Exit = "/exit";
        
        string? commandValue;
        string? userName = "";

        Console.WriteLine($"Привет!\nЭто консольный бот.\nДоступные команды в данный момент: {Start}, {Help}, {Info}, {Exit}");
        do
        {
            commandValue = Console.ReadLine();
            ControllFunction(commandValue);
        }
        while (commandValue != Exit);

        void ControllFunction(string? command)
        {
            if (command != null)
            {
                if (userName != "" && command.TrimStart().StartsWith($"{Echo} "))
                {
                    List<string> wordsOfCommand = new(command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    wordsOfCommand.RemoveAt(0);
                    string result = string.Join(" ", wordsOfCommand);
                    Console.WriteLine(result);
                }
                switch (command)
                {
                    case Start:
                        Console.WriteLine("Введите ваше имя:");
                        userName = Console.ReadLine();
                        Console.WriteLine($"{userName}, вам дополнительно стала доступна команда /echo (например /echo hello) " +
                            $"ожидание команды:");
                        break;
                    case Help:
                        Console.WriteLine($"{(userName != "" ? userName + ",\n" : "")}{HelpDescription}");
                        break;
                    case Info:
                        Console.WriteLine(string.Format($"{(userName != "" ? userName + ",\n" : "")}Текущая версия системы: " +
                            $"{Assembly.GetExecutingAssembly().GetName().Version}\nДата создания: 05.07.2024"));
                        break;
                    case Exit:
                        Console.WriteLine($"Пока{(userName != "" ? ", " + userName : "")}");
                        break;
                }
            }
        }
    }
}