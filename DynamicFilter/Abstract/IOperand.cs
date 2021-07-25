using System;
using System.Linq.Expressions;

namespace DynamicFilter.Abstract
{
    public interface IOperand
    {
        string Name { get; }
        LambdaExpression CalculateSql();
        LambdaExpression Calculate();
        string Print();
        IOperand Copy();
    }
}
