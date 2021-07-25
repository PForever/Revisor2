﻿using DynamicFilter.Abstract;
using DynamicFilter.Abstract.Filters;
using DynamicFilter.Factories;
using System;
using System.Linq.Expressions;

namespace DynamicFilter.Operands.Parametrized
{
    public class LessFilter : IParameterizedFilterOperand
    {
        public object Value { get; set; }
        public IFilterData Data { get; set; }
        public string DisplayValue { get; set; }

        public string Name => $"{Data.Print()} < {DisplayValue ?? Value?.ToString() ?? "null"}";

        public LessFilter(IFilterData data)
        {
            Data = data;
        }

        public LambdaExpression CalculateSql()
        {
            return FilterBuilder.LessPredicate(Data, Value);
        }

        public LambdaExpression Calculate()
        {
            return FilterBuilder.SafeLessPredicate(Data, Value);
        }
        public string Print() => $"({Name})";
        public IOperand Copy() => new LessFilter(Data) { Value = Value, DisplayValue = DisplayValue };
    }
}
