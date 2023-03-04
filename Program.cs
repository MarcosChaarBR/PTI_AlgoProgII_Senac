//Disciplina: Algoritmos e Programação II
//Aluno: MARCOS ROBERTO NUNES CHAAR

using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Informe a quantidade de números inteiros que formarão o vetor: ");
        int quantidadeElementos = 0;

        while (!(int.TryParse(Console.ReadLine(), out quantidadeElementos) && (quantidadeElementos > 0)))
            Console.Write("A quantidade tem que ser maior que 0, informe novamente a quantidade: ");

        Console.WriteLine();

        int[] elementos = new int[quantidadeElementos];
        int valorDigitado = 0;

        for (int i = 0; i < quantidadeElementos; i++)
        {
            Console.Write("Informe o valor para o item {0} : ", i + 1);
            while (!Int32.TryParse(Console.ReadLine(), out valorDigitado))
            {
                Console.Write("Este valor não é um número, informe um número inteiro para o item: ");

            }

            elementos[i] = valorDigitado;

        }

        Console.WriteLine();

        for (int i = 0; i < elementos.Length; i++)
        {
            int posicao = i + 1;
            Console.WriteLine("O item na posição {0} (Índice: {1}) tem o valor: {2}", posicao, i, elementos[i]);
        }


        if (elementos.Length > 1)
        {
            calculaMaiorDiferenca(elementos);
            ordemCrescente(elementos);

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("O vetor tem somente 1 item e não é possível calcular:\n - A maior diferença entre dois elementos\n - Se o vetor esta em ordem crescente");
        }
    }

    static void calculaMaiorDiferenca(int[] elementos)
    {
        int[] itens = new int[elementos.Length];
        for (int i = 0; i < elementos.Length; i++)
        {
            itens[i] = elementos[i];
        }


        bool mudou = true;
        int ultimo = itens.Length - 1;
        int ultimo_temp = itens.Length - 1;

        while (mudou)
        {
            int pos = 0;
            mudou = false;
            int temp = 0;

            while (pos < ultimo)
            {
                if (itens[pos] > itens[pos + 1])
                {

                    temp = itens[pos];
                    itens[pos] = itens[pos + 1];
                    itens[pos + 1] = temp;
                    mudou = true;
                    ultimo_temp = pos;

                }

                pos++;
            }

            ultimo = ultimo_temp;
        }

        Console.WriteLine(" ");
        int diferenca = itens[itens.Length - 1] - itens[0];

        Console.WriteLine("A maior diferença entre dois itens distintos é {0}, que é a diferença entre os números {1} e {2}", diferenca, itens[itens.Length - 1], itens[0]);


    }


    static void ordemCrescente(int[] elementos)
    {
        int pos = 0;
        int ultimo = elementos.Length - 1;
        bool ordemCrescente = true;
        bool itensIguais = false;

        while (pos < ultimo)
        {

            if (elementos[pos] > elementos[pos + 1])
            {
                ordemCrescente = false;
                break;
            }

            pos++;
        }

        // Verifica duplicidade
        for (int i = 1; i < elementos.Length; i++)
        {
            if (elementos[0] == elementos[i])
            {
                Console.WriteLine(elementos[0] + " " + elementos[i]);
                itensIguais = true;
            }
        }

        Console.WriteLine();

        if (ordemCrescente && !itensIguais)
        {
            Console.WriteLine("O vetor está em ordem crescente. TRUE");
        }
        else if (itensIguais)
        {
            Console.WriteLine("O vetor tem números repetidos e não é possível verificar se a ordem é crescente ou não.");
        }
        else
        {
            Console.WriteLine("O vetor não está em ordem crescente. FALSE");
        }

    }

}

