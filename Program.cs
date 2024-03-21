using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var listOfShapes = new List<Shape>
        {
            new Circle { Colour = "Red", Radius = 2.5 },
            new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
            new Circle { Colour = "Green", Radius = 8 },
            new Circle { Colour = "Purple", Radius = 12.3 },
            new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
        };

        XmlSerializer serializerXml = new XmlSerializer(typeof(List<Shape>), new[] { typeof(Circle), typeof(Rectangle) });
        using (TextWriter writer = new StreamWriter("shapes.xml"))
        {
            serializerXml.Serialize(writer, listOfShapes);
        }

        List<Shape> loadedShapesXml;
        using (TextReader reader = new StreamReader("shapes.xml"))
        {
            loadedShapesXml = serializerXml.Deserialize(reader) as List<Shape>;
        }

        // Output the loaded shapes with their areas
        Console.WriteLine("Loading shapes from XML:");
        foreach (Shape item in loadedShapesXml)
        {
            Console.WriteLine($"{item.GetType().Name} is {item.Colour} and has an area of {item.Area}");
        }
    }
}