using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Atm
    {
        public static double ExchangeRateEuro { get; set; } //курс евро/лей

        public static double ExchangeRateUsd { get; set; } //курс доллар/лей

        public static double ExchangeRateRub { get; set; } //курс рубль/лей


        public string Address { get; set; } //автоматическое св-во; адрес банкомата
        public string PersonalSurnameame { get; set; } //автоматическое св-во; Фамилия текущего пользователя
        public string PersonalName { get; set; } //автоматическое св-во; Имя текущего пользователя
        public string PersonalMiddlename { get; set; } //автоматическое св-во; Отчество текущего пользователя
        public double CashInNowEuro { get; set; } //автоматическое св-во; К-во наличности в банкомате Евро
        public double CashInNowUsd { get; set; } //автоматическое св-во; К-во наличности в банкомате Доллары
        public double CashInNowRub { get; set; } //автоматическое св-во; К-во наличности в банкомате Рубли
        public double CashInNowMdl { get; set; } //автоматическое св-во; К-во наличности в банкомате Леи

        //Статический конструктор
        static Atm()
        {
            ExchangeRateEuro = 20;
            ExchangeRateUsd = 18;
            ExchangeRateRub = 0.3;
        }

        public Atm(double cashInNowEuro, double cashInNowUsd, double cashInNowRub, double cashInNowMdl, string address)
        {
            CashInNowEuro = cashInNowEuro;
            CashInNowMdl = cashInNowMdl;
            CashInNowRub = cashInNowRub;
            CashInNowUsd = cashInNowUsd;
            Address = address;
        }
        public Atm()
        {
            Address = "туево-кукуево 6/5";
            CashInNowEuro = 100000;
            CashInNowMdl = 100000;
            CashInNowRub = 100000;
            CashInNowUsd = 100000; 
        }
        //Метод ввода ФИО пользователя
        public void NameInput()
        {
                Console.WriteLine("Введите по очереди ваши ФИО");
                PersonalSurnameame = Console.ReadLine();
                PersonalName = Console.ReadLine();
                PersonalMiddlename = Console.ReadLine();
                Console.WriteLine("Вы ввели: {0} {1} {2}", PersonalSurnameame, PersonalName, PersonalMiddlename);
                Console.WriteLine("Если данные верны, нажмите 1, если нет - 0 и введите данные заново");
                /*здесь просто ввод ФИО пользователя*/
        }

        public void NameImputControl() //Получает ФИО и проверяет на правильность
        {
            int userAnswer;
            do
            {
                NameInput();
                //ответ пользователя - верны ли данные
                userAnswer = Convert.ToInt32(Console.ReadLine());
                while (userAnswer != 1 && userAnswer != 0)
                {
                    Console.WriteLine("Вы ввели недопустимое значение - повторите ввод");
                    userAnswer = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
            } while (userAnswer == 0);
        }
        
        //функция ввода адреса банкомата
        public void MainAddressSet()
        {
            int correctAddresUserAnswer;
            do
            {
                Console.WriteLine("Вы используете административную ф-ю ввода адреса.\n Пожалуйста, укажите новый адрес");
                Address = Console.ReadLine();
                Console.WriteLine("Вы ввели: {0}\n Если данные не верны, нажмите 0 и повторите ввод", Address);
                correctAddresUserAnswer = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (correctAddresUserAnswer == 0);
        }
        //Функция снятия денег со счета
        public void TakeCash()
        {
            Console.WriteLine("Пожалуйста, введите необходимую сумму");
            double neededCash = Convert.ToDouble(Console.ReadLine());
            if (neededCash <= CashInNowMdl)
            {
                CashInNowMdl -= neededCash;
                Console.WriteLine("Пожалуйста, возьмите ваши деньги");
            }
            else
            {
                Console.WriteLine("В банкомате нет требуемой суммы. Попробуйте снять деньги в другом банкомате.");
            }

        }
        //методы проверки наличия денег в банкомате
        private void CashInMdlCheck() //MDL
        {
            Console.WriteLine(CashInNowMdl > 0
                ? "1 - MDL"
                : "На текущий момент в наличии отсутствует данная валюта (MDL)");
        }

        private void CashInEuroCheck() //EUR
        {
            Console.WriteLine(CashInNowEuro > 0
                ? "2 - EUR"
                : "На текущий момент в наличии отсутствует данная валюта (EUR)");
        }

        private void CashInUsdCheck() //USD
        {
            Console.WriteLine(CashInNowUsd > 0 
                ? "3 - USD"
                : "На текущий момент в наличии отсутствует данная валюта (USD)");
        }
        private void CashInRubCheck() //Rub
        {
            Console.WriteLine(CashInNowRub > 0
                ? "4 - RUB"
                : "На текущий момент в наличии отсутствует данная валюта (RUB)");
        }

        public int ExchangingValute() //Предлагает указать нужную валюту
        {
            CashInMdlCheck();
            CashInEuroCheck();
            CashInUsdCheck();
            CashInRubCheck();
            return Convert.ToInt32(Console.ReadLine());
        }

        //метод обена валюты
        public double CashExchange()
        {
            Console.WriteLine("Нажмите соответствующую обмениваемой валюте цифру:");
            int mainValuteType = ExchangingValute(); //Тип валюты на руках у пользователя
            Console.Clear();
            Console.WriteLine("Нажмите соответствующую требуемой валюте цифру:");
            int neededValuteType = ExchangingValute();
            Console.Clear();
            Console.WriteLine("Сколько денег вы хотите обменять?");
            double moneyCount = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            switch (mainValuteType)
            {
                case 1:
                    switch (neededValuteType)   //если осн валюта леи
                    {
                        case 2:
                           Console.WriteLine("MDL -> EUR по текущему курсу = {0} Евро", MdlToEurConvert(moneyCount)); 
                            break;
                        case 3:
                            Console.WriteLine("MDL -> USD по текущему курсу = {0} $", MdlToUsdConvert(moneyCount));
                            break;
                        case 4:
                            Console.WriteLine("MDL -> Rub по текущему курсу = {0} Р.", MdlToRubConvert(moneyCount));
                            break;
                        default :
                            Console.WriteLine("Что-то произошло...");
                                break;
                    }
                    break;
                case 2:
                    switch (neededValuteType) //если основная валюта евро
                    {
                        case 1:
                            Console.WriteLine("EUR -> MDL по текущему курсу = {0} Лей", EurToMdlConvert(moneyCount));
                            break;
                        case 3:
                            Console.WriteLine("EUR -> USD по текущему курсу = {0} $", EurToMdlConvert(MdlToUsdConvert(moneyCount)));
                            break;
                        case 4:
                            Console.WriteLine("EUR -> RUB по текущему курсу = {0} P.", EurToMdlConvert(MdlToRubConvert(moneyCount)));
                            break;
                        default:
                            Console.WriteLine("Что-то произошло...");
                            break;
                    }
                    break;
                case 3:
                    switch (neededValuteType) //если основная валюта доллары
                    {
                        case 1:
                            Console.WriteLine("USD -> MDL по текущему курсу = {0} Лей", UsdToMdlConvert(moneyCount));
                            break;
                        case 2:
                            Console.WriteLine("USD -> EUR по текущему курсу = {0} Евро", UsdToMdlConvert(MdlToEurConvert(moneyCount)));
                            break;
                        case 4:
                            Console.WriteLine("USD -> RUB по текущему курсу = {0} P.", UsdToMdlConvert(MdlToRubConvert(moneyCount)));
                            break;
                        default:
                            Console.WriteLine("Что-то произошло...");
                            break;
                    }
                    break;
                case 4:
                    switch (neededValuteType) //если основная валюта евро
                    {
                        case 1:
                            Console.WriteLine("RUB -> MDL по текущему курсу = {0} Лей", RubToMdlConvert(moneyCount));
                            break;
                        case 2:
                            Console.WriteLine("RUB -> EUR по текущему курсу = {0} Евро", RubToMdlConvert(MdlToEurConvert(moneyCount)));
                            break;
                        case 3:
                            Console.WriteLine("RUB -> USD по текущему курсу = {0} $", RubToMdlConvert(MdlToUsdConvert(moneyCount)));
                            break;
                        default:
                            Console.WriteLine("Что-то произошло...");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Что-то спроизошло...");
                    break;
            }

            return 0;
        }
        //метод eur -> mdl                                                                  //
        private double EurToMdlConvert (double euroCount)                                   //Методы обмена валюты из одной в другую
        {                                                                                   //
            return euroCount*ExchangeRateEuro;
        }
        // mdl -> eur
        private double MdlToEurConvert(double mdlCount)
        {
            return mdlCount/ExchangeRateEuro;
        }
        //usd -> mdl
        private double UsdToMdlConvert(double usdCount)
        {
            return usdCount*ExchangeRateUsd;
        }
        //mdl -> usd
        private double MdlToUsdConvert(double mdlCount)
        {
            return mdlCount/ExchangeRateUsd;
        }
        //rub -> mdl
        private double RubToMdlConvert(double rubCount)
        {
            return rubCount*ExchangeRateRub;
        }
        //mdl - > rub
        private double MdlToRubConvert(double mdlCount)
        {
            return mdlCount/ExchangeRateRub;
        }
        //метод отвечающий за пополнение счета
        public void PutCash()
        {
            Console.WriteLine("Валюта зачиляется только в леях, выберите вашу валюту и она будет зачисленна на ваш счет по текущему курсу");
            int userChoice = ExchangingValute();
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Введите сумму");
                    Console.ReadLine();
                    Console.WriteLine("Сумма зачислена");
                    break;
                case 2:
                    Console.WriteLine("Введите сумму");
                    Console.WriteLine("Сумма зачислена по текущему курсу - {0}", EurToMdlConvert(Convert.ToDouble(Console.ReadLine())));
                    break;
                case 3:
                    Console.WriteLine("Введите сумму");
                    Console.WriteLine("Сумма зачислена по текущему курсу - {0}", UsdToMdlConvert(Convert.ToDouble(Console.ReadLine())));
                    break;
                case 4:
                    Console.WriteLine("Введите сумму");
                    Console.WriteLine("Сумма зачислена по текущему курсу - {0}", RubToMdlConvert(Convert.ToDouble(Console.ReadLine())));
                    break;
                default:
                    Console.WriteLine("Что-то случилось...");
                    break;
            }
        }
    }
}
