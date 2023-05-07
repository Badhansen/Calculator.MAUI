using System;
using System.Windows.Input;
using Calculator.MAUI.Models;
using Calculator.MAUI.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calculator.MAUI.ViewModels
{
	public partial class CalculatorViewModel : ObservableObject
	{
        private CalculatorModel _model;

        public CalculatorViewModel()
        {
            this._model = new CalculatorModel();
        }
		private string _displayText;
        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText, value);
        }

		public ICommand OperationCommand => new RelayCommand<Operation>(OperatorClicked);
        public ICommand NumericCommand => new RelayCommand<string>(NumberClicked);
        public ICommand ClearCommand => new RelayCommand(ClearClicked);
        public ICommand EqualCommand => new RelayCommand(EqualClicked);

        private void OperatorClicked(Operation _operator)
        {
            if (!double.TryParse(DisplayText, out double currentValue))
            {
                return;
            }
            _model.CurrentValue = currentValue;

            if (_operator == Operation.Negate)
            {
                _model.CurrentValue = _model.Negate();
                if (_model.CurrentValue < 0)
                {
                    DisplayText = "-" + DisplayText;
                }
                else
                {
                    DisplayText = _model.CurrentValue.ToString();
                }
                return;
            }
            if (_model.Operator != Operation.None)
            {
                currentValue = Calculate();
            }

            
            _model.Operator = _operator;
            _model.IsOperatorClicked = true;
        }

        private void NumberClicked(string number)
        {
            if (_model.IsOperatorClicked)
            {
                DisplayText = "";
                _model.IsOperatorClicked = false;
            }

            DisplayText += number;
        }

        private void EqualClicked()
        {
            double result = Calculate();
            DisplayText = result.ToString();
            _model.Clear();
        }

        private void ClearClicked()
        {
            DisplayText = "";
            _model.Clear();
        }

        private double Calculate()
        {
            double currentValue = double.Parse(DisplayText);

            switch (_model.Operator)
            {
                case Operation.Modulo:
                    return _model.Modulo(_model.CurrentValue, currentValue);
                case Operation.Add:
                    return _model.Add(_model.CurrentValue, currentValue);
                case Operation.Subtract:
                    return _model.Subtract(_model.CurrentValue, currentValue);
                case Operation.Multiply:
                    return _model.Multiply(_model.CurrentValue, currentValue);
                case Operation.Divide:
                    if (currentValue == 0)
                    {
                        DisplayText = "Can't Divide with zero";
                        break;
                    }
                    return _model.Divide(_model.CurrentValue, currentValue);
                default:
                    return currentValue;
            }
            return currentValue;
        }
    }
}

