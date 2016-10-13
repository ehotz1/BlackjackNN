using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public abstract class Layer
    {
        protected Neuron[] neurons;
        public int size;
        protected int[] OutputIndexes; //Denotes which neurons outputs should be sent to
        public Layer()
        {
            neurons = new Neuron[] { };
            size = 0;
            CreateNeurons();
        }

        public void AddNeuron(Neuron n)
        {
            neurons[size] = n;
            size++;
        }

        public double[][] GetWeights()
        {
            double[][] weights = { };
            for (int i = 0; i < neurons.Length; i++)
            {
                weights[i] = neurons[i].weights;
            }
            return weights;
        }

        public void SetWeights(double[][] wts)
        {
            for (int i = 0; i < size; i++)
            {
                neurons[i].SetWeights(wts[i]);
            }
        }

        

        public double[] ProcessLayer()
        {
            double[] output = { };
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].ProcessingFunction();
                output[i] = neurons[i].Output;
            }
            return output;
        }

        public abstract void CreateNeurons();
        public abstract void SetInputs(double[] arr);
    }

    public class InputLayer : Layer
    {
        public override void CreateNeurons()
        {
            AddNeuron(new InputNeuron()); //Input player cards
            AddNeuron(new InputNeuron()); //Input dealer card
        }

        public override void SetInputs(double[] arr)
        {
            double[] PlayerCards = { };
            Array.Copy(arr, PlayerCards, arr.Length - 1);
            neurons[0].SetInputs(PlayerCards);
            neurons[1].SetInputs(new double[] { arr[arr.Length] });
        }

    }

    public class HiddenLayer : Layer
    {
        public override void CreateNeurons()
        {
            AddNeuron(new HiddenNeuron()); //Process player cards
            AddNeuron(new HiddenNeuron()); //Process player/dealer
            AddNeuron(new HiddenNeuron()); //Process dealer
        }

        public override void SetInputs(double[] arr)
        {
            neurons[0].SetInputs(new double[] { arr[0] });
            neurons[1].SetInputs(new double[] { arr[0], arr[1] });
            neurons[2].SetInputs(new double[] { arr[1] });
        }
    }

    public class OutputLayer : Layer
    {
        public override void CreateNeurons()
        {
            AddNeuron(new OutputNeuron()); //Output to hit or stay
        }

        public override void SetInputs(double[] arr)
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].SetInputs(new double[] { arr[i] });
            }
        }
    }
}
