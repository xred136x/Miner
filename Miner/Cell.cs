using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Runtime.Remoting.Contexts;

namespace Miner
{
    internal class Cell
    {
        private Button myButton;
       
        public Button button { get { return myButton;} }
        private string Name;
        public string name { get { return Name; } }
        private int x;
        public int X {get {return x;} }
        private int y;
        public int Y { get { return y; } }
        private bool IsMine = false;
        public bool isMine { get { return IsMine; } }
        private string Reverse = " ";
        public string reverse { get { return Reverse; } }
        private int CountMineArround = 0;
        public int countMineArround { get { return CountMineArround; } }
        static private int _point;
        public int Setpoint(int point){ _point += point; return _point; }
        public Cell(string name, int x, int y, string _content = " ", bool printMine = false)
        {
            this.myButton = new Button();
            this.x = x;
            this.y = y;
            this.myButton.Height = 70;
            this.myButton.Width = 70;
            this.myButton.FontSize = 20;
            this.myButton.HorizontalAlignment = HorizontalAlignment.Center;
            this.myButton.VerticalAlignment = VerticalAlignment.Center;
            this.Name = name;  
            this.myButton.Content = _content;
            
            this.myButton.Click += MyButton_Click;
        }
        private void setReverse(string _reverse)
        {
            this.Reverse = _reverse;
        }

        public void MyButton_Click(object sender, RoutedEventArgs e)
        {
            int point = 10;
            this.myButton.Content = this.Reverse;
            switch (reverse)
            {
                case " ":
                    this.myButton.Background = Brushes.DarkSlateGray;
                     _point += point;                    
                    break;
                case "1":
                    this.myButton.Background = Brushes.LightGreen;                    
                     _point += point;                    
                    break;
                case "2":
                    this.myButton.Background = Brushes.LightPink;                    
                    _point = point;                   
                    break;
                case "3":
                    this.myButton.Background = Brushes.LightSkyBlue;
                    _point += point;                    
                    break;
                case "4":
                    this.myButton.Background = Brushes.LightYellow;                  
                    _point += point;                    
                    break;
                case "5":
                    this.myButton.Background = Brushes.LightSlateGray;                    
                    _point += point;                    
                    break;
                case "B":
                    this.myButton.Background = Brushes.IndianRed;
                    break;
                default:
                    break;
            }
            GameOver();
        }
        public void growCountOfMineArround()
        {
            this.CountMineArround++;
            this.Reverse = $"{CountMineArround}";
        }
        public void setBomb()
        {
            this.IsMine = true;
            this.Reverse = "B";
        }
        public void GameOver()
        {
            if(this.IsMine == true)
            {
                MessageBox.Show("Game Over" + " " + $"Набранные очки: {_point}");
            }
        }
        
    }
}
