internal class Program
{
    private static void Main(string[] args)
    {
        List<string> AvailableOptions = GetAvailables(typeof(State));

        var currentState = State.Free;

        int currentLine = 0;

        while (currentState != State.Exit)
        {
            //Seçenekleri ekrana getir.
            for (int i = 0; i < AvailableOptions.Count; i++)
            {
                var currentOption = AvailableOptions[i];
                if (i == currentLine)
                    currentOption = ShowSelected(currentOption);
                Console.WriteLine(currentOption);
            }

            // Basılan tuşu al
            var keyPressed = Console.ReadKey(true);
            if (keyPressed.Key == ConsoleKey.Enter)
                currentState = (State)(currentLine + 1);
            else if (keyPressed.Key == ConsoleKey.DownArrow)
                currentLine++;
            else if (keyPressed.Key == ConsoleKey.UpArrow)
                currentLine--;

            if (currentLine < 0)
                currentLine = AvailableOptions.Count + currentLine;
            else if (currentLine >= AvailableOptions.Count)
                currentLine = AvailableOptions.Count - currentLine;

            Console.Clear();
        }
    }

    static string ShowSelected(string text)
    {
        return text + "<";
    }

    static List<string> GetAvailables(Type type)
    {
        if (!type.IsEnum)
            return new List<string>();

        var list = new List<string>();

        foreach (var item in Enum.GetValues(type))
        {
            list.Add(item.ToString());
        }
        return list;
    }
}

public enum State
{
    Free = 1,
    Menu = 2,
    Exit = 3
}