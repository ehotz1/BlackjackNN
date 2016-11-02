using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public class Network
    {
        public Layer[] layers;
        public bool IsFit;
        public double[][] InputWeights { get { return layers[0].GetWeights(); } set { layers[0].SetWeights(value); } }
        public double[][] HiddenWeights { get { return layers[1].GetWeights(); } set { layers[1].SetWeights(value); } }
        public double threshold { get { return layers[2].GetWeights()[0][0]; } set { layers[2].SetWeights(new double[][] { new double[] {value } }); } }

        public Network()
        {
            IsFit = false;
            layers = new Layer[3];
            CreateLayers();
        }

        private void CreateLayers()
        {
            layers[0] = new InputLayer(2); //Input number of neurons for each layer
            layers[1] = new HiddenLayer(2);
            layers[2] = new OutputLayer(1);
        }

        public void SetWeights(int LayerIndex, double[][] weights)
        {
            layers[LayerIndex].SetWeights(weights);
        }

        public Network Clone()
        {
            Network net = new Network();
            net.InputWeights = this.InputWeights;
            net.HiddenWeights = this.HiddenWeights;
            net.threshold = this.threshold;
            return net;
        }

        public bool Decision()
        {
            //Feed card values to input neurons
            double[] IN_Array = new double[3];
            IN_Array[0] = BlackjackLogic.GetInstance().Player.Hand.Value;
            if (BlackjackLogic.GetInstance().Player.Hand.AceFlag)
            {
                IN_Array[1] = BlackjackLogic.GetInstance().Player.Hand.GetHighValue();
            } else IN_Array[1] = -1;
            IN_Array[2] = BlackjackLogic.GetInstance().DealerHand.Cards[1].NumValue;
            layers[0].SetInputs(IN_Array);
            //Feed values to hidden layer after processing input layer
            layers[1].SetInputs(layers[0].ProcessLayer());
            //Feed to output layer from processing hidden layer
            layers[2].SetInputs(layers[1].ProcessLayer());

            return ((int)layers[2].ProcessLayer()[0] == 1) ? true : false;
            

        }

        public override string ToString()
        {
            return "Layers: " + layers.Length;
        }
    }
}
