using System;
using System.Collections.Generic;

namespace SequenciaFibonnaci
{
    class Program
    {
        static void Main(string[] args)
        {
            int UltimoNumero = 1;
            int PenultimoNumero = 0;

            var sequenciaFibonnaci = new List<int> { 1, 1 };

            while (sequenciaFibonnaci.Count < 30)
            {
                var proximoElemento = sequenciaFibonnaci[UltimoNumero] + sequenciaFibonnaci[PenultimoNumero];

                sequenciaFibonnaci.Add(proximoElemento);

                UltimoNumero++;
                PenultimoNumero++;
            }

            Console.WriteLine("Os Trinta Primeiros elementos da Sequencia de Fibonnaci São: ");

            foreach (var elemento in sequenciaFibonnaci)
            {
                Console.WriteLine(elemento);
            }
        }
    }
}
