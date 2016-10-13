using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public class GeneticAlgorithm
    {
        //Create n NNs, choose best, repopulate
        List<Network> networks;
        private double MutationRate;
        private int Population;
        private int Generations;
        public int NetIndex;

        public bool Stop;

        public GeneticAlgorithm()
        {
            NetIndex = 0;
            networks = new List<Network>();
            Stop = false;
            MutationRate = 0.05;

        }

        public void SetParams(int p, int g)
        {
            Population = p;
            Generations = g;
        }

        public void SetNetworkFitness(bool fit)
        {
            networks[NetIndex].IsFit = fit;
        }

        public void CreateNetworks(int num)
        {
            //Create weights from fit networks, or from random set
            for (int i = 0; i < num; i++)
            {
                networks.Add(new Network());
                //Set weights
            }
        }

        public void Run()
        {
            while (Generations > 0 && !Stop)
            {
                for (int i = 0; i < networks.Count; i++)
                {
                    //Run network
                }
                NextGeneration();
                Generations--;
            }
        }

        public void NextGeneration()
        {
            NetIndex = 0;
            //Remove unfit networks, breed new networks
        }

        public double[][] RandomWeights()
        {
            double[][] weights = { };
            //Create random weights
            return weights;
        }

        public double[] MutatedWeights(double[] wt)
        {
            double[] weights = { };
            //Create array of mutated weights based on wt array 
            return weights;
        }
    }
}
