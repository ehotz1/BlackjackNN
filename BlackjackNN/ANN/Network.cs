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
        public double[][] InputWeights { get { return layers[0].GetWeights(); } set { layers[0].SetWeights(value); } }
        public double[][] HiddenWeights { get { return layers[1].GetWeights(); } set { layers[1].SetWeights(value); } }
        public double threshold { get { return layers[2].GetWeights()[0][0]; } set { layers[2].SetWeights(new double[][] { new double[] {value } }); } }
        public double fitness { get { return results.GetFitness(); } }
        public Results results;

        public Network(int rounds)
        {
            layers = new Layer[3];
            results = new Results(rounds);
            CreateLayers();
            
        }

        private void CreateLayers()
        {
            layers[0] = new InputLayer(2); //Input number of neurons for each layer
            layers[1] = new HiddenLayer(2);
            layers[2] = new OutputLayer(1);
        }

        public void SetResults(int round, int win, int player, int dealer)
        {
            if (dealer > 21) dealer = 22; //Treats all dealer busts as the same fitness
            results.SetRoundResult(round, win, player, dealer);
        }

        public void SetWeights(int LayerIndex, double[][] weights)
        {
            layers[LayerIndex].SetWeights(weights);
        }

        public Network Clone(int rounds)
        {
            Network net = new Network(rounds);
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
        
    }

    public struct Results
    {
        int[,] results;
        public Results(int rounds)
        {
            results = new int[rounds, 3];
        }

        public void SetRoundResult(int round, int win, int player, int dealer)
        {

            results[round, 0] = win;
            results[round, 1] = player;
            results[round, 2] = dealer;
        }
        
        public int GetWins()
        {
            int wins = 0;
            for (int i = 0; i < results.GetLength(0); i++)
            {
                if (results[i,0] == 1) wins++;
            }
            return wins;
        }

        public double GetFitness() //Network fitness function
        {
            double fitness = 0;
            int wins = 0;
            for (int i = 0; i < results.GetLength(0); i++)
            {
                if (results[i, 0] == 1)
                {
                    fitness += (double)results[i, 1] / (double)results[i, 2];
                    wins++;
                }
            }
            return (wins == 0) ? 0 : fitness / (double)wins;
        }

        public string PrintResults()
        {
            string s = "";
            for (int i = 0; i < results.GetLength(0); i++)
            {
                s += "Round " + i + ": ";
                s += (results[i, 0] == 0) ? "Loss" : "Win";
                s += "; Player: " + results[i, 1] + ", Dealer: " + results[i, 2] + "\n";
            }
            return s;
        }
    }

}
