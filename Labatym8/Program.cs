using System;
using System.IO;
using System.Collections.Generic;
using labatym8;

namespace labatym8
{
    class Program
    {

        static string ReversesTheOrderOfCharactersInString(string sourceString)
        {
            char[] stringCharacterArray = sourceString.ToCharArray();

            Array.Reverse(stringCharacterArray);

            return String.Concat(stringCharacterArray);
        }

        static bool ChecksObjectImplementsIFormattableUsingIs(object checkedObject)
        {
            if (checkedObject is IFormattable)
            {
                return true;
            }

            return false;
        }


        static bool ChecksObjectImplementsIFormattableUsingAs(object checkedObject)
        {
            if (checkedObject as IFormattable == null)
            {
                return false;
            }

            return true;
        }

        static bool ExtractingEmailFromDataString(ref string dataString)
        {
            string[] data = dataString.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length == 2)
            {
                dataString = data[1];
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("Лабораторная работа тумакова №8");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 8.1.   -   цифра 1\n" +
                                  "Упражнение 8.2.   -   цифра 2\n" +
                                  "Упражнение 8.3.   -   цифра 3\n" +
                                  "Упражнение 8.4.   -   цифра 4\n" +
                                  "Домашнее задание 8.1.  -   цифра 5\n" +
                                  "Домашнее задание 8.2   -   цифра 6\n" +
                                  "Выйти из программы     -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Упражнение 8.1");

                        BankAccount firstBankAccount = new BankAccount(AccountType.Текущий_счет);
                        BankAccount secondBankAccount = new BankAccount(AccountType.Текущий_счет);
                        bool putMoneyResult, transferringMoneyResult;

                        putMoneyResult = firstBankAccount.PutMoneyIntoAccount(500000.55M);
                        putMoneyResult &= secondBankAccount.PutMoneyIntoAccount(100000.87M);

                        if (putMoneyResult)
                        {
                            Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                              $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");

                            transferringMoneyResult = firstBankAccount.TransferringMoney(secondBankAccount, 50000.87M);

                            if (transferringMoneyResult)
                            {
                                Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                                  $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");
                            }
                            else
                            {
                                Console.WriteLine("На банковском счету недостаточно средств или вы неверно ввели сумму");
                            }

                            transferringMoneyResult = secondBankAccount.TransferringMoney(firstBankAccount, 500000);

                            if (transferringMoneyResult)
                            {
                                Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                                  $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");
                            }
                            else
                            {
                                Console.WriteLine("На банковском счету недостаточно средств или вы неверно ввели сумму");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы неверно ввели сумму");
                        }

                        Console.Write("нажмите на любую кнопку");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Упражнение 8.2");

                        string userString, newString;

                        Console.Write("Введите строку: ");
                        userString = Console.ReadLine();

                        newString = ReversesTheOrderOfCharactersInString(userString);
                        Console.Write($"Из строки {userString} получилась строка: {newString}");

                        Console.Write("нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Упражнение 8.3");

                        string path;
                        string[] fileContents;

                        Console.Write("Введите путь к файлу: ");
                        path = Console.ReadLine();

                        if (File.Exists(path))
                        {
                            fileContents = File.ReadAllLines(path);

                            for (int i = 0; i < fileContents.Length; i++)
                            {
                                File.AppendAllText(path + "/../newFile.txt", fileContents[i].ToUpper() + Environment.NewLine);
                            }

                            Console.WriteLine("Обработка прошла успешно. Рядом с исходным файлом добавлен новый");
                            Console.Write("нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Данного файла не существует");
                            Console.Write("нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Упражнение 8.4");

                        ClassImplementingIFormattables firstObject = new ClassImplementingIFormattables();
                        BankAccount secondObject = new BankAccount(AccountType.Текущий_счет);

                        if (ChecksObjectImplementsIFormattableUsingIs(firstObject))
                        {
                            Console.WriteLine("Объект реализует интерфейс System.IFormattable");
                        }
                        else
                        {
                            Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
                        }

                        if (ChecksObjectImplementsIFormattableUsingIs(secondObject))
                        {
                            Console.WriteLine("Объект реализует интерфейс System.IFormattable");
                        }
                        else
                        {
                            Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
                        }

                        if (ChecksObjectImplementsIFormattableUsingAs(firstObject))
                        {
                            Console.WriteLine("Объект реализует интерфейс System.IFormattable");
                        }
                        else
                        {
                            Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
                        }

                        if (ChecksObjectImplementsIFormattableUsingAs(secondObject))
                        {
                            Console.WriteLine("Объект реализует интерфейс System.IFormattable");
                        }
                        else
                        {
                            Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
                        }

                        Console.Write("нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Домашнее задание 8.1");

                        bool extractingResult;
                        string[] dataFile = File.ReadAllLines("ProgramFiles/DataFile.txt");

                        for (int i = 0; i < dataFile.Length; i++)
                        {
                            string dataString = dataFile[i];
                            extractingResult = ExtractingEmailFromDataString(ref dataString);
                            if (extractingResult)
                            {
                                File.AppendAllText("ProgramFiles/EmailFile.txt", dataString + Environment.NewLine);
                            }
                            else
                            {
                                Console.WriteLine("Проверьте входной файл!");
                                break;
                            }
                        }

                        Console.Write("нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Домашнее задание 8.2");

                        Song firstSong = new Song("За Мазу-Рашу!\r\n", "The Starkillers");
                        Song secondSong = new Song("Я хочу сниматься в порно\r\n ", "The Starkillers", firstSong);
                        Song thirdSong = new Song("Пусть твоя могила...\r\n ", "The Starkillers", secondSong);
                        Song fourthSong = new Song("Наши демоны нас берегут\r\n", "The Starkillers", thirdSong);

                        List<Song> songList = new List<Song> { firstSong, secondSong, thirdSong, fourthSong };

                        foreach (Song song in songList)
                        {
                            Console.WriteLine(song.Title);
                        }

                        if (firstSong.Equals(secondSong))
                        {
                            Console.WriteLine("\nПесни равны");
                        }
                        else
                        {
                            Console.WriteLine("\nПесни неравны");
                        }

                        Console.Write("нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Вы вышли из программы");
                        tasksEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такого задания нет");
                        break;
                }
            } while (!tasksEnd);
        }
    }
}