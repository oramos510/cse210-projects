using System;
public class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    public Fraction(int numerator)
    {
        this.numerator = numerator;
        denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator != 0 ? denominator : throw new ArgumentException("Denominator cannot be zero.");
    }

    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int numerator)
    {
        this.numerator = numerator;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.denominator = denominator;
    }

    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}