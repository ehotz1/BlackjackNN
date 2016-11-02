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
        //protected double bias;
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
        public abstract double ProcessingFunction(); //Process inputs
    }

    public class InputNeuron : Neuron
    {
        public InputNeuron(int WtArrSize) : base(WtArrSize)
        {
        }

        //inputs[0]: hand value
        //inputs[1]: second hand value; only used if player's hand contains an ace
        //weights[0]: weight for hand value
        //weights[1/2]: used to weight ace low/ace high hands

        public new void SetInputs(double[] i)
        {
            inputs = i;
            //NormalizeInputs();
        }

        public override double ProcessingFunction() //Weight inputs, sum
        {
            //If a second hand value exists - an Ace in hand - choose which value to use based on step function
            int i = 0;
            if (inputs.Length > 1 && inputs[1] != -1)
            {
                i = (inputs[0] * weights[1] > inputs[1] * weights[2]) ? 0 : 1;
            }
            
            return inputs[i] * weights[0];
            
        }


        public void NormalizeInputs()
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = inputs[i] - 10; //Normalize data for hidden neuron sigmoid function
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
            //Activation function - Sigmoid, modified to process outputs for values from 2 to 20
            
            Output = 1 / (1 + Math.Exp(-5+.5 * inputs[0]));
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
            //Activation function. Decide whether to hit or stay; output 1 or 0
            Output = (inputs[0] + inputs[1] > threshold) ? 1 : 0;
            return Output;
        }

       
    }
}
