public class Circle : Shape
{
    public double Radius { get; set; }
    public override double Area => Math.PI * Radius * Radius;
}
