using System;


namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // representa um valor que não é um número e resulta quando uma operação aritmética é definida
            switch (op) //Usa a declaração switch para fazer o cálculo
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0) //pede ao usuário para inserir um número diferente de 0
                    {
                        result = num1 / num2;
                    }
                    break;
                default: //retorna um texto para uma entrada incorreta
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Calculadora em C#");
            Console.WriteLine(".................\n");

            while (!endApp)
            {
                //declara as variáveis e deixa elas vazias
                string numInput1;
                string numInput2;
                double result = 0;

                Console.Write("Digite um número e pressione Enter: ");
                numInput1 = Console.ReadLine();
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1)) //Converte o valor de string e devolve em double. Observação: Exclamação significa not, ou negação de uma lógica
                {
                    Console.Write("Essa não é uma entrada valida. Por favor, insira um número inteiro ");
                    numInput1 = Console.ReadLine();
                }
                Console.Write("Digite outro número e pressione Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2)) ;
                {
                    Console.Write("Essa não é uma entrada valida. Por favor, insira um número inteiro ");
                }
                //Pede para o usuário escolher uma operação.
                Console.WriteLine("Escolha uma operação da lista abaixo:");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result)) //se os valores não resultarem em um número, retorna um erro matemático
                    {
                        Console.WriteLine("Essa operação resultará em um erro.\n");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", result);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Oh, não! Ocorreu um problema durante o cálculo.\n - Detalhes: " + e.Message);
                }
                Console.WriteLine("........................\n");
                //espera por uma esposta do usuário para fechar o app
                Console.WriteLine("Pressione 'f' e Enter para fechar o app. Ou qualquer letra e Enter para continuar: ");
                if (Console.ReadLine() == "f") endApp = true;

                Console.WriteLine("\n"); //Espaçamento para continuação
            }
            return;

        }
    }
}
