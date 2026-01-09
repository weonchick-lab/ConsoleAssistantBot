using System;
using System.IO;

namespace AsistentBot
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Якщо ти хочеш начати дію веди слово 'Старт':"); //Питаємо в користувача начинати роботу чи ні
            string? user = Console.ReadLine(); 

            if (user.ToLower() == "старт") //Даєм логіку Старт
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Привіт я твій ассистент бот. Веди нижче своє ім'я!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; //Даємо лагогіку. Якщо користувач не веде
                Console.WriteLine("Якщо ні, то ні :(");
                Environment.Exit(0);
                Console.ResetColor();
            }

            string[] userSave = new string[4];
            bool profile = false;


            if (File.Exists("log.txt"))
            {
                string[] daniZFailu = File.ReadAllLines("log.txt");

                if(daniZFailu.Length >= 3)
                {
                    userSave[0] = daniZFailu[0];
                    userSave[1] = daniZFailu[1];
                    userSave[2] = daniZFailu[2];

                    System.Console.WriteLine($"Привіт {userSave[0]} давно не бачились :)");
                }
                else
                {
                    System.Console.WriteLine("Файл пошкоджено!");
                    System.Console.WriteLine("Давай заново зарегеструємось");

                    profile = false;
                }

            }
            else
            {
                System.Console.WriteLine("Ти тут новенький? Давай зарегеструємось");

                while (!profile)
                {
                    Console.ForegroundColor = ConsoleColor.Gray; 
                    Console.WriteLine("Ведіть своє імя:"); //Просим користувача ввести ім'я
                    userSave[0] = Console.ReadLine();

                    Console.WriteLine("Ведіть своє вік:"); //Вік так само
                    userSave[1] = Console.ReadLine();

                    Console.WriteLine("Ваше хобі:"); //Хобі теж саме
                    userSave[2] = Console.ReadLine();

                    Console.WriteLine($"Ваше ім'я: {userSave[0]}"); //Це все виводим. Ім'я, вік, хобі.
                    Console.WriteLine($"Ваш вік: {userSave[1]}");
                    Console.WriteLine($"Ваше хобі: {userSave[2]}");

                    System.Console.WriteLine("Ви хочите зберегти дані? Ведіть Так/Ні: "); //Робим логіку зберегти зміні чи ні!
                    if (Console.ReadLine()?.ToLower() == "так")
                    {
                        System.Console.WriteLine("Ок будем знакомі");
                        profile = true;
                        File.AppendAllText("log.txt", userSave[0] + Environment.NewLine); //Додаємо все в txt файлик
                        File.AppendAllText("log.txt", userSave[1] + Environment.NewLine);
                        File.AppendAllText("log.txt", userSave[2] + Environment.NewLine);
                    }   
                    else
                    {
                        Console.WriteLine("Окей, давай заповнимо ще раз.");
                    }

                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray; 
                Console.WriteLine("---Головне меню---"); //Виводимо користувачу інформацію що, куди жати
                Console.WriteLine("1 - Ваш профіль");
                Console.WriteLine("2 - Аніґдоти");
                Console.WriteLine("3 - Гра 'Вгадай число'");
                Console.WriteLine("4 - Замітки");
                Console.WriteLine("5 - Конвертатор валют");
                Console.WriteLine("0 - Вихід");

                string menuUser = Console.ReadLine();

                if(menuUser == "0") //Логіка виходу
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("До зустрічі!");
                    Console.ResetColor();
                    break;
                }

                switch (menuUser) //Даємо йому логіку
                {
                    case "1": //Якщо 1, то профіль
                        Profile(userSave);
                        break; 
                    case "2": //Якщо 2, то Анігдоти
                        Anigdot();
                        break;
                    case "3": // Якщо 3, то гра
                        PlayNumber();
                        break;
                    case "4": // Якщо 4, то заметки
                        Zametka();
                        break; 
                    case "5": // Якщо 5, то Конвертатор
                        ConvertatorValut();
                        break;  
                }

                Console.ResetColor();
            }
        }

        static void Profile(string[] userSave) //Просто передаємо масив фінкції 
        {
            Console.ForegroundColor = ConsoleColor.Cyan; //Виводимо
            Console.WriteLine("---Ваш профіль---");
            Console.WriteLine($"Ваше ім'я: {userSave[0]}"); 
            Console.WriteLine($"Ваш вік: {userSave[1]}");
            Console.WriteLine($"Ваше хобі: {userSave[2]}");
            Console.WriteLine("---------------------");
            Console.ResetColor();
        }

        static void Anigdot() //Аніґдоти теж окремо!
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Random random = new Random();
            byte randomAnigdot = (byte)random.Next(0, 5); //Генеруєм число

            //І від числа яке буде згенероване буде анігдот
            if(randomAnigdot == 1) // Якщо випаде 1, то виводити атекий інформація
            {
                System.Console.WriteLine("-------------------------------------------------------------------");
                System.Console.WriteLine("програміст бачить пачку масла 72% і думає, що скоро 'завантажиться'");
                System.Console.WriteLine("-------------------------------------------------------------------");
            }
            else if(randomAnigdot == 2) // Якщо випаде 2, то виводити атекий інформація
            {
                System.Console.WriteLine("--------------------------------------");
                System.Console.WriteLine("Немає багів, є незадокументовані фічі.");
                System.Console.WriteLine("--------------------------------------");   
            }
            else if(randomAnigdot == 3) // Якщо випаде 3, то виводити атекий інформація
            {
                System.Console.WriteLine("-------------------------------------------------------------------------------");
                System.Console.WriteLine("Без вимог і дизайну програмування — це мистецтво додавати баги в порожній файл.");
                System.Console.WriteLine("-------------------------------------------------------------------------------");
            }
            else if(randomAnigdot == 4) // Якщо випаде 4, то виводити атекий інформація
            {
                System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Як програміст помер у душі? Він прочитав інструкції на пляшці шампуню: Збити. Змити. Повторити.");
                System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            }
            else if(randomAnigdot == 5) // Якщо випаде 5, то виводити атекий інформація
            {
                System.Console.WriteLine("---------------------------------------------------------------------------------");
                System.Console.WriteLine("-А в мене вчора один за п'ять хвилин сервер зламав. - Він що, хакер? - Він баран!");
                System.Console.WriteLine("---------------------------------------------------------------------------------");
            }
            else // Інакше такий анігдом (навсякий пожарний)
            {
                System.Console.WriteLine("-------------------------------------------------------------------------");
                System.Console.WriteLine("Є 10 типів людей: які розуміють двійкову систему числення і не розуміють.");
                System.Console.WriteLine("-------------------------------------------------------------------------");                
            }
            Console.ResetColor();
        }

        static void PlayNumber() //Створюємо окрему функцію для випадкового число, щоб код був чистішим 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Random random = new Random(); //Генеруємо випадкове число
            byte randomByte = (byte)random.Next(1, 11);

            for(byte i = 0; i < 5; i++) //Даємо користувачу 5 спроб
            {
                Console.WriteLine("Ведіть число від 0 до 10:");
                byte userInput = Convert.ToByte(Console.ReadLine());

                if(userInput == randomByte) //Перевіряємо чи вгадав користувач
                {
                    Console.WriteLine("Ви вгадали!");
                    break;
                    
                }
                else if(userInput < randomByte)
                {
                    Console.WriteLine("Ваше число менше за загадане."); //Підказка для користувача
                }
                else
                {
                    Console.WriteLine("Ваше число більше за загадане."); //Ще одна підказка для користувача
                }
            }
            Console.ResetColor();
        }

        static void Zametka() 
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("Ведіть свію замітку: "); //Просимо користувача вести замітку
            string zametka = Console.ReadLine();

            File.AppendAllText("zametka.txt", zametka + Environment.NewLine); // Додаєму нашу інформацію, і записуємо її в txt файл

            string vuvod = File.ReadAllText("zametka.txt"); //Читаємо наш файл

            System.Console.WriteLine("---Ваші замітки---"); //Виволимо нашу інформацію з файла
            System.Console.WriteLine(vuvod);
            Console.ResetColor();
        }

        static void ConvertatorValut()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("Ведіть суму в гривнях");
            double uan = double.Parse(Console.ReadLine());

            double kurs = 43.19;

            double usd =  uan / kurs;

            System.Console.WriteLine($"Ваші {usd} доларів");
            Console.ResetColor();
        }      
    }
}