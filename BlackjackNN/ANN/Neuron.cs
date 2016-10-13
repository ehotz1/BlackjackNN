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
        public double[] weights { get; private set; }
        public double Output { get; set; }
        //protected double bias;
        //public abstract void NormalizeInputs(); //Convert inputs to usable numbers
        public void SetWeights(double[] w)
        {
            weights = w;
        }
        public void SetInputs(double[] i)
        {
            inputs = i;
        }
        public abstract void ProcessingFunction(); //Process inputs
    }

    public class InputNeuron : Neuron
    {
        

        public override void ProcessingFunction() //Weight inputs and sum
        {
            Output = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                Output += inputs[i] * weights[i];
            }
        }
        

        //public void NormalizeInputs()
        //{
        //    for (int i = 0; i < inputs.Length; i++)
        //    {
        //        inputs[i] = inputs[i] / 10;
        //    }
        //}
    }

    public class HiddenNeuron : Neuron
    {
        
        public override void ProcessingFunction()
        {
            //Activation function
        }

        
    }

    public class OutputNeuron : Neuron
    {
        

        public override void ProcessingFunction()
        {
            //Activation function. Decide whether to hit or stay; output 1 or 0
        }

       
    }
}
