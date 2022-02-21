using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace murzaev_mvvm
{
    class viewpattern:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string rezultChanged
        {
            get
            {
                return pattern.itog.ToString();
            }
        }
        public List<string> operCombo
        {
            get
            {
                return pattern.operList;
            }
        }
        public int operInd
        {
            set
            {
                pattern.operId = value;
            }
        }
        public static string tbOne
        {
            set
            {
                pattern.one = Convert.ToInt32(value);
            }
        }
        public static string tbTwo
        {
            set
            {
                pattern.two = Convert.ToInt32(value);
            }
        }
        public RoutedCommand buttRez { get; set; } = new RoutedCommand();
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            switch (pattern.operId)
            {
                case 0:
                    pattern.itog = pattern.one + pattern.two;
                    break;
                case 1:
                    pattern.itog = pattern.one - pattern.two;
                    break;
                case 2:
                    pattern.itog = pattern.one * pattern.two;
                    break;
                case 3:
                    pattern.itog = pattern.one / pattern.two;
                    break;
                default:
                    pattern.itog = 404;
                    break;
            }
            PropertyChanged(this, new PropertyChangedEventArgs("rezultChanged"));
        }
        public CommandBinding bind;
        public viewpattern()
        {
            bind = new CommandBinding(buttRez);
            bind.Executed += Command_Executed;
        }
    }
}

