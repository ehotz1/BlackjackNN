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
        private double MutationChance;
        private double WinThreshold;
        private int Population;
        private int Generations;
        public int RoundNumber;
        private Random r;
        private NetInterface NetDisplay;
        public bool Stop;

        public GeneticAlgorithm()
        {
            RoundNumber = 5;
            Stop = true;
            MutationRate = 0.05;
            MutationChance = 0.5;
            WinThreshold = 0.75;
            r = new Random();
            NetDisplay = new NetInterface(this);
            NetDisplay.Show();
        }

        public void SetParams(int pop, int gen, int rounds, int per)
        {
            Population = pop;
            Generations = gen;
            RoundNumber = rounds;
            WinThreshold = (double)per/100;
            networks = new List<Network>();
            CreateNetworks(pop, false);
        }
        

        public void Run()
        {

            while (Generations > 0 && !Stop)
            {
                int NetIndex = 0;
                for (int i = 0; i < networks.Count; i++)
                {
                    for (int j = 0; j < RoundNumber; j++)
                    {
                        BlackjackLogic.GetInstance().PlayRound();
                        while (BlackjackLogic.GetInstance().CanAct)
                        {
                            if (networks[NetIndex].Decision())
                            {
                                BlackjackLogic.GetInstance().Hit();
                            }
                            else
                            {
                                BlackjackLogic.GetInstance().Stay();
                            }
                        }
                        int[] results = BlackjackLogic.GetInstance().round_replay.GetRoundResults();
                        networks[NetIndex].SetResults(j, results[0], results[1], results[2]);
                    }
                    NetIndex++;
                }
                NextGeneration();
                Generations--;
            }
            if (Generations == 0) NetDisplay.Reset();
        }

        public void NextGeneration()
        {
            //Remove unfit networks, breed new networks
            for (int i = networks.Count - 1; i >= 0; i--)
            {
                if ((double)networks[i].results.GetWins()/RoundNumber < WinThreshold) 
                {
                    networks.RemoveAt(i);
                }
            }
            int num = Population - networks.Count;
            double percentage = ((double)networks.Count / (double)Population) * 100;
            NetDisplay.UpdateDisplay("Fit networks: " + percentage + "%");
            CreateNetworks(num, true);
        }

        public void CreateNetworks(int num, bool mutate) //Create weights from fit networks, or from random set
        {
            List<Network> newNetworks = new List<Network>();
            if (mutate) //Sort networks by fitness, pick from the top
            {
                networks.Sort(delegate(Network x, Network y)
                {
                    if (x.fitness == y.fitness) return 0;
                    else if (x.fitness < y.fitness) return 1;
                    else return -1;
                });
            }
            
            for (int i = 0; i < num; i++)
            {
                Network net = (mutate) ? GetRandomFitNetwork() : new Network(RoundNumber);
                
                SetNetworkWeights(net, mutate);
                newNetworks.Add(net);
            }
            networks.AddRange(newNetworks);
        }
        
        public Network GetRandomFitNetwork() 
        {
            if (networks.Count == 0) //In case of population crash, create new random network
            {
                Network net = new Network(RoundNumber);
                SetNetworkWeights(net, false);
                return net;
            }

            int i = r.Next((int)(networks.Count*.75), networks.Count - 1);
            return networks[i].Clone(RoundNumber);
        }

        public double[] RandomWeights(int l) 
        {
            double[] weights = new double[l];
            for (int i = 0; i < l; i++)
            {
                weights[i] = r.NextDouble();
            }
            
            return weights;
        }

        public double[] MutatedWeights(double[] wt) 
        {
            for (int i = 0; i < wt.Length; i++)
            {
                bool positive = (r.NextDouble() >= 0.5) ? true : false;
                wt[i] += (positive) ? (r.NextDouble() * MutationRate) : (-r.NextDouble() * MutationRate);
                if (wt[i] < 0) wt[i] = 0;
                if (wt[i] > 1) wt[i] = 1;
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
        
        public void TestTopNetwork()
        {
            for (int j = 0; j < 10; j++)
            {
                BlackjackLogic.GetInstance().PlayRound();
                while (BlackjackLogic.GetInstance().CanAct)
                {
                    if (networks[0].Decision())
                    {
                        BlackjackLogic.GetInstance().Hit();
                    }
                    else
                    {
                        BlackjackLogic.GetInstance().Stay();
                    }
                }
                NetDisplay.UpdateDisplay(BlackjackLogic.GetInstance().round_replay.PrintReplay());
            }
        }

        public List<double[][]> GetTopNetworkWeights()
        {
            List<double[][]> weights = new List<double[][]>();
            weights.Add(networks[0].InputWeights);
            weights.Add(networks[0].HiddenWeights);
            weights.Add(new double[][] { new double[] { networks[0].threshold } });
            return weights;
        }
        
    }

    
}
