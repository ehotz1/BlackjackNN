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
        private Random r;
        private NetInterface NI;
        public bool Stop;

        public GeneticAlgorithm(int p, int g)
        {
            NetIndex = 0;
            networks = new List<Network>();
            Stop = true;
            MutationRate = 0.05;
            SetParams(p, g);
            r = new Random();
            CreateNetworks(p, false);
            NI = new NetInterface(this);
            NI.Show();
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

        public void Run()
        {

            while (Generations > 0 && !Stop)
            {
                for (int i = 0; i < networks.Count; i++)
                {
                    //Run network
                    BlackjackLogic.GetInstance().PlayRound();
                    while (BlackjackLogic.GetInstance().CanAct)
                    {
                        if (networks[NetIndex].Decision())
                        {
                            BlackjackLogic.GetInstance().Hit();
                        } else
                        {
                            BlackjackLogic.GetInstance().Stay();
                        }
                    }
                }
                NextGeneration();
                Generations--;
            }
        }

        public void NextGeneration()
        {
            NetIndex = 0;
            //Remove unfit networks, breed new networks
            for (int i = networks.Count - 1; i >= 0; i--)
            {
                if (!networks[i].IsFit)
                {
                    networks.RemoveAt(i);
                }
            }
            int num = Population - networks.Count;
            PushUpdate();
            CreateNetworks(num, true);
        }

        public void CreateNetworks(int num, bool mutate)
        {
            //Create weights from fit networks, or from random set
            for (int i = 0; i < num; i++)
            {
                Network net = (mutate) ? GetRandomNetwork() : new Network();
                
                SetNetworkWeights(net, mutate);
                networks.Add(net);
            }
        }

        public Network GetRandomNetwork() //Returns a random network from the network list
        {
            if (networks.Count == 0) return new Network();
            return networks[r.Next(networks.Count)].Clone();
        }

        public double[] RandomWeights(int l)  //Create random weights
        {
            double[] weights = new double[l];
            for (int i = 0; i < l; i++)
            {
                weights[i] = r.NextDouble();
            }
            
            return weights;
        }

        public double[] MutatedWeights(double[] wt) //TODO: look up proper mutation process
        {
            for (int i = 0; i < wt.Length; i++)
            {
                bool positive = (r.NextDouble() >= 0.5) ? true : false;
                wt[i] += (positive) ? (r.NextDouble() * MutationRate) : (-r.NextDouble() * MutationRate);
            }
            return wt;
        }
        
        public void SetNetworkWeights(Network n, bool mutate) 
        {
            for (int i = 0; i < n.layers.Length; i++)
            {
                for (int j = 0; j < n.layers[i].neurons.Length; j++)
                {
                    if (mutate)
                    {
                        n.layers[i].neurons[j].SetWeights(MutatedWeights(n.layers[i].neurons[j].weights));
                    }
                    else
                    {
                        n.layers[i].neurons[j].SetWeights(RandomWeights(n.layers[i].neurons[j].weights.Length));
                    }
                }
            }
        }

        private void PushUpdate()
        {
            string output = "";
            double percentage = ((double)networks.Count / (double)Population) * 100;
            output += "Generation: " + Generations + " Win: " + percentage + "%";
            NI.UpdateDisplay(output);
        }
        
    }
}
