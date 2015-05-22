using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CircuitSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            NodeMediator nMediator = new NodeMediator();
            NodeFactory nFactory = NodeFactory.Instance;
            CircuitBuilder nCircuitBuilder = new CircuitBuilder(nMediator,nFactory);
            DataContext = new CircuitController(nMediator, nCircuitBuilder);
            InitializeComponent();
        }
    }
}
