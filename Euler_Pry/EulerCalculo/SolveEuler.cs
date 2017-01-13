using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace EulerCalculo
{
    
    public class Problema18
    {
        public long Calcular()
        {
            var archivoDatos = @"C:\Euler\E18.txt";
            //var archivoDatos = @"C:\Euler\E182.txt";

            return SolucionMaximaSuma.CalculaArchivo(archivoDatos);
        }
    }


    public static class SolucionMaximaSuma
    {
        public static int CalculaArchivo(string archivoDatos)
        {
            string datos = File.ReadAllText(archivoDatos);

            return Calcular(datos);
        }

        public static int Calcular(string datos)
        {
            var rows = datos
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line =>
                        line.Split(' ')
                            .Select(token => int.Parse(token))
                            .ToList()
                )
                .ToList();

            return rows.Aggregate(
                new List<int> { 0 },
                (currentMax, nextRow) =>
                {
                    var rowLength = nextRow.Count();
                    return nextRow
                        .Select((cell, index) =>
                                index == 0 ? cell + currentMax[index]
                                : index == rowLength - 1 ? cell + currentMax[index - 1]
                                : Math.Max(cell + currentMax[index - 1], cell + currentMax[index]))
                        .ToList();
                }
                )
                .Max();
        }
    }
}
