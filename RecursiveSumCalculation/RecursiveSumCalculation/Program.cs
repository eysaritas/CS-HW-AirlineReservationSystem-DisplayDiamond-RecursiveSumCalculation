using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveSumCalculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number (between 10 and 99,999): ");
            int number = int.Parse(Console.ReadLine());

            // Giriş aralığını kontrol et
            if (number < 10 || number > 99999)
            {
                Console.WriteLine("Please enter a number between 10 and 99,999.");
            }
            else
            {
                // Basamakların toplamını hesapla ve ekrana yazdır
                int sum = BasamakToplami(number);
                Console.WriteLine("Sum of digits: " + sum);
                Console.ReadLine();
            }

        }
        static int BasamakToplami(int number)
        {
            // Temel durum: Sayı 10'dan küçükse kendisini döndür
            if (number < 10)
            {
                return number;
            }
            else
            {
                // Rekürsif adım: Basamakların toplamını hesapla
                return (number % 10) + BasamakToplami(number / 10);
            }
        }
    }
}
