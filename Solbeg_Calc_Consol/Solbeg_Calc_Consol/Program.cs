using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Solbeg_Calc_Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите ввод:\n" +
                    "1. Ввод выражения\n" +
                    "2. Поэтапный ввод\n" +
                    "3. Выход");
                int key;
                string keys = Console.ReadLine();
                if (int.TryParse(keys, out key))
                {

                    switch (key)
                    {
                        case 1:
                            while (true)
                            {
                                double final;
                                string result = null;
                                Console.WriteLine("Если хотите выбрать другой тип ввода, введите Back");
                                Console.WriteLine("Введите выражение в виде: 2 числа и между ними оператор");
                                string arg = Console.ReadLine();

                                Again:
                                if (arg == "Back") break;
                                char[] operators = { '+', '-', '*', '/' };

                                int indexOperator = arg.IndexOfAny(operators);
                                if (indexOperator < 0)
                                {
                                    Console.WriteLine("Нету знака оператора");
                                    continue;
                                }
                                char Operator = arg[indexOperator];
                                for (int i = 0; i < arg.Length; i++)
                                {
                                    if (i == indexOperator) break;
                                    result += arg[i];
                                }
                                if (double.TryParse(result, out final))
                                {
                                    result = null;
                                    arg = arg.Substring(indexOperator);
                                    foreach (var i in arg)
                                    {
                                        if (i == '+' | i == '-' | i == '/' | i == '*')
                                            arg = arg.Remove(0, 1);
                                    }
                                    result = arg;
                                    double final2;
                                    if (double.TryParse(result, out final2))
                                    {
                                        switch (Operator)
                                        {
                                            case '+':
                                                final = final + final2;
                                                break;
                                            case '-':
                                                final = final - final2;
                                                break;
                                            case '*':
                                                final = final * final2;
                                                break;
                                            case '/':
                                                final = final / final2;
                                                break;
                                        }
                                        Console.WriteLine($"Ответ: {final}");
                                        Console.WriteLine("Хотите продолжить с этим числом? y/n");
                                        result = Console.ReadLine();
                                        if (result == "y")
                                        {
                                            arg = final.ToString();
                                            Console.WriteLine("Введите оператор и число для продолжения");
                                            arg += Console.ReadLine();
                                            result = null;
                                            goto Again;
                                        }
                                        else if (result == "n") continue;
                                    }
                                    else Console.WriteLine("Вы ввели неверный формат");
                                }
                                else Console.WriteLine("Вы ввели неверный формат");
                            }
                            break;
                        case 2:
                            while (true)
                            {
                                double final, final2;
                                Console.WriteLine("Если хотите выбрать другой тип ввода, введите Back");
                                Console.WriteLine("Введите первое число:");
                                string arg1 = Console.ReadLine();
                                if (arg1 == "Back") break;
                                if (double.TryParse(arg1, out final))
                                {
                                    Again:
                                    Console.WriteLine("Введите второе число:");
                                    string arg2 = Console.ReadLine();
                                    if (arg2 == "Back") break;
                                    if (double.TryParse(arg2, out final2))
                                    {
                                        
                                        Console.WriteLine("Введите оператор:");
                                        string operator1 = Console.ReadLine();
                                        char operator2;
                                        if (char.TryParse(operator1, out operator2))
                                        {
                                            switch (operator2)
                                            {
                                                case '+':
                                                    arg1 = (Convert.ToDouble(arg1) + Convert.ToDouble(arg2)).ToString();
                                                    break;
                                                case '-':
                                                    arg1 = (Convert.ToDouble(arg1) - Convert.ToDouble(arg2)).ToString();
                                                    break;
                                                case '*':
                                                    arg1 = (Convert.ToDouble(arg1) * Convert.ToDouble(arg2)).ToString();
                                                    break;
                                                case '/':
                                                    arg1 = (Convert.ToDouble(arg1) / Convert.ToDouble(arg2)).ToString();
                                                    break;
                                                default:
                                                    Console.WriteLine("Неверный знак оператора");
                                                    break;
                                            }
                                            Console.WriteLine($"Ответ: {arg1}");
                                            Console.WriteLine("Хотите продолжить с этим числом? y/n");
                                            string result = Console.ReadLine();
                                            if (result == "y")
                                            {
                                                goto Again;
                                            }
                                            else if (result == "n") continue;
                                        }
                                        else Console.WriteLine("Вы ввели неверный формат оператора");
                                    }
                                    else Console.WriteLine("Вы ввели неверный формат");
                                }
                                else Console.WriteLine("Вы ввели неверный формат");
                            }
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default: continue;
                    }
                }
                else continue;
            }
        }
    }
}
