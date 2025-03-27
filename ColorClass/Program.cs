// See https://aka.ms/new-console-template for more information

using System;

class Color
{
    private int red, green, blue, alpha;
    public Color(int red, int green, int blue, int alpha = 255)
    {
        this.red = Math.Clamp(red, 0, 255);
        this.green = Math.Clamp(green, 0, 255);
        this.blue = Math.Clamp(blue, 0, 255);
        this.alpha = Math.Clamp(alpha, 0, 255);
    }

    //get set methods for the variables
    public int Red { get => red; set => red = Math.Clamp(value, 0, 255); }
    public int Green { get => green; set => green = Math.Clamp(value, 0, 255); }
    public int Blue { get => blue; set => blue = Math.Clamp(value, 0, 255); }
    public int Alpha { get => alpha; set => alpha = Math.Clamp(value, 0, 255); }
    
    //A method to get the grayscale value for the color 
    public int GetGrayscale() => (red + green + blue) / 3;
}

class Ball
{
    private int size;
    private Color color;
    private int throwCount;
    public Ball(int size, Color color)
    {
        this.size = size > 0 ? size : 1; 
        this.color = color;
        this.throwCount = 0;
    }

    public void Pop(){size = 0;} 
    public void Throw()
    {
        if (size > 0)
            throwCount++;
    }

    public int GetThrowCount() => throwCount;
}

class Program
{
    static void Main()
    {
        Color redColor = new Color(255, 0, 0);
        Color blueColor = new Color(0, 0, 255);
        Ball ball1 = new Ball(10, redColor);
        Ball ball2 = new Ball(15, blueColor);
        Ball ball3 = new Ball(5, redColor);
        Ball ball4 = new Ball(1, blueColor);
        ball1.Throw();
        ball1.Throw();
        ball2.Throw();
        ball2.Throw();
        ball3.Throw();
        ball3.Throw();
        ball3.Throw();
        ball4.Throw();
        ball1.Pop();
        ball1.Throw();
        Console.WriteLine($"Ball 1 throw count: {ball1.GetThrowCount()}"); 
        Console.WriteLine($"Ball 2 throw count: {ball2.GetThrowCount()}"); 
        Console.WriteLine($"Ball 3 throw count: {ball3.GetThrowCount()}");
        Console.WriteLine($"Ball 4 throw count: {ball4.GetThrowCount()}");
    }
}
