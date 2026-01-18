using System.Text;

public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
            // This code crates a new string for every loop         
            // result += stack.Pop();
            // This new one does it better and efficiently
            var results = new StringBuilder();
        while (stack.Count > 0)
            result.Append(stack.Pop());
            return result.ToString();
    }
}