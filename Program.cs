using System;
using System.Text.RegularExpressions;
using Barcoder.Code39;
using Barcoder.Renderer.Image;
using Barcoder.Renderer.Svg;
using Barcoder.Renderers;

/// <summary>
/// Use / dotnet run "TEST" / to generate a Code 39 Extended barcode for the string "TEST" (output PNG).
/// Use / dotnet run "TEST" -svg / to generate a Code 39 Extended barcode for the string "TEST" (output SVG).
/// Code using the Barcoder library: https://github.com/huysentruitw/barcoder
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Erreur: Veuillez fournir une chaîne à vérifier.");
            Environment.Exit(1);
        }

        string input = args[0];
        bool useSvgRenderer = args.Length > 1 && args[1] == "-svg";

        if (!IsValidCode39Extended(input))
        {
            Console.WriteLine("Erreur: La chaîne fournie contient des caractères non valides pour Code 39 Extended.");
            Environment.Exit(1);
        }

        string outputDirectory = "output";
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        var barcode = Code39Encoder.Encode(input, false, true);
        
        IRenderer renderer;

        if (useSvgRenderer)
        {
            var svgOptions = new SvgRendererOptions
            { 
                // This property is not available in this version of the library but it present on barcoder 3.1.0 (not still available on NuGet) but not on 3.0.0
                // https://github.com/huysentruitw/barcoder/tags
                // BarHeightFor1DBarcode = 100,
                IncludeEanContentAsText = true 
            };
            renderer = new SvgRenderer(svgOptions);
        }
        else
        {
            var imageOptions = new ImageRendererOptions 
            {
                ImageFormat = ImageFormat.Png, 
                BarHeightFor1DBarcode = 100,
                IncludeEanContentAsText = true

            };
            renderer = new ImageRenderer(imageOptions);
        }
        using (var stream = new MemoryStream())
        using (var reader = new StreamReader(stream))
        {
            renderer.Render(barcode, stream);
            stream.Position = 0;

            string extension;
            string filename = Path.Combine(outputDirectory, $"barcode_{Guid.NewGuid()}");

            if (useSvgRenderer)
            {
                string output = reader.ReadToEnd();
                extension = "svg";
                filename += $".{extension}";
                File.WriteAllText(filename, output);
            }
            else
            {
                extension = "png";
                filename += $".{extension}";
                File.WriteAllBytes(filename, stream.ToArray());
            }
        }
    }

    static bool IsValidCode39Extended(string input)
    {
        string pattern = @"^([A-Z0-9\-\.\/\$\+\%\* ]|[\/\+\%][A-Z])+$";
        return Regex.IsMatch(input, pattern);
    }
}