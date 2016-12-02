using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public abstract class Neuron
    {
        protected double[] inputs;
        public double[] weights { get; set; } 
        protected double Output { get; set; }
        public Neuron(int WtArrSize)
        {
            weights = new double[WtArrSize];

        }
        public void SetWeights(double[] w)
        {
            weights = w;
        }
        public void SetInputs(double[] i)
        {
            inputs = i;
        }
        public abstract double ProcessingFunction();
    }

    public class InputNeuron : Neuron
    {
        public InputNeuron(int WtArrSize) : base(WtArrSize)
        {
        }
        

        public new void SetInputs(double[] i)
        {
            inputs = i;
            NormalizeData();
        }

        public override double ProcessingFunction() //Weight inputs, sum
        {
            return inputs[0] * weights[0];
        }

        private void NormalizeData()
        {
            for (int i = 0; i < inputs.Length; i++) 
            {
                inputs[i] = inputs[i]/20;
            }
        }
    }

    public class HiddenNeuron : Neuron
    {
        public HiddenNeuron(int WtArrSize) : base(WtArrSize)
        {
        }

        public override double ProcessingFunction()
        {
            //Transfer function - Modified Sigmoid
            Output = 1 / (1 + Math.Exp(-3+(6*inputs[0])));
            return Output * weights[0];
        }

        
    }

    public class OutputNeuron : Neuron
    {
        public OutputNeuron(int WtArrSize) : base(WtArrSize)
        {
        }

        public override double ProcessingFunction()
        {
            double threshold = weights[0];
            //Activation function. Decide whether to hit or stay
            Output = (inputs[0] > threshold && inputs[1] < threshold) ? 1 : 0;
            return Output;
        }

       
    }
}
