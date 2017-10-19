using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldStuartPenningtonUWP
{
   class DeskQuote
   {
      //properties
      public Desk DeskStruct { get; set; } //pass desk struct to this class
      public string CustomerName { get; set; }
      public DateTime QuoteDate { get; set; } // get date from the system
      public decimal QuoteAmount { get; set; } // this is where the calculations for the full PRICE quote save

      public DeskQuote()
      {
         DeskStruct = new Desk();
      }

      public double makeDesk(int width, int depth,
         int nDrawers, char days, Desk.Material mat, int numDesks)
      {
         // Make our desk
         DeskStruct = new Desk(width, depth, nDrawers, days, mat);

         // Give back the price
         return calcPrice(numDesks);
      }

      private double calcPrice(int desks)
      {
         // Base price to add to
         double total = 200.0;

         //Add large-size cost
         // Desktop Surface Area > 1000 in(2) $1 per in(2)
         int area = DeskStruct.Width * DeskStruct.Depth;
         if (area > 1000)
            total += area - 1000;

         // Add cost of surface material
         total += getSurfacePrice();

         // Add drawers cost
         total += DeskStruct.NumDrawers * 50;

         // Add rush cost
         total += getRushPrice(desks);

         // Calculate for number of desks
         total *= desks;

         return total;
      }

      private int getSurfacePrice()
      {
         switch (DeskStruct.SurfaceMaterial)
         {
            case Desk.Material.Laminate:
               return 100;
            case Desk.Material.Oak:
               return 200;
            case Desk.Material.Rosewood:
               return 300;
            case Desk.Material.Veneer:
               return 125;
            case Desk.Material.Pine:
               return 50;
            default:
               return 0;
         }
      }

      private int getRushPrice(int desks)
      {
         switch (DeskStruct.RushDays)
         {
            // 3 day rush
            case '3':
               //Small number of desks
               if (desks < 1000)
                  return 60;
               //Medium number of desks
               else if (desks < 2000)
                  return 70;
               //High number of desks
               else
                  return 80;
            // 5 day rush
            case '5':
               if (desks < 1000)
                  return 40;
               else if (desks < 2000)
                  return 50;
               else
                  return 60;
            // 7 day rush
            case '7':
               if (desks < 1000)
                  return 30;
               else if (desks < 2000)
                  return 35;
               else
                  return 40;
            // No rush
            default:
               return 0;
         }
      }

      bool saveDesk()
      {
         // True on success
         return true;
      }
   }
}
