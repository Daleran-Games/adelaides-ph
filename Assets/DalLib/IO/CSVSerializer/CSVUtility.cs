﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DaleranGames.IO
{
    public static class CSVUtility 
    {
        const string columnSplit = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        const string rowSplit = @"\r\n|\n\r|\n|\r";
        static char[] trimChars = { '\"' };
        const string listSplit = @";";

        public static List<string[]> ParseCSVToArray(string csv)
        {
            string[] rows = Regex.Split(csv, rowSplit);
            if (rows.Length <= 1)
            {
                List<string[]> zero = new List<string[]>();
                return zero;
            }
            List<string[]> output = new List<string[]>();

            for (int i=0; i < rows.Length; i++)
            {
                string[] row = Regex.Split(rows[i], columnSplit);
                if (row.Length == 0 || string.IsNullOrEmpty(row[0]) || row[0] == " " )
                    continue;
                output.Add(row);
            }
            return output;
        }

        public static List<string> ParseList (string csvListElement)
        {
            List<string> items = new List<string>(Regex.Split(csvListElement,listSplit));
            //Debug.Log("List Lenght: "+items.Count);
            if (items.Count == 1 && items[0] == "")
                return new List<string>(0);
            else
                return items;
        }
    }
}
