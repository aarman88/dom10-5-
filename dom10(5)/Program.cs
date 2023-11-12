using System;
using System.IO;

public interface IStorable
{
    void SaveState(string filePath);
    void LoadState(string filePath);
}

public class AdvancedCalculator : ICalculatable, IStorable
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Деление на ноль недопустимо.");
        }
        return a / b;
    }

    public double Power(double baseNumber, double exponent)
    {
        return Math.Pow(baseNumber, exponent);
    }

    public double SquareRoot(double number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Извлечение корня из отрицательного числа недопустимо.");
        }
        return Math.Sqrt(number);
    }

    public void SaveState(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("AdvancedCalculator State");
            // Здесь можно сохранить состояние калькулятора, если необходимо.
        }
    }

    public void LoadState(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string stateHeader = reader.ReadLine();
                if (stateHeader != "AdvancedCalculator State")
                {
                    Console.WriteLine("Неверный формат файла состояния калькулятора.");
                    return;
                }

                // Здесь можно восстановить состояние калькулятора, если необходимо.
            }
        }
        else
        {
            Console.WriteLine("Файл состояния калькулятора не найден.");
        }
    }

    public void PerformCalculation()
    {
        // Реализация метода PerformCalculation, как в предыдущем ответе.
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Расширенный калькулятор:");
        AdvancedCalculator advancedCalculator = new AdvancedCalculator();
        advancedCalculator.PerformCalculation();

        Console.WriteLine("Сохранение состояния калькулятора...");
        advancedCalculator.SaveState("calculator_state.txt");
        Console.WriteLine("Состояние калькулятора сохранено.");

        Console.WriteLine("Загрузка состояния калькулятора...");
        advancedCalculator.LoadState("calculator_state.txt");
        Console.WriteLine("Состояние калькулятора загружено.");
    }
}
