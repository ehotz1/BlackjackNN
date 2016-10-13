using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public class Network
    {
        Layer[] layers;
        public bool IsFit;
        double[][] InputWeights { get { return layers[0].GetWeights(); } }
        double[][] HiddenWeights { get { return layers[1].GetWeights(); } }

        public Network()
        {
            IsFit = false;
            layers = new Layer[3];
            CreateLayers();
        }

        private void CreateLayers()
        {
            layers[0] = new InputLayer();
            layers[1] = new HiddenLayer();
            layers[2] = new OutputLayer();
        }

        public void SetWeights(int LayerIndex, double[][] weights)
        {
            layers[LayerIndex].SetWeights(weights);
        }

        public void Run()
        {
            //Feed card values to input neurons
            double[] IN_Array = { };
            int index = 0;
            foreach (Card c in BlackjackLogic.GetInstance().Player.Hand.Cards)
            {
                IN_Array[index] = c.NumValue;
                index++;
            }
            IN_Array[index] = BlackjackLogic.GetInstance().DealerHand.Cards[1].NumValue;
            layers[0].SetInputs(IN_Array);
            //Feed values to hidden layer after processing input layer
            layers[1].SetInputs(layers[0].ProcessLayer());
            //Feed to output layer from processing hidden layer
            layers[2].SetInputs(layers[1].ProcessLayer());

            bool ShouldHit = ((int)layers[2].ProcessLayer()[0] == 1) ? true : false;

            if (ShouldHit) BlackjackLogic.GetInstance().Hit();
            else BlackjackLogic.GetInstance().Stay();

        }
    }
}
