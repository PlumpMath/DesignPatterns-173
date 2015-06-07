using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFSimulator.Circuits;
using WFSimulator.Handlers;

namespace WFSimulator
{
    public partial class Simulator : Form
    {
        CircuitController controller;
        public Simulator()
        {
            InitializeComponent();
            NodeMediator nMediator = new NodeMediator();
            NodeFactory nFactory = NodeFactory.Instance;
            nFactory.setMediator(nMediator);
            CircuitBuilder nCircuitBuilder = new CircuitBuilder(nFactory);
            CircuitManager nManager = new CircuitManager(nCircuitBuilder);
            controller = new CircuitController(nMediator, nManager);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.BuildCircuit(openFileDialog.FileName);
                textBox1.Clear();
                foreach (string line in controller.getOutput())
                {
                    textBox1.AppendText(line);
                    textBox1.AppendText(Environment.NewLine);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.Start();
        }

 
    }
}
