using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Erreur: Veuillez fournir une chaîne à vérifier.");
            Environment.Exit(1);
        }

        string input = args[0];

        if (IsValidCode39Extended(input))
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Erreur: La chaîne fournie contient des caractères non valides pour Code 39 Extended.");
            Environment.Exit(1);
        }
    }

    static bool IsValidCode39Extended(string input)
    {
        string pattern = @"^([A-Z0-9\-\.\/\$\+\%\* ]|[\/\+\%][A-Z])+$";
        return Regex.IsMatch(input, pattern);
    }
}