using System;
using System.Diagnostics;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        if (bottom == 0)
            throw new ArgumentException("Denominator can not be zero.");

        this._top =top;
        this._bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }
    public void SetTOp(int _top)
    {
        this._top = _top;
    }
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottomn(int bottom)
    {
        if (bottom == 0)
            throw new ArgumentException("Denominator can not be zero.");

        this._bottom =bottom;
    }
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}