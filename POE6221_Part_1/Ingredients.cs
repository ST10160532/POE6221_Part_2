using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;

namespace POE6221_Part_1
{
    public class Ingredients
    {

        private string ingredName;
        private int ingredQuantity;
        private string ingredMeasurement;
        private double measurement;
        private double clear;
        private double reset;
        private double measuremntScale;
        private int ingred;
        private Formula[] formula;
        private double calories;
        private string foodGroup;


        public string IngredName
        {
            get { return ingredName; }
            set { ingredName = value; }
        }


        public double Calories
        {
            get { return calories; }
            set { calories = value; }

        }
        public string FoodGroup
        {
            get { return foodGroup; }
            set { FoodGroup = value; }
        }

        public int Ingred
        {
            get { return ingred; }
            set { ingred = value; }
        }

        public int IngredQuantity
        {
            get { return ingredQuantity; }
            set { ingredQuantity = value; }
        }

        public string IngredMeasurement
        {
            get { return ingredMeasurement; }
            set { ingredMeasurement = value; }
        }
        public double MeasuremntScale
        {
            get { return measuremntScale; }
            set { measuremntScale = value; }
        }

        public Formula[] Formula
        {
            get { return formula; }
            set { formula = value; }
        }
        public double Measurement
        {
            get { return measurement; }
            set { measurement = value; }
        }
        public double Reset
        {
            get { return reset; }
            set { reset = value; }
        }

        public double Clear
        {
            get { return clear; }
            set { clear = value; }
        }
        public Ingredients(Formula[] formula, string ingredMeasurement, int ingredQuantity, string ingredName, int calories, string foodGroup)
        {
            this.formula = formula;
            this.ingredMeasurement = ingredMeasurement;
            this.ingredQuantity = ingredQuantity;
            this.ingredName = ingredName;
            this.calories = calories;
            this.foodGroup = foodGroup;


        }

        public Ingredients()
        {

        }

        public Ingredients(double measuremntScale)
        {
            this.measuremntScale = measuremntScale;
        }
        //My notififcation delegate declaration
        public delegate void CaloriesNotifier(string Notitfication);

        //calculate the scales
        public void ScaleCalc()
        {
            double MeasuremntScaleOpt = double.Parse(Console.ReadLine());

            switch (MeasuremntScaleOpt)
            {

                case 1:
                    measuremntScale = 0.5;
                    break;
                case 2:
                    measuremntScale = 2;
                    break;
                case 3:
                    measuremntScale = 3;
                    break;
                default:
                    measuremntScale = 0;
                    break;

            }
            measurement = measuremntScale * ingredQuantity;

            Console.WriteLine();
            Console.WriteLine(measurement + " " + ingredMeasurement + " of " + ingredName);

            Console.WriteLine();

            Console.WriteLine();

        }

        //Reset the input 
        public void ResetScale()
        {

            reset = measuremntScale;
            Console.WriteLine();
            Console.WriteLine(reset + " " + ingredMeasurement + " of " + ingredName);

            Console.WriteLine();


            Console.WriteLine();


        }

        //clear all data 
        public void ClearScale()
        {
            clear = 0;
            ingredMeasurement = "";
            ingredName = "";
            Console.WriteLine();


            Console.WriteLine("Data is cleared!!");

            Console.WriteLine();

        }


        //calc my total ingred calories
        public static double CalcCalories(Ingredients[] ingredients)
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories * ingredient.IngredQuantity;
            }
            return totalCalories;
        }

        //display method
        public void Display()
        {
            foreach (var steps in formula)
            {

                Console.WriteLine();
                Console.WriteLine(ingredQuantity + " " + ingredMeasurement + " of " + ingredName);


                Console.WriteLine();
                Console.WriteLine("Steps: ");

                Console.WriteLine();
                Console.WriteLine(steps.IngredInstruction);



                Console.WriteLine();
            }







        }


       
    }

}