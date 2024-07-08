using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace EjemploEntity2.Utilities;

public class ControlError
{
    public void LogErrorMetodos(string error, string metodo)
    {
        var ruta = string.Empty;
        var archivo = string.Empty;
        var mensaje = string.Empty;
        DateTime fecha = DateTime.Now;
        try
        {
            ruta = "/Users/jimmyholguin/Desktop/Logs/";
            archivo = $"Log_{fecha.ToString("dd-MM-yyyy")}";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            StreamWriter writ = new StreamWriter($"{ruta}\\{archivo}", true);
            writ.WriteLine($"Se presento una novedad con el metodo: {metodo}, con el error: {error}");
            writ.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
