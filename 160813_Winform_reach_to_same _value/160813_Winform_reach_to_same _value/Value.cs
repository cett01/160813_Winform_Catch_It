using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // Stack
namespace _160813_Winform_reach_to_same__value
{
    class Value
    { 
        private int count;
        private string name;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public string Name
        {
            get { return name; }
            set{    name=value;}
        }
        public int element;
        public Value(int _count, string _name) { Count = _count; Name = _name; element = 0; }
       
        public int Increment(bool state,int main, int other)// dogru ise
        {
            if (state){
                Count = Count+main;             
            }

            else {
                Count =Count + other;
            } 
            return Count;
             
        }
       /* public bool Reach (int _value)  {
            if (_value == Count)
                return true;
            else
                return false;    
        }*/
    }
}
