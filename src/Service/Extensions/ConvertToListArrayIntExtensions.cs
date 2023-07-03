using System.Text.RegularExpressions;

namespace Service.Extensions
{
    /// <summary>
    /// Extension method to convert from list string to list array of int
    /// </summary>
    public static class ConvertToListArrayIntExtensions
    {
        /// <summary>
        /// Convert to List of int
        /// </summary>
        /// <param name="list"></param>
        /// <returns>List<int[]></returns>
        public static List<int[]> ToListArrayInt(this List<string> list)
        {
            var listArray = new List<int[]>();

            foreach(var line in list)
            {
                listArray.Add(Array.ConvertAll(Splitter(line.Trim()), int.Parse));
            }
            return listArray;
        }

        private static string[] Splitter(string input)
        {
            return Regex.Split(input, @"\W+");
        }
    }
}
