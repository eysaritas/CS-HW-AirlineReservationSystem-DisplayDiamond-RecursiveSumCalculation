using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationsSystem
{
	internal class Program
	{
		//Public değikenleri tanımlıyoruz.
		public static bool[] seats;
		public static int totalAssignedFirstClass;
		public static int totalAssignedEconomyClass;
		static void Main(string[] args)
		{
			//Oturma düzeni için bir boyutlu array ve üzerinde işlem için seçilecek değişkeni oluşturuyoruz.
			seats = new bool[11];
			int selectedClass = 0;
			
			//İndex numarasına göre koltuklara false(yani koltukların boş olduğunu) tanımlıyoruz
			for (int i = 0; i <= 10; i++) 
			{
				seats[i] = false;
			}
			//Array içinde dönmek ve işlemler yapabilmek için 1'den 10'a döngüyü kuruyoruz.
			for (int i = 1;i <= 10; i++) 
			{
				Console.WriteLine("Please choose type-1 First Class or type-2 Economy Class");
				
				//Kullanıcıdan First Class mı Economy Class mı olacağına dair 1-2 değerleri alıyoruz.
				//Eğer değer yerine 1-2 dışında başka değer girilmişse döngüye girip sürekli olarak değer almaya devam ediyoruz.
				selectedClass = Convert.ToInt32(Console.ReadLine());
				while (selectedClass < 1 || selectedClass > 2)
				{
					Console.WriteLine("Please just enter the 1- First Class or 2- Economy Class!");
                    selectedClass = Convert.ToInt32(Console.ReadLine());
                }
				//Müşteri First Classtan yana bir talebi varsa First Class için doluluk durumunu kontrol ediyoruz.
				if (selectedClass == 1)
				{
					//Eğer toplam First Class 5'e eşit ise (yani dolu ise) ve Economy Class 5'ten küçük (yani boşsa) First Class dolu uyarısı veriyoruz.
					if (totalAssignedFirstClass == 5 && totalAssignedEconomyClass < 5)
					{
						Console.WriteLine("Sorry, First Class is full! Do you want to get a ticket for Economy Class? Yes-No");
						//Eğer kullanıcı Economy Class istemiyorsa (yani cevabı No ise) "Next plane leaves in 3 hours!" uyarısı verip seats dizisi gezen for döngüsünün sayacını 1 azaltıyoruz.
						if (Console.ReadLine().Equals("No"))
						{
							Console.WriteLine("Next plane leaves in 3 hours!");
							i--;
						}
						//Eğer kullanıcı Economy Class istiyorsa (yani cevabı Yes ise) Economy Class metodunu çağırıyoruz.
						else
						{
							assignEconomyClass();
						}
					}
					//Eğer toplam First Class 5'ten küçük ise (yani boş ise) First Class metodu çağrılır.
					else if (totalAssignedFirstClass < 5)
					{
						assignFirstClass();
					}
				}
                //selectedClass == 2 ise yani Müşterinin Economy Classtan yana bir talebi varsa Economy Class için doluluk durumunu kontrol ediyoruz
                else
                {
					//Eğer toplam Economy Class 5'e eşit ise (yani dolu ise) ve First Class 5'ten küçük (yani boşsa) First Class dolu uyarısı veriyoruz.
					if (totalAssignedEconomyClass == 5 && totalAssignedFirstClass < 5)
					{
						Console.WriteLine("Sorry, Economy Class is full! Do you want to get a ticket for First Class? Yes-No");
						//Eğer kullanıcı First Class istemiyorsa (yani cevabı No ise) "Next plane leaves in 3 hours!" uyarısı verip seats dizisi gezen for döngüsünün sayacını 1 azaltıyoruz.
						if (Console.ReadLine().Equals("No"))
						{
							Console.WriteLine("Next plane leaves in 3 hours!");
							i--;
						}
						//Eğer kullanıcı First Class istiyorsa (yani cevabı Yes ise) First Class metodunu çağırıyoruz.
						else
						{
							assignFirstClass();
						}
					}
					//En son olasılık Economy Class'ın boş olup yerleşme durumudur.
					else
					{
						assignEconomyClass();
					}
				}
            }
			Console.Write("\n");
			Console.WriteLine("Sorry, The plane is full! Next one leaves in 3 hours!");
			Console.ReadLine();
		}
		//First Class uçuşu atama metodu
		public static void assignFirstClass()
		{
            //Temp, bir boş koltuk bulunduğunda döngüden çıkmak için kullanılacaktır.
            bool temp = false;
            //Rand, rastgele sayılar üretmek için kullanılacaktır.
            Random rand = new Random();
			int index = 0;
            //Bu döngü, bir boş koltuk bulana kadar devam eder(temp değeri true ise döngüden çıkar). Eğer rastgele atanan değerdeki indexin koltuğu doluysa döngüye devam edilir.
            while (!temp) 
			{
				temp = true;
				index = rand.Next(1,6);
				if (seats[index] == true)
					temp = false;
			}
			//Eğer rastgele atanan değerdeki indexte koltuk boş ise o değer true yapılır ve Class'ın boş yeri azaltılır(yani total sayıyı arttırdığımızda 5'e göre azalma oluyor). )
			seats[index] = true;
			totalAssignedFirstClass++;
			//Koltuk numarası yazdırılır.
			Console.WriteLine("Assigned seat {0:N0}",index);
		}
        //Economy Class uçuşu atama metodu
        public static void assignEconomyClass()
        {
            //Temp, bir boş koltuk bulunduğunda döngüden çıkmak için kullanılacaktır.
            bool temp = false;
            //Rand, rastgele sayılar üretmek için kullanılacaktır.
            Random rand = new Random();
            int index = 0;
            //Bu döngü, bir boş koltuk bulana kadar devam eder(temp değeri true ise döngüden çıkar). Eğer rastgele atanan değerdeki indexin koltuğu doluysa döngüye devam edilir.
            while (!temp)
            {
                temp = true;
                index = rand.Next(6, 11);
                if (seats[index] == true)
                    temp = false;
            }
            //Eğer rastgele atanan değerdeki indexte koltuk boş ise o değer true yapılır ve Class'ın boş yeri azaltılır(yani total sayıyı arttırdığımızda 5'e göre azalma oluyor). )
            seats[index] = true;
            totalAssignedEconomyClass++;
            //Koltuk numarası yazdırılır.
            Console.WriteLine("Assigned seat {0:N0}", index);
        }
    }
}

