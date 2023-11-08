using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard //Fady Hatta .NET23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode; //för att programmet ska kunna läsa och skriva in Unicode (Symboler och tecken)
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Hur många rader ska du ha:"); //Dela upp Rader
            if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0)
            {
                Console.WriteLine("Fel! Du måste använda ett positivt heltal.");
                return;
            }

            Console.WriteLine("Hur många kolumner ska du ha:"); //...och kolumner
            if (!int.TryParse(Console.ReadLine(), out int columns) || columns <= 0)
            {
                Console.WriteLine("Fel! Du måste använda ett positivt heltal.");
                return;
            }

            char[,] chessBoard = new char[rows, columns];

            Console.WriteLine("Vad ska du använda för typ av svarta pjäser? (t.ex. ♞):");
            char blackSquareChar = Console.ReadLine()[0];

            Console.WriteLine("Vad ska du använda för typ av vita pjäser? (t.ex. ♖):");
            char whiteSquareChar = Console.ReadLine()[0];

            Console.WriteLine("Vart ska pjäsen stå? (Ange i formatet A1, B2, C3 osv.):");
            string position = Console.ReadLine();

            if (position.Length != 2 || !char.IsLetter(position[0]) || !char.IsDigit(position[1]))
            {
                Console.WriteLine("Fel position. Du måste använda formatet A1, B2, osv.");
                return;
            }

            // Konvertera användarens inmatning till rad och kolumn-index
            char columnChar = position[0];
            int row = Int32.Parse(position.Substring(1)) - 1; // Minskar raden med 1 för att matcha array, annars hamnar hjärtat en kolumn ner

            // Placera hjärtat på den angivna positionen
            chessBoard[row, columnChar - 'A'] = '♥';

            // Skriv ut schackbrädet med ett hjärta på den angivna positionen (personlig pjäs)
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (chessBoard[i, j] == '♥')
                    {
                        Console.Write('♥'); // Vår personliga pjäs position
                    }
                    else if ((i + j) % 2 == 0)
                    {
                        Console.Write(blackSquareChar); // Svart pjäs
                    }
                    else
                    {
                        Console.Write(whiteSquareChar); // Vit pjäs
                    }
                }
                Console.WriteLine(); // Ny rad
            }
        }
    }
}
