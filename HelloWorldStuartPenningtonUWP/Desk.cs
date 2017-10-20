using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldStuartPenningtonUWP
{
   struct Desk
   {
      public enum Material
      {
         Laminate = 100,
         Oak = 20,
         Rosewood = 300,
         Veneer = 125,
         Pine = 50,
         None = 0
      }

      public string first { get; set; }
      public string last { get; set; }
      public int Width { get; set; }
      public int Depth { get; set; }
      public int NumDrawers { get; set; }
      public int RushDays { get; set; }
      public Material SurfaceMaterial { get; set; }

      /// <summary>
      /// Construct a desk with the given parameters
      /// </summary>
      /// <param name="width"></param>
      /// <param name="depth"></param>
      /// <param name="nDrawers"></param>
      /// <param name="days"></param>
      /// <param name="mat"></param>
      public Desk(string fir, string las, int width, int depth,
         int nDrawers, int days, Desk.Material mat)
      {
         this.first = fir;
         this.last = las;
         this.Width = width;
         this.Depth = depth;
         this.NumDrawers = nDrawers;
         this.RushDays = days;
         this.SurfaceMaterial = mat;
      }
   }
}
