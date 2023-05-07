using System;
using Calculator.MAUI.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calculator.MAUI.Models
{
	public partial class CalculatorModel : ObservableObject
	{
		public CalculatorModel()
		{
		}
        private double _currentValue;
        public double CurrentValue
        {
            get => _currentValue;
            set => SetProperty(ref _currentValue, value);
        }

        private Operation _operator;
        public Operation Operator
        {
            get => _operator;
            set => SetProperty(ref _operator, value);
        }

        private bool _isOperatorClicked;
        public bool IsOperatorClicked
        {
            get => _isOperatorClicked;
            set => SetProperty(ref _isOperatorClicked, value);
        }

        public double Add(double value1, double value2)
        {
            return value1 + value2;
        }
        public double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }
        public double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }
        public double Modulo(double value1, double value2)
        {
            return value1 % value2;
        }
        public double Negate()
        {
            return -CurrentValue;
        }
        public double Divide(double value1, double value2)
        {
            return value1 / value2;
        }
        public void Clear()
        {
            CurrentValue = 0;
            this.Operator = Operation.None;
            IsOperatorClicked = false;
        }
    }
}

