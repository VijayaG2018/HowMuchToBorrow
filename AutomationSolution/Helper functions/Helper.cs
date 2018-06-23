namespace AutomationSolution.Helper_functions
{
    public static class Helper
    {
        public static string RemoveNonNumeric(this string s)
        {
            var modifiedText = s.Replace("$", "");
            //Console.WriteLine(modifiedText);
            var finalText = modifiedText.Replace(",", "");
            //Console.WriteLine(finalText);
            return finalText;
        }

        //more functions could be added to handle calendar,popup,carousels, generate random strings etc
    }
}
