using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Atm atm1 = new Atm(10000, 10000, 10000, 10000, "Лень писать что-то - вы крч на месте^^");
            Console.WriteLine("Вас приветствует банкомат компании ООО Рандом Крафт");
            atm1.NameImputControl();
            Console.WriteLine("Вас приветствует банкомат компании ООО Рандом Крафт \n " +
                              "Пожалуйста, выберите опцию. Нажмите: \n " +
                              "1 - Чтобы снять валюту с вашего счета. \n " +
                              "2 - Чтобы обменять валюту. \n " +
                              "3 - Пополнить счет \n " +
                              "4 - Увидеть адрес текущего банкомата.");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            
  
            switch (userChoice)
            {
                case 1:
                    atm1.TakeCash();

                    break;
                case 2:
                    atm1.CashExchange();
                    break;
                case 3:
                    atm1.PutCash();
                    break;
                case 4:
                    Console.WriteLine("Адрес: {0}", atm1.Address);
                    break;
                default:
                    Console.WriteLine("Что-то случилось...");
                    break;
            }
            Console.ReadKey();
        }
    }
}
