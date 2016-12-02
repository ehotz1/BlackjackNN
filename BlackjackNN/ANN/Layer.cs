using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public abstract class Layer
    {
        public Neuron[] neurons;
        private int index;
        public Layer(int size)
        {
            neurons = new Neuron[size];
            index = 0;
            CreateNeurons();
        }

        public void AddNeuron(Neuron n)
        {
            neurons[index] = n;
            index++;
        }

        public double[][] GetWeights()
        {
            double[][] weights = new double[neurons.Length][];
            for (int i = 0; i < neurons.Length; i++)
            {
                weights[i] = neurons[i].weights;
            }
            return weights;
        }

        public void SetWeights(double[][] wts)
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].SetWeights(wts[i]);
            }
        }

        public double[] ProcessLayer()
        {
            double[] output = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                output[i] = neurons[i].ProcessingFunction();
            }
            return output;
        }

        public abstract void CreateNeurons();
        public abstract void SetInputs(double[] arr);
    }

    public class InputLayer : Layer
    {
        public InputLayer(int size) : base(size)
        {
        }

        public override void CreateNeurons()
        {
            AddNeuron(new InputNeuron(1)); //Input player cards
            AddNeuron(new InputNeuron(1)); //Input dealer card
        }

        public override void SetInputs(double[] arr)
        {
            neurons[0].SetInputs(new double[] { arr[0], arr[1] });
            neurons[1].SetInputs(new double[] { arr[2] });
        }

    }

    public class HiddenLayer : Layer
    {
        public HiddenLayer(int size) : base(size)
        {
        }

        public override void CreateNeurons()
        {
            AddNeuron(new HiddenNeuron(1)); //Process player cards
            AddNeuron(new HiddenNeuron(1)); //Process dealer
        }

        public override void SetInputs(double[] arr)
        {
            neurons[0].SetInputs(new double[] { arr[0] });
            neurons[1].SetInputs(new double[] { arr[1] });
        }
    }

    public class OutputLayer : Layer
    {
        public OutputLayer(int size) : base(size)
        {
        }

        public override void CreateNeurons()
        {
            AddNeuron(new OutputNeuron(1)); //Output to hit or stay
        }

        public override void SetInputs(double[] arr)
        {
            neurons[0].SetInputs(arr);
        }
    }
}
