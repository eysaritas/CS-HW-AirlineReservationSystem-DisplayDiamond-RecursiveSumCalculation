using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayingDiamond
{
	internal class Program
	{
		//Elması oluşturacağımız fonksiyondur.
		static void CreateDiamond(int dimension)
		{
			int temp = dimension;

			//Üst üçgenin boyutuna göre döngüyü satır satır döndürür.
			for (int i = 0; i <= temp; i++)
			{
				//üst üçgende ters üçgen şeklinde boşluklar yazdırır.
				for (int j = 1; j <= (temp - i); j++)
					Console.Write(" ");
				//üst üçgen oluşumu bu döngüde olur.
				for (int k = 1; k <= (2 * i - 1); k++)
					Console.Write("*");
				Console.Write("\n");
			}
			//Alt üçgende boyuta göre döngüyü satır satır döndürür. 
			for (int x = (temp - 1); 1 <= x; x--)
			{
				//alt üçgende düz üçgen şeklinde boşlular yazdırır.
				for (int y = 1; y <= (temp - x); y++) 
					Console.Write(" ");
				//alt üçgen oluşumu bu döngüde olur.
				for(int z = 1; z <= (2 * x - 1); z++)
					Console.Write("*");
				Console.Write("\n");
			}	
		}
		static void Main(string[] args)
		{
			//Elmasın boyutunu atayacağımız dimension değişkenini atıyoruz.
			int dimension = 0;
			
			//Kullanıcıdan bir boyut değeri alıyoruz.
			Console.WriteLine("Enter the dimension of Diamond :");
			dimension = Convert.ToInt32(Console.ReadLine());

			//Boyut değerinin negatif olma durumunu kontrol ediyoruz.
			if (dimension < 0)
				Console.WriteLine("Dimension value can not be zero!");
			else
				CreateDiamond(dimension);
			Console.ReadLine();
		}
	}
}
